using ClashClient.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClashClient.Net {
    /// <summary>
    /// Class used to connect to the API.
    /// </summary>
    public class ApiClient {
        #region --Instance Varibles--

        private IConfigurationProvider _configurationProvider;
        private JsonSerializer _serializer;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class.
        /// </summary>
        /// <param name="configurationProvider">The <see cref="IConfigurationProvider"/> instance used to load configuration data.</param>
        public ApiClient(IConfigurationProvider configurationProvider) {
            this._configurationProvider = configurationProvider;
            this._serializer = new JsonSerializer();
        } // end defaualt constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Returns the data from making a call to the clash-of-clans API.
        /// </summary>
        /// <typeparam name="TResponse">The type of response object expected back from the API.</typeparam>
        /// <param name="apiRequest">The <see cref="ApiRequest"/> that contains the data used to customize the API call.</param>
        /// <returns>A new <see cref="ApiResponse"/> instance with the results of the API call.</returns>
        public virtual ApiResponse Load<TResponse>(ApiRequest apiRequest) where TResponse : class {
            if (apiRequest == null) {
                throw new ArgumentNullException("apiRequest", "No request was provided.");
            }

            ApiResponse response = new ApiResponse();
            HttpWebRequest request = null;

            request = this.BuildRequest(apiRequest);
            string responseContents = string.Empty;

            try {
                using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse()) {
                    using (var sr = new StreamReader(resp.GetResponseStream())) {
                        responseContents = sr.ReadToEnd();
                    }
                }

                if (!string.IsNullOrWhiteSpace(responseContents)) {
                    using (var stringReader = new StringReader(responseContents)) {
                        using (var jsonReader = new JsonTextReader(stringReader)) {
                            try {
                                response.Data = this._serializer.Deserialize<TResponse>(jsonReader);
                            } catch (JsonSerializationException) {
                                // TODO: Better Error handling
                                throw;
                            }
                        }
                    }
                }
            } catch (WebException wex) {
                var errorResponse = wex.Response as HttpWebResponse;
                if (errorResponse != null && errorResponse.StatusCode == HttpStatusCode.BadRequest) {
                    response.Data = this.ParseErrorResponse(errorResponse);
                }
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

            if (this.ConfigurationProvider.TryGetValue<string>(ConfigurationKeys.BaseApiUrlKey(), out baseUrl)) {
                if (this.ConfigurationProvider.TryGetValue<string>(ConfigurationKeys.ApiVersionKey(), out version)) {
                    string apiUrl = string.Concat(baseUrl, "//", version, "/", apiRequest.Method).Replace("///", "/");
                    string parameters = apiRequest.ParametersToQueryString(new QueryStringFormatter());
                    if (this.ConfigurationProvider.TryGetValue<string>(ConfigurationKeys.ApiTokenKey(), out apiToken)) {
                        request = (HttpWebRequest)HttpWebRequest.Create(string.Concat(apiUrl, "?", parameters));
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
            ErrorResponse response = new ErrorResponse();
            string data = string.Empty;
            using (var responseStream = webResponse.GetResponseStream()) {
                using (var reader = new StreamReader(responseStream)) {
                    data = reader.ReadToEnd();
                }
            }

            using (var reader = new StringReader(data)) {
                using (var txtReader = new JsonTextReader(reader)) {
                    response = this._serializer.Deserialize<ErrorResponse>(txtReader);
                }
            }

            return response;
        } // end function ParseErrorResponse

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets the <see cref="IConfigurationProvider"/> instance used to load configuration data.
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
