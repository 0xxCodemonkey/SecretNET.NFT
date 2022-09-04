namespace SecretNET.SNIP721;

public class GetTokenApprovalsRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("token_approvals")]
    public GetTokenApprovalsRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetTokenApprovalsRequest" /> class.
    /// </summary>
    /// <param name="tokenId">The ID of the token being queried.</param>
    /// <param name="viewingKey">The token owner's viewing key.</param>
    /// <param name="includeExpired">if set to <c>true</c> [include expired].</param>
    public GetTokenApprovalsRequest(string tokenId, string viewingKey, bool? includeExpired = null)
    {
        Payload = new GetTokenApprovalsRequest_Payload
        {
            TokenId = tokenId,
            ViewingKey = viewingKey,
            IncludeExpired = includeExpired
        };
    }
}

public class GetTokenApprovalsRequest_Payload
{
    /// <summary>
    /// The ID of the token being queried (not optional).
    /// </summary>
    /// <value>The token identifier.</value>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// The token owner's viewing key (not optional).
    /// </summary>
    /// <value>The viewing key.</value>
    [JsonProperty("viewing_key", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewingKey { get; set; }

    /// <summary>
    /// True if expired transfer approvals should be included in the response.
    /// </summary>
    /// <value>The include expired.</value>
    [JsonProperty("include_expired")]
    public bool? IncludeExpired { get; set; }

}