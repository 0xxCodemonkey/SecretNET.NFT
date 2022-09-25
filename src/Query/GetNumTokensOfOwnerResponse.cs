namespace SecretNET.NFT;

public class GetNumTokensOfOwnerResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("num_tokens")]
    public GetNumTokensOfOwnerResponse_Result Result { get; set; }

}

public class GetNumTokensOfOwnerResponse_Result
{
    /// <summary>
    /// Gets or sets the count.
    /// </summary>
    /// <value>The count.</value>
    [JsonProperty("count")]
    public uint Count { get; set; }

}

