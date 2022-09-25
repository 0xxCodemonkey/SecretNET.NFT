namespace SecretNET.NFT;

public class MakeOwnershipPrivateRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("reveal")]
    public MakeOwnershipPrivateRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RevealRequest" /> class.
    /// </summary>
    /// <param name="padding">The padding.</param>
    public MakeOwnershipPrivateRequest(string padding = null)
    {
        Payload = new MakeOwnershipPrivateRequest_Payload
        {
            Padding = padding
        };
    }

}

public class MakeOwnershipPrivateRequest_Payload
{
    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


