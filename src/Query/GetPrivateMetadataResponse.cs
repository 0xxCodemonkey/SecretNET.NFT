namespace SecretNET.NFT;

public class GetPrivateMetadataResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("private_metadata")]
    public GetPrivateMetadataResponse_Result Result { get; set; }

}

public class GetPrivateMetadataResponse_Result
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

