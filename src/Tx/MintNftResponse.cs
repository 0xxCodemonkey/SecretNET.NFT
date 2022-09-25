namespace SecretNET.NFT;

public class MintNftResponse
{
    [JsonProperty("mint_nft")]
    public MintNftResponse_Result Result { get; set; }
}

public class MintNftResponse_Result
{

    [JsonProperty("token_id")]
    public string TokenId { get; set; }
}


