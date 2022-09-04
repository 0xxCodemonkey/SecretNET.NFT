namespace SecretNET.SNIP721;

public class RevealRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("reveal")]
    public RevealRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RevealRequest" /> class.
    /// </summary>
    /// <param name="tokenId">ID of the token to unwrap.</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    public RevealRequest(string tokenId, string padding = null)
    {
        Payload = new RevealRequest_Payload
        {
            TokenId = tokenId,
            Padding = padding
        };
    }

}

public class RevealRequest_Payload
{
    /// <summary>
    /// ID of the token to unwrap.
    /// </summary>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


