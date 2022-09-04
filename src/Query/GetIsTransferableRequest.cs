namespace SecretNET.SNIP721;

public class GetIsTransferableRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("is_transferable")]
    public GetIsTransferableRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetIsTransferableRequest"/> class.
    /// </summary>
    /// <param name="tokenId">The ID of the token whose transferability is being queried.</param>
    public GetIsTransferableRequest(string tokenId)
    {
        Payload = new GetIsTransferableRequest_Payload
        {
            TokenId = tokenId
        };
    }
}

public class GetIsTransferableRequest_Payload
{
    /// <summary>
    /// The ID of the token whose transferability is being queried (not optional).
    /// </summary>
    /// <value>The token identifier.</value>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

}