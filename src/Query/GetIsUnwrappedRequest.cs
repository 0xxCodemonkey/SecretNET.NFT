namespace SecretNET.NFT;

public class GetIsUnwrappedRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("is_unwrapped")]
    public GetIsUnwrappedRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetIsUnwrappedRequest"/> class.
    /// </summary>
    /// <param name="tokenId">The ID of the token whose unwrapped status is being queried.</param>
    public GetIsUnwrappedRequest(string tokenId)
    {
        Payload = new GetIsUnwrappedRequest_Payload
        {
            TokenId = tokenId
        };
    }
}

public class GetIsUnwrappedRequest_Payload
{
    /// <summary>
    /// The ID of the token whose unwrapped status is being queried (not optional).
    /// </summary>
    /// <value>The token identifier.</value>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

}