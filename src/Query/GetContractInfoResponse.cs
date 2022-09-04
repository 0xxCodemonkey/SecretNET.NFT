namespace SecretNET.SNIP721;

public class GetContractInfoResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("contract_info")]
    public GetContractInfoResponse_Result Result { get; set; }
}

public class GetContractInfoResponse_Result
{
    /// <summary>
    /// The contract name.
    /// </summary>
    /// <value>The name.</value>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// The contract symbol.
    /// </summary>
    /// <value>The symbol.</value>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

}
