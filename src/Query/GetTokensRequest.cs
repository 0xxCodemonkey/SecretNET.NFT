namespace SecretNET.SNIP721;

public class GetTokensRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("tokens")]
    public GetTokensRequest_Payload Payload { get; set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="GetTokensRequest"/> class.
    /// </summary>
    /// <param name="owner">The address whose inventory is being queried.</param>
    /// <param name="viewer">The querier's address if different from the owner.</param>
    /// <param name="viewingKey">The querier's viewing key.</param>
    /// <param name="startAfter">Results will only list token IDs that come after this token ID in the list.</param>
    /// <param name="limit">Number of token IDs to return.</param>
    public GetTokensRequest(string owner, string viewer = null, string viewingKey = null, string startAfter = null, int? limit = null)
    {
        Payload = new GetTokensRequest_Payload
        {
            Owner = owner,
            Viewer = viewer,
            ViewingKey = viewingKey,
            StartAfter = startAfter,
            Limit = limit
        };
    }
}

public class GetTokensRequest_Payload
{
    /// <summary>
    /// The address whose inventory is being queried (not optional).
    /// </summary>
    /// <value>The owner.</value>
    [JsonProperty("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// The querier's address if different from the owner.
    /// </summary>
    /// <value>The viewer.</value>
    [JsonProperty("viewer", NullValueHandling = NullValueHandling.Ignore)]
    public string Viewer { get; set; }

    /// <summary>
    /// The token owner's viewing key.
    /// </summary>
    /// <value>The viewing key.</value>
    [JsonProperty("viewing_key", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewingKey { get; set; }

    /// <summary>
    /// Results will only list token IDs that come after this token ID in the list.
    /// </summary>
    /// <value>The start after.</value>
    [JsonProperty("start_after")]
    public string StartAfter { get; set; }

    /// <summary>
    /// True if expired transfer approvals should be included in the response.
    /// </summary>
    /// <value>The include expired.</value>
    [JsonProperty("limit")]
    public int? Limit { get; set; }

}