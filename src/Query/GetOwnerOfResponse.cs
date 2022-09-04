namespace SecretNET.SNIP721;

public class GetOwnerOfResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("owner_of")]
    public GetOwnerOfResponse_Result Result { get; set; }

}

public class GetOwnerOfResponse_Result
{
    /// <summary>
    /// Address of the token's owner.
    /// </summary>
    /// <value><c>true</c> if owner; otherwise, <c>false</c>.</value>
    [JsonProperty("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// List of approvals to transfer this token.
    /// </summary>
    /// <value>The approvals.</value>
    [JsonProperty("approvals")]
    public Approval[] Approvals { get; set; }

}

