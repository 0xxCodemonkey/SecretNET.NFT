namespace SecretNET.SNIP721;

public class GetImplementsTokenSubtypeResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("implements_token_subtype")]
    public GetImplementsTokenSubtypeResponse_Result Result { get; set; }
}

public class GetImplementsTokenSubtypeResponse_Result
{
    /// <summary>
    /// True if the contract implements token subtypes.
    /// </summary>
    /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
    [JsonProperty("is_enabled")]
    public bool IsEnabled { get; set; }

}
