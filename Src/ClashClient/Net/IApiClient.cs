namespace ClashClient.Net {
    /// <summary>
    /// Interface that exposes a contract for a client that can consume the clash-of-clans API.
    /// </summary>
    public interface IApiClient {
        #region --Functions--

        /// <summary>
        /// Returns the data from making a call to the clash-of-clans API.
        /// </summary>
        /// <typeparam name="TResponse">The type of response object expected back from the API.</typeparam>
        /// <param name="apiRequest">The <see cref="ApiRequest"/> that contains the data used to customize the API call.</param>
        /// <returns>A new <see cref="ApiResponse"/> instance with the results of the API call.</returns>
        ApiResponse<TResponse> Load<TResponse>(ApiRequest apiRequest) where TResponse : class;

        #endregion
    } // end interface IApiClient
} // end namespace
