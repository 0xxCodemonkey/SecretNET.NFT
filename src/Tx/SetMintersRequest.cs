namespace SecretNET.SNIP721;

public class SetMintersRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("set_minters")]
    public SetMintersRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetMintersRequest"/> class.
    /// </summary>
    /// <param name="minters">The list of addresses to are allowed to mint.</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    public SetMintersRequest(string[] minters, string? padding = null)
    {
        Payload = new SetMintersRequest_Payload
        {
            Minters = minters,
            Padding = padding
        };
    }
}

public class SetMintersRequest_Payload
{
    /// <summary>
    /// The list of addresses to are allowed to mint (not optional).
    /// </summary>
    [JsonProperty("minters")]
    public string[] Minters { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}


