namespace SecretNET.SNIP721;

public class GetVerifyTransferApprovalResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("verify_transfer_approval")]
    public GetVerifyTransferApprovalResponse_Result Result { get; set; }

}

public class GetVerifyTransferApprovalResponse_Result
{
    /// <summary>
    /// True if the address has transfer approval on all the token_ids.
    /// </summary>
    /// <value><c>true</c> if [approved for all]; otherwise, <c>false</c>.</value>
    [JsonProperty("approved_for_all")]
    public bool ApprovedForAll { get; set; }

    /// <summary>
    /// The first token in the list that the address does not have approval to transfer.
    /// </summary>
    /// <value>The airst unapproved token.</value>
    [JsonProperty("first_unapproved_token")]
    public string FirstUnapprovedToken { get; set; }

}

