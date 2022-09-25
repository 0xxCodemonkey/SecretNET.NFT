namespace SecretNET.NFT;

public class GetContractConfigRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("contract_config")]
    public object Payload { get; set; } = new object();
}


