namespace SecretNET.NFT;

public class BatchSendNftRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("batch_send_nft")]
    public BatchSendNftRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BatchSendNftRequest" /> class.
    /// </summary>
    /// <param name="sends">List of Send objects to process.</param>
    /// <param name="padding">The padding.</param>
    public BatchSendNftRequest(BatchSend[] sends, string padding = null)
    {
        Payload = new BatchSendNftRequest_Payload
        {
            Sends = sends,
            Padding = padding
        };
    }
}

public class BatchSendNftRequest_Payload
{
    /// <summary>
    /// List of Transfer objects to process (not optional).
    /// </summary>
    [JsonProperty("sends")]
    public BatchSend[] Sends { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}

public class BatchSend
{
    /// <summary>
    /// Address receiving the token (not optional).
    /// </summary>
    [JsonProperty("contract")]
    public string Contract { get; set; }

    /// <summary>
    /// Identifier of the token to be transferred (not optional).
    /// </summary>
    [JsonProperty("token_ids")]
    public string[] TokenIds { get; set; }

    /// <summary>
    /// Msg (string (base64 encoded Binary)) included when calling the recipient contract's BatchReceiveNft (or ReceiveNft).
    /// </summary>
    [JsonProperty("msg")]
    public object? Msg { get; set; }

    /// <summary>
    /// Memo for the tx that is only viewable by addresses involved (recipient, sender, previous owner).
    /// </summary>
    [JsonProperty("memo")]
    public string? Memo { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding")]
    public string? Padding { get; set; }

    /// <summary>
    /// Code hash and BatchReceiveNft implementation status of the recipient contract.
    /// </summary>
    [JsonProperty("receiver_info")]
    public ReceiverInfo? ReceiverInfo { get; set; }

}

