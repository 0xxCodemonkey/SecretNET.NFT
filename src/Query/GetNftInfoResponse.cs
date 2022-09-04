namespace SecretNET.SNIP721;

public class GetNftInfoResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("nft_info")]
    public GetNftInfoResponse_Result Result { get; set; }

}

public class GetNftInfoResponse_Result
{
    /// <summary>
    /// Uri pointing to off-chain JSON metadata (optional) - extension should be set if empty.
    /// </summary>
    /// <value>The token URI.</value>
    [JsonProperty("token_uri")]
    public string? TokenUri { get; set; }

    /// <summary>
    /// Data structure defining on-chain metadata.
    /// </summary>
    /// <value>The extension.</value>
    [JsonProperty("extension")]
    public Extension Extension { get; set; }

}

