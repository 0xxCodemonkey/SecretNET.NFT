namespace SecretNET.SNIP721;

public class GetImplementsNonTransferableTokensResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("implements_non_transferable_tokens")]
    public GetImplementsNonTransferableTokensResponse_Result Result { get; set; }
}

public class GetImplementsNonTransferableTokensResponse_Result
{
    /// <summary>
    /// True if the contract implements non-transferable tokens.
    /// </summary>
    /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
    [JsonProperty("is_enabled")]
    public bool IsEnabled { get; set; }

}
