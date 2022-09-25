namespace SecretNET.NFT;

public class AddMinterRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("add_minters")]
    public AddMinterRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AddMinterRequest"/> class.
    /// </summary>
    /// <param name="minters">The list of addresses to add to the list of authorized minters.</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    public AddMinterRequest(string[] minters, string? padding = null)
    {
        Payload = new AddMinterRequest_Payload
        {
            Minters = minters,
            Padding = padding
        };
    }

}

public class AddMinterRequest_Payload
{
    /// <summary>
    /// The list of addresses to add to the list of authorized minters (not optional).
    /// </summary>
    [JsonProperty("minters")]
    public string[] Minters { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding")]
    public string Padding { get; set; }
}


