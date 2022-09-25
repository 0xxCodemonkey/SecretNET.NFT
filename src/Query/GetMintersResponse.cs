namespace SecretNET.NFT;

public class GetMintersResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("minters")]
    public GetMintersResponse_Result Result { get; set; }
}

public class GetMintersResponse_Result
{
    /// <summary>
    /// List of addresses of minters.
    /// </summary>
    /// <value>The minters.</value>
    [JsonProperty("minters")]
    public string[] Minters { get; set; }

}
