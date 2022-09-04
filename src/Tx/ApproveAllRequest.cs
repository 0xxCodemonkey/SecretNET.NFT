namespace SecretNET.SNIP721;

public class ApproveAllRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("approve_all")]
    public ApproveAllRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApproveAllRequest" /> class.
    /// </summary>
    /// <param name="tokenOperator">Address being granted approval to transfer all of the message sender's tokens.</param>
    /// <param name="expires">The expiration of this inventory-wide transfer approval.
    /// Can be a blockheight, time, or never.
    /// Of type =&gt; "never" | {"at_height": 999999} | {"at_time":999999}</param>
    /// <param name="padding">The padding.</param>
    public ApproveAllRequest(string tokenOperator, object expires = null, string padding = null)
    {
        Payload = new ApproveAllRequest_Payload
        {
            Operator = tokenOperator,
            Expires = expires,
            Padding = padding
        };
    }
}

public class ApproveAllRequest_Payload
{
    /// <summary>
    /// Address being granted approval to transfer the token (not optional).
    /// </summary>
    [JsonProperty("operator")]
    public string Operator { get; set; }

    /// <summary>
    /// The expiration of this inventory-wide transfer approval.
    /// Can be a blockheight, time, or never.
    /// Of type => "never" | {"at_height": 999999} | {"at_time":999999}
    /// </summary>
    [JsonProperty("expires", NullValueHandling = NullValueHandling.Ignore)]
    public object Expires { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


