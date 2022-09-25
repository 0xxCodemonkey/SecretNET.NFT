namespace SecretNET.NFT;

public class GetNumTokensRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("num_tokens")]
    public GetNumTokensRequest_Payload Payload { get; set; }    


    /// <summary>
    /// Initializes a new instance of the <see cref="GetNumTokensRequest"/> class.
    /// </summary>
    /// <param name="address">Address of the querier if supplying optional ViewerInfo.</param>
    /// <param name="viewingKey">Viewer's key if supplying optional ViewerInfo.</param>
    public GetNumTokensRequest(string address = null, string viewingKey = null)
    {
        Payload = new GetNumTokensRequest_Payload();
        if (!string.IsNullOrEmpty(address) || !string.IsNullOrEmpty(viewingKey))
        {
            Payload.ViewerInfo = new ViewerInfo()
            {
                Address = address,
                ViewingKey = viewingKey
            };
        }
    }
}

public class GetNumTokensRequest_Payload
{
    /// <summary>
    /// The address and viewing key performing this query.
    /// </summary>
    /// <value>The address.</value>
    [JsonProperty("viewer", NullValueHandling = NullValueHandling.Ignore)]
    public ViewerInfo ViewerInfo { get; set; }

}

