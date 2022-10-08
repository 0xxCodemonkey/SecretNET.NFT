namespace SecretNET.NFT;

/// <summary>
/// Class SendNftRequest.
/// </summary>
public class SendNftRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("send_nft")]
    public SendNftRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SendNftRequest"/> class.
    /// </summary>
    /// <param name="contract">Address receiving the token (not optional).</param>
    /// <param name="tokenId">Identifier of the token to be transferred (not optional).</param>
    /// <param name="Msg">Msg (string (base64 encoded Binary)) included when calling the recipient contract's BatchReceiveNft (or ReceiveNft).</param>
    /// <param name="receiverInfo">Code hash and BatchReceiveNft implementation status of the recipient contract.</param>
    /// <param name="memo">Memo for the tx that is only viewable by addresses involved (recipient, sender, previous owner).</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    public SendNftRequest(string contract, string tokenId, object Msg = null, ReceiverInfo receiverInfo = null, string memo = null, string padding = null)
    {
        Payload = new SendNftRequest_Payload
        {
            Contract = contract,
            TokenId = tokenId,
            Msg = Msg,
            Memo = memo,
            ReceiverInfo = receiverInfo,
            Padding = padding
        };
    }

}

/// <summary>
/// Class SendNftRequest_Payload.
/// </summary>
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




