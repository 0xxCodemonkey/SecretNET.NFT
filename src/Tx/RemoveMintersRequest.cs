namespace SecretNET.SNIP721;

public class RemoveMintersRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("remove_minters")]
    public RemoveMintersRequest_Payload Payload { get; set; }

}

public class RemoveMintersRequest_Payload
{
    /// <summary>
    /// The list of addresses to remove from the list of authorized minters (not optional).
    /// </summary>
    [JsonProperty("minters")]
    public string[] Minters { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding")]
    public string Padding { get; set; }
}


