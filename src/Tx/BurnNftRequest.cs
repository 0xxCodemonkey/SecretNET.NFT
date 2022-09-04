namespace SecretNET.SNIP721;

public class BurnNftRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("burn_nft")]
    public BurnNftRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BurnNftRequest" /> class.
    /// </summary>
    /// <param name="tokenId">ID of the token to burn.</param>
    /// <param name="memo">Memo for the burn tx that is only viewable by addresses involved in the burn (message sender and previous owner if different).</param>
    /// <param name="padding">The padding.</param>
    public BurnNftRequest(string tokenId, string memo = null, string padding = null)
    {
        Payload = new BurnNftRequest_Payload
        {
            TokenId = tokenId,
            Memo = memo,
            Padding = padding
        };
    }
}

public class BurnNftRequest_Payload
{
    /// <summary>
    /// ID of the token to burn (not optional).
    /// </summary>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// Memo for the burn tx that is only viewable by addresses involved in the burn (message sender and previous owner if different).
    /// </summary>
    [JsonProperty("memo")]
    public string Memo { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


