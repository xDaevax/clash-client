using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using ClashClient.Common.Caching;
using ClashClient.Common.Configuration;
using ClashClient.Configuration;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ClashClient.Net {
    /// <summary>
    /// Class used to connect to the API.
    /// </summary>
    public class ApiClient : IApiClient {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region --Instance Varibles--

        private readonly ICacheProvider _cacheProvider;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly JsonSerializer _serializer;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class.
        /// </summary>
        /// <param name="configurationProvider">The <see cref="IConfigurationProvider"/> instance used to load configuration data.</param>
        /// <param name="cacheProvider">The <see cref="ICacheProvider"/> instance used to manage cached data.</param>
        public ApiClient(IConfigurationProvider configurationProvider, ICacheProvider cacheProvider) {
            this._configurationProvider = configurationProvider;
            this._serializer = new JsonSerializer();
            this.Serializer.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
            this._cacheProvider = cacheProvider;
        } // end defaualt constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Returns the data from making a call to the clash-of-clans API.
        /// </summary>
        /// <typeparam name="TResponse">The type of response object expected back from the API.</typeparam>
        /// <param name="apiRequest">The <see cref="ApiRequest"/> that contains the data used to customize the API call.</param>
        /// <returns>A new <see cref="ApiResponse"/> instance with the results of the API call.</returns>
        public virtual ApiResponse<TResponse> Load<TResponse>(ApiRequest apiRequest) where TResponse : class {
            if (apiRequest == null) {
                throw new ArgumentNullException("apiRequest", "No request was provided.");
            }

            var response = new ApiResponse<TResponse>();
            var responseMessages = new List<ApiMessage>();
            HttpWebRequest request = null;

            request = this.BuildRequest(apiRequest);

            string cacheName = $"ApiResponse_{apiRequest.ToCacheName(new QueryStringFormatter())}";
            var cachedResponse = this.CacheProvider.Read<ApiResponse<TResponse>>(cacheName);
            var workingResponse = new ApiResponse<TResponse>();

            if (cachedResponse == null || !cachedResponse.CacheHit()) {
                string responseContents = string.Empty;

                try {
                    using (var resp = (HttpWebResponse)request.GetResponse()) {
                        workingResponse.HttpStatusCode = (int)resp.StatusCode;
                        using (var sr = new StreamReader(resp.GetResponseStream())) {
                            responseContents = sr.ReadToEnd();
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(responseContents)) {
                        using (var stringReader = new StringReader(responseContents)) {
                            using (var jsonReader = new JsonTextReader(stringReader)) {
                                try {
                                    workingResponse.Successful = true;
                                    workingResponse.Data = this.Serializer.Deserialize<TResponse>(jsonReader);
                                    responseMessages.Add(new ApiMessage("API call succeeded.", "1.001.001", ApiMessageCategory.Diagnostic));
                                } catch (JsonSerializationException jse) {
                                    workingResponse.Successful = false;
                                    Log.Error("Unable to deserialize API response.", jse);
                                    responseMessages.Add(new ApiMessage($"Unable to serialize the API response: {jse.Message}.  See the logs for more information.", "3.001.001", ApiMessageCategory.Failure));
                                }
                            }
                        }
                    } else {
                        workingResponse.Successful = true;
                        responseMessages.Add(new ApiMessage("No reponse body received from API.", "2.001.001", ApiMessageCategory.Problem));
                    }
                } catch (WebException wex) {
                    workingResponse.Successful = false;
                    Log.Error($"An error occurred while invoking the api: {request.RequestUri}.", wex);
                    if (wex.Response is HttpWebResponse errorResponse) {
                        workingResponse.HttpStatusCode = (int)errorResponse.StatusCode;
                        if (errorResponse.StatusCode == HttpStatusCode.BadRequest || errorResponse.StatusCode == HttpStatusCode.Forbidden || errorResponse.StatusCode == HttpStatusCode.InternalServerError || errorResponse.StatusCode == HttpStatusCode.NotFound || errorResponse.StatusCode == HttpStatusCode.ServiceUnavailable) {
                            var errorDetail = this.ParseErrorResponse(errorResponse);
                            if (errorDetail != null) {
                                responseMessages.Add(new ApiMessage($"Error Detail: {errorDetail.Reason} - {errorDetail.Message}", "3.001.004", ApiMessageCategory.Failure));
                            } else {
                                Log.Warn($"Unable to read the error response from the API.");
                                responseMessages.Add(new ApiMessage($"Unable to read the response from the API: {request.RequestUri}.", "3.001.005", ApiMessageCategory.Failure));
                            }
                        } else {
                            responseMessages.Add(new ApiMessage($"An unknown status was returned from the API: {errorResponse.StatusCode}.", "3.001.002", ApiMessageCategory.Failure));
                        }
                    } else {
                        responseMessages.Add(new ApiMessage($"The API response is not available or could not be found for endpoint: {request.RequestUri}.", "3.001.003", ApiMessageCategory.Failure));
                    }
                } finally {

                    response = new ApiResponse<TResponse> {
                        Successful = workingResponse.Successful,
                        Data = workingResponse.Data,
                        HttpStatusCode = workingResponse.HttpStatusCode,
                        Messages = responseMessages.ToList()
                    };
                    responseMessages.Add(new ApiMessage("Response loaded from cache.", ApiMessageCategory.Diagnostic));
                    workingResponse.Messages = responseMessages;
                    if (workingResponse.Successful) {
                        var dataToCache = new CacheEntry<ApiResponse<TResponse>>(workingResponse) { CachePreference = CachePreference.ShortLivedSliding };
                        this.CacheProvider.Set(cacheName, dataToCache);
                    }
                }
            } else {
                response = cachedResponse.LoadCachedData();
            }

            return response;
        } // end function Load

        /// <summary>
        /// Builds the <see cref="HttpWebRequest"/> instance that will be used to request data from the API.
        /// </summary>
        /// <param name="apiRequest">The <see cref="ApiRequest"/> that contains the data used to customize the API call.</param>
        /// <returns>A new instance of the <see cref="HttpWebRequest"/> class.</returns>
        /// <exception cref="ConfigurationErrorsException">Thrown if the URL for the API isn't provided in configurataion.</exception>
        protected virtual HttpWebRequest BuildRequest(ApiRequest apiRequest) {
            string baseUrl = string.Empty;
            HttpWebRequest request = null;
            string version = string.Empty;
            string apiToken = string.Empty;

            if (this.ConfigurationProvider.TryGetValue(ConfigurationKeys.BaseApiUrlKey, out baseUrl)) {
                if (this.ConfigurationProvider.TryGetValue(ConfigurationKeys.ApiVersionKey, out version)) {
                    string apiUrl = $"{baseUrl}/{version}/{apiRequest.Method}".Replace("///", "/");
                    string parameters = apiRequest.ParametersToQueryString(new QueryStringFormatter());
                    string urlArgs = apiRequest.ParametersToUrlPath();
                    if (this.ConfigurationProvider.TryGetValue(ConfigurationKeys.ApiTokenKey, out apiToken)) {
                        string targetUrl = apiUrl;
                        if (!string.IsNullOrWhiteSpace(urlArgs)) {
                            targetUrl += urlArgs;
                        }

                        if (!string.IsNullOrWhiteSpace(parameters)) {
                            targetUrl += string.Concat("?", parameters);
                        }

                        request = (HttpWebRequest)WebRequest.Create(targetUrl);
                        request.Headers.Add("authorization", string.Concat("Bearer ", apiToken));
                        request.Accept = "application/json";
                    } else {
                        throw new ConfigurationErrorsException("Unable to load developer API key.");
                    }
                } else {
                    throw new ConfigurationErrorsException("Unable to load the API version.");
                }
            } else {
                throw new ConfigurationErrorsException("Unable to load the API url.");
            }
            
            
            return request;
        } // end function BuildRequest

        /// <summary>
        /// Parses the API response when an error occurs.
        /// </summary>
        /// <returns>A new instance of the <see cref="ErrorResponse"/> type from the data in the <param name="webResponse">webResponse</param>.</returns>
        protected virtual ErrorResponse ParseErrorResponse(HttpWebResponse webResponse) {
            var response = new ErrorResponse();
            string data = string.Empty;
            using (var responseStream = webResponse.GetResponseStream()) {
                using (var reader = new StreamReader(responseStream)) {
                    data = reader.ReadToEnd();
                }
            }

            using (var reader = new StringReader(data)) {
                using (var txtReader = new JsonTextReader(reader)) {
                    response = this.Serializer.Deserialize<ErrorResponse>(txtReader);
                }
            }

            return response;
        } // end function ParseErrorResponse

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets the injected <see cref="ICacheProvider"/> instance used to manage data in cache.
        /// </summary>
        protected ICacheProvider CacheProvider {
            get => this._cacheProvider;
        } // end property CacheProvider

        /// <summary>
        /// Gets the injected <see cref="IConfigurationProvider"/> instance used to load configuration data.
        /// </summary>
        protected IConfigurationProvider ConfigurationProvider {
            get {
                return this._configurationProvider;
            }
        } // end property ConfigurationProvider

        /// <summary>
        /// Gets the serializer instance used to read the response data from the API into strongly typed objects.
        /// </summary>
        protected JsonSerializer Serializer {
            get {
                return this._serializer;
            }
        } // end property Serializer

        #endregion
    } // end class ApiClient
} // end namespace
