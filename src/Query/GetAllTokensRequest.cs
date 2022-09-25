namespace SecretNET.NFT;

public class GetAllTokensRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("all_tokens")]
    public GetAllTokensRequest_Payload Payload { get; set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="GetNumTokensRequest" /> class.
    /// </summary>
    /// <param name="address">Address of the querier if supplying optional ViewerInfo.</param>
    /// <param name="viewingKey">Viewer's key if supplying optional ViewerInfo.</param>
    /// <param name="startAfter">Results will only list token IDs that come after this token ID in the list.</param>
    /// <param name="limit">Number of token IDs to return (default 300).</param>
    public GetAllTokensRequest(string address = null, string viewingKey = null, string startAfter = null, int? limit = 300)
    {
        Payload = new GetAllTokensRequest_Payload()
        {
            StartAfter = startAfter,
            Limit = limit
        };

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

public class GetAllTokensRequest_Payload
{
    /// <summary>
    /// The address and viewing key performing this query.
    /// </summary>
    /// <value>The address.</value>
    [JsonProperty("viewer", NullValueHandling = NullValueHandling.Ignore)]
    public ViewerInfo ViewerInfo { get; set; }

    /// <summary>
    /// Results will only list token IDs that come after this token ID in the list.
    /// </summary>
    /// <value>The start after.</value>
    [JsonProperty("start_after")]
    public string StartAfter { get; set; }

    /// <summary>
    /// Number of token IDs to return (default 300).
    /// </summary>
    /// <value>The limit.</value>
    [JsonProperty("limit")]
    public int? Limit { get; set; }

}