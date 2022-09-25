namespace SecretNET.NFT;

public class BatchTransferNftRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("batch_transfer_nft")]
    public BatchTransferNftRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BatchTransferNftRequest" /> class.
    /// </summary>
    /// <param name="transfers">List of Transfer objects to process.</param>
    /// <param name="padding">The padding.</param>
    public BatchTransferNftRequest(BatchTransfer[] transfers, string padding = null)
    {
        Payload = new BatchTransferNftRequest_Payload
        {
            Transfers = transfers,
            Padding = padding
        };
    }
}

public class BatchTransferNftRequest_Payload
{
    /// <summary>
    /// List of Transfer objects to process (not optional).
    /// </summary>
    [JsonProperty("transfers")]
    public BatchTransfer[] Transfers { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}

public class BatchTransfer
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
    public string[] TokenIds { get; set; }

    /// <summary>
    /// Memo for the transfer transaction that is only viewable by addresses involved in the transfer (recipient, sender, previous owner).
    /// </summary>
    [JsonProperty("memo")]
    public string Memo { get; set; }

}

