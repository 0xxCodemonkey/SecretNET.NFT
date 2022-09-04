namespace SecretNET.SNIP721;

public class GetNftInfoRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("nft_info")]
    public GetNftInfoRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetNftInfoRequest"/> class.
    /// </summary>
    /// <param name="tokenId">The ID of the token being queried.</param>
    public GetNftInfoRequest(string tokenId)
    {
        Payload = new GetNftInfoRequest_Payload
        {
            TokenId = tokenId
        };
    }
}

public class GetNftInfoRequest_Payload
{
    /// <summary>
    /// The ID of the token being queried (not optional).
    /// </summary>
    /// <value>The token identifier.</value>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

}