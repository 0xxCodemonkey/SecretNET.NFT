namespace SecretNET.SNIP721;

public class RevokePermitResponse
{
    [JsonProperty("revoke_permit")]
    public SimpleStatusResponse_Result Result { get; set; }
}

