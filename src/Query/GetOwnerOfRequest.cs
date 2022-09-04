namespace SecretNET.SNIP721;

public class GetOwnerOfRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("owner_of")]
    public GetOwnerOfRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetOwnerOfRequest" /> class.
    /// </summary>
    /// <param name="tokenId">The ID of the token being queried.</param>
    /// <param name="viewerInfo">The viewer information.</param>
    /// <param name="includeExpired">if set to <c>true</c> [include expired].</param>
    public GetOwnerOfRequest(string tokenId, ViewerInfo viewerInfo = null, bool? includeExpired = null)
    {
        Payload = new GetOwnerOfRequest_Payload
        {
            TokenId = tokenId,
            ViewerInfo = viewerInfo,
            IncludeExpired = includeExpired
        };
    }
}

public class GetOwnerOfRequest_Payload
{
    /// <summary>
    /// The ID of the token being queried (not optional).
    /// </summary>
    /// <value>The token identifier.</value>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// The address and viewing key performing this query.
    /// </summary>
    /// <value>The address.</value>
    [JsonProperty("viewer", NullValueHandling = NullValueHandling.Ignore)]
    public ViewerInfo ViewerInfo { get; set; }

    /// <summary>
    /// True if expired transfer approvals should be included in the response.
    /// </summary>
    /// <value>The include expired.</value>
    [JsonProperty("include_expired")]
    public bool? IncludeExpired { get; set; }
}