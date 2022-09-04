namespace SecretNET.SNIP721;

public class ApproveRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("approve")]
    public ApproveRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApproveRequest" /> class.
    /// </summary>
    /// <param name="spender">Address being granted approval to transfer the token.</param>
    /// <param name="tokenId">ID of the token that the spender can now transfer.</param>
    /// <param name="expires">The expiration of this transfer approval.
    /// Can be a blockheight, time, or never.
    /// Of type =&gt; "never" | {"at_height": 999999} | {"at_time":999999}</param>
    /// <param name="padding">The padding.</param>
    public ApproveRequest(string spender, string tokenId, object expires = null, string padding = null)
    {
        Payload = new ApproveRequest_Payload
        {
            Spender = spender,
            TokenId = tokenId,
            Expires = expires,
            Padding = padding
        };
    }
}

public class ApproveRequest_Payload
{
    /// <summary>
    /// Address being granted approval to transfer the token (not optional).
    /// </summary>
    [JsonProperty("spender")]
    public string Spender { get; set; }

    /// <summary>
    /// ID of the token that the spender can now transfer (not optional).
    /// </summary>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// The expiration of this token transfer approval.
    /// Can be a blockheight, time, or never.
    /// Of type => "never" | {"at_height": 999999} | {"at_time":999999}
    /// </summary>
    [JsonProperty("expires", NullValueHandling = NullValueHandling.Ignore)]
    public object Expires { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


