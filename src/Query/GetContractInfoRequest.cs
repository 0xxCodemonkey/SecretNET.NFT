namespace SecretNET.SNIP721;

public class GetContractInfoRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("contract_info")]
    public object Payload { get; set; } = new object();
}


