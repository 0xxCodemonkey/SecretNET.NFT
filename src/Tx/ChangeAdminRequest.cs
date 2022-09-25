namespace SecretNET.NFT;

public class ChangeAdminRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("change_admin")]
    public ChangeAdminRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChangeAdminRequest" /> class.
    /// </summary>
    /// <param name="address">The address.</param>
    /// <param name="padding">The padding.</param>
    public ChangeAdminRequest(string address, string padding = null)
    {
        Payload = new ChangeAdminRequest_Payload
        {
            Address = address,
            Padding = padding
        };
    }

}

public class ChangeAdminRequest_Payload
{
    /// <summary>
    /// Address of the new contract admin.
    /// </summary>
    [JsonProperty("address")]
    public string Address { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


