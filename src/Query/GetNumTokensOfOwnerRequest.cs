namespace SecretNET.SNIP721;

public class GetNumTokensOfOwnerRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("tokens")]
    public GetNumTokensOfOwnerRequest_Payload Payload { get; set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="GetNumTokensOfOwnerRequest"/> class.
    /// </summary>
    /// <param name="owner">The address whose inventory is being queried.</param>
    /// <param name="viewer">The querier's address if different from the owner.</param>
    /// <param name="viewingKey">The querier's viewing key.</param>
    public GetNumTokensOfOwnerRequest(string owner, string viewer = null, string viewingKey = null)
    {
        Payload = new GetNumTokensOfOwnerRequest_Payload
        {
            Owner = owner,
            Viewer = viewer,
            ViewingKey = viewingKey
        };
    }
}

public class GetNumTokensOfOwnerRequest_Payload
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

}