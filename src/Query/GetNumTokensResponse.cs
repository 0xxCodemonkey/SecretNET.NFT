namespace SecretNET.NFT;

public class GetNumTokensResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("num_tokens")]
    public GetNumTokensResponse_Result Result { get; set; }

}

public class GetNumTokensResponse_Result
{
    /// <summary>
    /// Gets or sets the count.
    /// </summary>
    /// <value>The count.</value>
    [JsonProperty("count")]
    public uint Count { get; set; }

}

