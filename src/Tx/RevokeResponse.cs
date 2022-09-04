namespace SecretNET.SNIP721;

public class RevokeResponse
{
    [JsonProperty("revoke")]
    public SimpleStatusResponse_Result Result { get; set; }
}


