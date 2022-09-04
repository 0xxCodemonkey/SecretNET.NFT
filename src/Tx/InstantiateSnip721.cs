namespace SecretNET.SNIP721;

public class InstantiateSnip721
{
    /// <summary>
    /// Name of the token contract (not optional).
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Token contract symbol (not optional).
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Address to be given admin authority.
    /// Value If Omitted: env.message.sender
    /// </summary>
    [JsonProperty("admin")]
    public string Admin { get; set; }

    /// <summary>
    /// String used as entropy when generating random viewing keys (not optional).
    /// </summary>
    [JsonProperty("entropy")]
    public string Entropy { get; set; }

    /// <summary>
    /// Default RoyaltyInfo for the contract
    /// </summary>
    [JsonProperty("royalty_info")]
    public RoyaltyInfo? RoyaltyInfo { get; set; }

    /// <summary>
    /// Privacy configuration for the contract.
    /// Value If Omitted: see defaults on Config => https://github.com/baedrik/snip721-reference-impl#config
    /// </summary>
    [JsonProperty("config")]
    public ConfigSettings? Config { get; set; }

    /// <summary>
    /// Information used to perform a callback message after initialization.
    /// The PostInitCallback object is used to have the token contract execute an optional callback message after the contract has initialized. 
    /// This can be useful if another contract is instantiating this token contract and needs the token contract to inform the creating contract of the address it has been given.
    /// </summary>
    [JsonProperty("post_init_callback")]
    public PostInitCallback? PostInitCallback { get; set; }
}

public class ConfigSettings
{
    /// <summary>
    /// This config value indicates whether the token IDs and the number of tokens controlled by the contract are public. 
    /// If the token supply is private, only minters can view the token IDs and number of tokens controlled by the contract 
    /// (default: False)
    /// </summary>
    [JsonProperty("public_token_supply")]
    public bool PublicTokenSupply { get; set; }

    /// <summary>
    /// This config value indicates whether token ownership is public or private by default. 
    /// Regardless of this setting a user has the ability to change whether the ownership of their tokens is public or private 
    /// (default: False)
    /// </summary>
    [JsonProperty("public_owner")]
    public bool PublicOwner { get; set; }

    /// <summary>
    /// This config value indicates whether sealed metadata should be enabled. 
    /// If sealed metadata is enabled, the private metadata of a newly minted token is not viewable by anyone, not even the owner, 
    /// until the owner calls the Reveal message. When Reveal is called, the sealed metadata is irreversibly unwrapped and moved to the public metadata (as default). 
    /// If unwrapped_metadata_is_private is set to true, the sealed metadata will remain as private metadata after unwrapping, 
    /// but the owner (and anyone the owner has whitelisted) will now be able to see it. Anyone will be able to query the token to know whether it has been unwrapped. 
    /// This simulates buying/selling a wrapped card that no one knows which card it is until it is unwrapped. 
    /// If sealed metadata is not enabled, all tokens are considered unwrapped when minted 
    /// (default: False)
    /// </summary>
    [JsonProperty("enable_sealed_metadata")]
    public bool EnableSealedMetadata { get; set; }

    /// <summary>
    /// This config value indicates if the Reveal message should keep the sealed metadata private after unwrapping. 
    /// This config value is ignored if sealed metadata is not enabled 
    /// (default: False)
    /// </summary>
    [JsonProperty("unwrapped_metadata_is_private")]
    public bool UnwrappedMetadataIsPrivate { get; set; }

    /// <summary>
    /// This config value indicates whether a minter is permitted to update a token's metadata 
    /// (default: True)
    /// </summary>
    [JsonProperty("minter_may_update_metadata")]
    public bool MinterMayUpdateMetadata { get; set; } = true;

    /// <summary>
    /// This config value indicates whether the owner of a token is permitted to update a token's metadata 
    /// (default: False)
    /// </summary>
    [JsonProperty("owner_may_update_metadata")]
    public bool OwnerMayUpdateMetadata { get; set; }

    /// <summary>
    /// This config value indicates whether burn functionality is enabled. 
    /// SNIP-722 non-transferable tokens can always be burned even when burning is disabled. 
    /// This is because an owner must have a way to dispose of an unwanted, non-transferable token 
    /// (default: False)
    /// </summary>
    [JsonProperty("enable_burn")]
    public bool EnableBurn { get; set; }
}

public class PostInitCallback
{
    /// <summary>
    /// Base64 encoded Binary representation of the callback message to perform after contract initialization (not optional).
    /// </summary>
    [JsonProperty("msg")]
    public string Msg { get; set; }

    /// <summary>
    /// Address of the contract to call after initialization (not optional).
    /// </summary>
    [JsonProperty("contract_address")]
    public string ContractAddress { get; set; }

    /// <summary>
    /// A 32-byte hex encoded string, with the code hash of the contract to call after initialization (not optional).
    /// </summary>
    [JsonProperty("code_hash")]
    public string CodeHash { get; set; }

    /// <summary>
    /// List of native Coin amounts to send with the callback message (not optional => use empty array if nothing to send).
    /// Coin is the payment to send with the post-init callback message. Although send is not an optional field of the PostInitCallback, because it is an array, 
    /// you can just use [] to not send any payment with the callback message
    /// </summary>
    [JsonProperty("send")]
    public SecretNET.Tx.Coin[] Send { get; set; } = new SecretNET.Tx.Coin[0];
}
