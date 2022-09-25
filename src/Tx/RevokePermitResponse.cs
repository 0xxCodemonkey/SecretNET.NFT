namespace SecretNET.NFT;

public class RevokePermitResponse
{
    [JsonProperty("revoke_permit")]
    public SimpleStatusResponse_Result Result { get; set; }
}

