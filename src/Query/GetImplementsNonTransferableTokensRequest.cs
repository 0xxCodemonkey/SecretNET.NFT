namespace SecretNET.SNIP721;

public class GetImplementsNonTransferableTokensRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("implements_non_transferable_tokens")]
    public object Payload { get; set; } = new object();
}


