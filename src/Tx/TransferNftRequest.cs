namespace SecretNET.SNIP721;

public class TransferNftRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("transfer_nft")]
    public TransferNftRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TransferNftRequest" /> class.
    /// </summary>
    /// <param name="recipient">Address receiving the token.</param>
    /// <param name="tokenId">ID of the token to be transferred.</param>
    /// <param name="memo">Memo for the transfer transaction that is only viewable by addresses involved in the transfer (recipient, sender, previous owner).</param>
    /// <param name="padding">The padding.</param>
    public TransferNftRequest(string recipient, string tokenId, string memo = null, string padding = null)
    {
        Payload = new TransferNftRequest_Payload
        {
            Recipient = recipient,
            TokenId = tokenId,
            Memo = memo,
            Padding = padding
        };
    }
}

public class TransferNftRequest_Payload
{
    /// <summary>
    /// Address receiving the token (not optional).
    /// </summary>
    [JsonProperty("recipient")]
    public string Recipient { get; set; }

    /// <summary>
    /// ID of the token to be transferred (not optional).
    /// </summary>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// Memo for the transfer transaction that is only viewable by addresses involved in the transfer (recipient, sender, previous owner).
    /// </summary>
    [JsonProperty("memo")]
    public string Memo { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


