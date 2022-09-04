namespace SecretNET.SNIP721;

public class BatchMintNftResponse
{
    [JsonProperty("batch_mint_nft")]
    public BatchMintNftResponse_Result Result { get; set; }
}

public class BatchMintNftResponse_Result
{

    [JsonProperty("token_ids")]
    public string[] TokenIds { get; set; }
}


