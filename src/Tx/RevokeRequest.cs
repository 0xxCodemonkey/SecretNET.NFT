namespace SecretNET.NFT;

public class RevokeRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("revoke")]
    public RevokeRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RevokeRequest" /> class.
    /// </summary>
    /// <param name="spender">Address no longer permitted to transfer the token.</param>
    /// <param name="tokenId">ID of the token that the spender can no longer transfer.</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    public RevokeRequest(string spender, string tokenId, object expires = null, string padding = null)
    {
        Payload = new RevokeRequest_Payload
        {
            Spender = spender,
            TokenId = tokenId,
            Padding = padding
        };
    }
}

public class RevokeRequest_Payload
{
    /// <summary>
    /// Address no longer permitted to transfer the token (not optional).
    /// </summary>
    [JsonProperty("spender")]
    public string Spender { get; set; }

    /// <summary>
    /// ID of the token that the spender can no longer transfer (not optional).
    /// </summary>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


