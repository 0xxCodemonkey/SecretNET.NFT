namespace SecretNET.NFT;

public class GetApprovedForAllResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("approved_for_all")]
    public GetApprovedForAllResponse_Result Result { get; set; }

}

public class GetApprovedForAllResponse_Result
{
    /// <summary>
    /// List of approvals to transfer all of the owner's tokens.
    /// </summary>
    /// <value>The operators.</value>
    [JsonProperty("operators")]
    public Approval[] Operators { get; set; }

}

