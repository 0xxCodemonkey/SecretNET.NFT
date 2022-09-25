namespace SecretNET.NFT;

public class RevokePermitRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("revoke_permit")]
    public RevokePermitRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RevokePermitRequest" /> class.
    /// </summary>
    /// <param name="permitName">Name of the permit that is no longer valid.</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    public RevokePermitRequest(string permitName, string padding = null)
    {
        Payload = new RevokePermitRequest_Payload
        {
            PermitName = permitName,
            Padding = padding
        };
    }
}

public class RevokePermitRequest_Payload
{
    /// <summary>
    /// Name of the permit that is no longer valid (not optional).
    /// </summary>
    [JsonProperty("permit_name")]
    public string PermitName { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


