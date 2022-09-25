namespace SecretNET.NFT;

public class GetRegisteredCodeHashResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("registered_code_hash")]
    public GetRegisteredCodeHashResponse_Result Result { get; set; }

}

public class GetRegisteredCodeHashResponse_Result
{
    /// <summary>
    /// A 32-byte hex encoded string, with the code hash of the registered contract.
    /// </summary>
    /// <value>The code hash.</value>
    [JsonProperty("code_hash")]
    public string CodeHash { get; set; }

    /// <summary>
    /// True if the registered contract also implements BatchReceiveNft.
    /// </summary>
    /// <value><c>true</c> if [also implements batch receive NFT]; otherwise, <c>false</c>.</value>
    [JsonProperty("also_implements_batch_receive_nft")]
    public bool AlsoImplementsBatchReceiveNft { get; set; }
}

