namespace SecretNET.NFT;

public class RevokeAllRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("revoke_all")]
    public RevokeAllRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RevokeAllRequest" /> class.
    /// </summary>
    /// <param name="tokenOperator">Address being revoked all approvals to transfer the message sender's tokens.</param>
    /// <param name="padding">The padding.</param>
    public RevokeAllRequest(string tokenOperator, string padding = null)
    {
        Payload = new RevokeAllRequest_Payload
        {
            Operator = tokenOperator,
            Padding = padding
        };
    }
}

public class RevokeAllRequest_Payload
{
    /// <summary>
    /// Address being revoked all approvals to transfer the message sender's tokens (not optional).
    /// </summary>
    [JsonProperty("operator")]
    public string Operator { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


