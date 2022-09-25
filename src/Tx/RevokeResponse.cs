namespace SecretNET.NFT;

public class RevokeResponse
{
    [JsonProperty("revoke")]
    public SimpleStatusResponse_Result Result { get; set; }
}


