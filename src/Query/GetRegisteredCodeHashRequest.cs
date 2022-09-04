namespace SecretNET.SNIP721;

public class GetRegisteredCodeHashRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("registered_code_hash")]
    public GetRegisteredCodeHashRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetBalanceRequest"/> class.
    /// </summary>
    /// <param name="address">The address.</param>
    /// <param name="viewingKey">The viewing key.</param>
    public GetRegisteredCodeHashRequest(string contractAddress)
    {
        Payload = new GetRegisteredCodeHashRequest_Payload
        {
            ContractAddress = contractAddress
        };
    }
}

public class GetRegisteredCodeHashRequest_Payload
{
    /// <summary>
    /// The address of the contract whose registration info is being queried (not optional).
    /// </summary>
    /// <value>The address.</value>
    [JsonProperty("contract")]
    public string ContractAddress { get; set; }

}