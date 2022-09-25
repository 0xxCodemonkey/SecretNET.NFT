namespace SecretNET.NFT;

public class SetContractStatusRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("set_contract_status")]
    public SetContractStatusRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetContractStatusRequest" /> class.
    /// </summary>
    /// <param name="level">The level that defines which messages the contract will execute.</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    public SetContractStatusRequest(ContractStatus level, string? padding = null)
    {
        Payload = new SetContractStatusRequest_Payload
        {
            Level = level,
            Padding = padding
        };
    }
}

public class SetContractStatusRequest_Payload
{
    /// <summary>
    /// The list of addresses to are allowed to mint (not optional).
    /// </summary>
    [JsonProperty("level")]
    public ContractStatus Level { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}


