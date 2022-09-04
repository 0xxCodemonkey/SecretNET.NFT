namespace SecretNET.SNIP721;

public class SendNftRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("send_nft")]
    public SendNftRequest_Payload Payload { get; set; }

}

public class SendNftRequest_Payload
{
    /// <summary>
    /// Address receiving the token (not optional).
    /// </summary>
    [JsonProperty("contract")]
    public string Contract { get; set; }

    /// <summary>
    /// Identifier of the token to be transferred (not optional).
    /// </summary>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

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




