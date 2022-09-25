namespace SecretNET.NFT;

public class SimpleStatusResponse_Result
{
    [JsonProperty("status")]
    public string Status { get; set; }
}
public class Mint
{
    /// <summary>
    /// Identifier for the token to be minted.
    /// Value If Omitted: minting order number
    /// </summary>
    [JsonProperty("token_id")]
    public string? TokenId { get; set; }

    /// <summary>
    /// Address of the owner of the minted token.
    /// Value If Omitted: env.message.sender
    /// </summary>
    [JsonProperty("owner")]
    public string? Owner { get; set; }

    /// <summary>
    /// The metadata that is publicly viewable.
    /// </summary>
    [JsonProperty("public_metadata")]
    public Metadata? PublicMetadata { get; set; }

    /// <summary>
    /// The metadata that is viewable only by the token owner and addresses the owner has whitelisted.
    /// </summary>
    [JsonProperty("private_metadata")]
    public Metadata? PrivateMetadata { get; set; }

    /// <summary>
    /// The SerialNumber for this token.
    /// </summary>
    [JsonProperty("serial_number")]
    public SerialNumberType? SerialNumber { get; set; }

    /// <summary>
    /// Memo for the mint tx that is only viewable by addresses involved in the mint (minter, owner).
    /// </summary>
    [JsonProperty("memo")]
    public string? Memo { get; set; }

    /// <summary>
    /// RoyaltyInfo for this token
    /// Value If Omitted: default RoyaltyInfo
    /// 
    /// Setting royalties for a non-transferable token has no purpose, because it can never be transferred as part of a sale, 
    /// so this implementation will not store any RoyaltyInfo for non-transferable tokens.
    /// </summary>
    [JsonProperty("royalty_info")]
    public RoyaltyInfo? RoyaltyInfo { get; set; }

    /// <summary>
    /// True if the minted token should be transferable (default: true).
    /// </summary>
    [JsonProperty("transferable")]
    public bool? Transferable { get; set; } = true;

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}

public class ViewerInfo
{
    /// <summary>
    /// The querying address' viewing key (not optional).
    /// </summary>
    [JsonProperty("viewing_key")]
    public string ViewingKey { get; set; }

    /// <summary>
    /// Address performing the query.
    /// </summary>
    [JsonProperty("address")]
    public string Address { get; set; }
}

public class Trait
{
    /// <summary>
    /// Indicates how a trait should be displayed.
    /// </summary>
    [JsonProperty("display_type")]
    public string? DisplayType { get; set; }

    /// <summary>
    /// Name of the trait.
    /// </summary>
    [JsonProperty("trait_type")]
    public string? TraitType { get; set; }

    /// <summary>
    /// Trait value (not optional).
    /// </summary>
    [JsonProperty("value")]
    public string Value { get; set; }

    /// <summary>
    /// Optional max value for numerical traits.
    /// </summary>
    [JsonProperty("max_value")]
    public string? MaxValue { get; set; }
}

public class Authentication
{
    /// <summary>
    /// Either a decryption key for encrypted files or a password for basic authentication.
    /// </summary>
    [JsonProperty("key")]
    public string? key { get; set; }

    /// <summary>
    /// Username used in basic authentication.
    /// </summary>
    [JsonProperty("user")]
    public string? User { get; set; }
}

public class MediaFile
{
    /// <summary>
    /// Stashh currently uses: "image", "video", "audio", "text", "font", "application".
    /// </summary>
    [JsonProperty("file_type")]
    public string? FileType { get; set; }

    /// <summary>
    /// File extension.
    /// </summary>
    [JsonProperty("extension")]
    public string? Extension { get; set; }

    /// <summary>
    /// Credentials or decryption key for a protected file.
    /// </summary>
    [JsonProperty("authentication")]
    public Authentication? Authentication { get; set; }

    /// <summary>
    /// Url to the file.  Urls should be prefixed with `http://`, `https://`, `ipfs://`, or `ar://` (not optional).
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }
}

public class Extension
{
    /// <summary>
    /// Url to the token's image
    /// </summary>
    [JsonProperty("image")]
    public string? Image { get; set; }

    /// <summary>
    /// Raw SVG image data (not recommended). Only use this if you're not including the image parameter.
    /// </summary>
    [JsonProperty("image_data")]
    public string? ImageData { get; set; }

    /// <summary>
    /// Url to allow users to view the item on your site.
    /// </summary>
    [JsonProperty("external_url")]
    public string? ExternalUrl { get; set; }

    /// <summary>
    /// Item description.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Name of the item.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Item attributes
    /// </summary>
    [JsonProperty("attributes")]
    public Trait[]? Attributes { get; set; }

    /// <summary>
    /// Background color represented as a six-character hexadecimal without a pre-pended #.
    /// </summary>
    [JsonProperty("background_color")]
    public string? BackgroundColor { get; set; }

    /// <summary>
    /// Url to a multimedia file.
    /// </summary>
    [JsonProperty("animation_url")]
    public string? AnimationUrl { get; set; }

    /// <summary>
    /// Url to a YouTube video.
    /// </summary>
    [JsonProperty("youtube_url")]
    public string? YouTubeUrl { get; set; }

    /// <summary>
    /// Media files as specified on Stashh that allows for basic authenticatiion and decryption keys.
    /// Most of the above is used for bridging lic eth NFT metadata easily, whereas `media` will be used
    /// when minting NFTs on Stashh.
    /// </summary>
    [JsonProperty("media")]
    public MediaFile[]? Media { get; set; }

    /// <summary>
    /// A select list of trait_types that are in the private metadata.  This will only ever be used in lic metadata.
    /// </summary>
    [JsonProperty("protected_attributes")]
    public string[]? ProtectedAttributes { get; set; }

    /// <summary>
    /// Token subtype used to signify what the NFT is used for, such as "badge".
    /// </summary>
    [JsonProperty("token_subtype")]
    public string? TokenSubtype { get; set; }
}

public class Metadata
{
    /// <summary>
    /// Optional uri for off-chain metadata.  This should be prefixed with `http://`, `https://`, `ipfs://`, or `ar://`. 
    /// Only use this if you are not using `extension`Credentials or decryption key for a protected file
    /// </summary>
    [JsonProperty("token_uri")]
    public string? TokenUri { get; set; }

    /// <summary>
    /// Optional on-chain metadata.  Only use this if you are not using `token_uri`.
    /// </summary>
    [JsonProperty("extension")]
    public Extension? Extension { get; set; }
}

public class RoyaltyInfo
{
    /// <summary>
    /// The number of decimal places used for all rates in royalties (e.g. 2 decimals for whole percents) (not optional).
    /// </summary>
    [JsonProperty("decimal_places_in_rates")]
    public string DecimalPlacesInRates { get; set; }

    /// <summary>
    /// List of royalties to be paid upon sale (not optional).
    /// </summary>
    [JsonProperty("royalties")]
    public Royalty[] Royalties { get; set; }
}

public class Royalty
{
    /// <summary>
    /// The address that should be paid this royalty (not optional).
    /// </summary>
    [JsonProperty("recipient")]
    public string Recipient { get; set; }

    /// <summary>
    /// The royalty rate to be paid using the number of decimals specified in the RoyaltyInfo containing this Royalty (not optional).
    /// </summary>
    [JsonProperty("rate")]
    public ushort Rate { get; set; }
}

public class SerialNumberType
{
    /// <summary>
    /// The serial number of this token (not optional).
    /// </summary>
    [JsonProperty("serial_number")]
    public uint? SerialNumber { get; set; }

    /// <summary>
    /// The mint run this token was minted in. This represents batches of NFTs released at the same time.
    /// </summary>
    [JsonProperty("mint_run")]
    public uint? MintRun { get; set; }

    /// <summary>
    /// The number of tokens minted in this mint run.
    /// </summary>
    [JsonProperty("quantity_minted_this_run")]
    public uint? QuantityMintedThisRun { get; set; }
}

public class Approval
{
    /// <summary>
    /// Address whitelisted to transfer a token.
    /// </summary>
    [JsonProperty("spender")]
    public string Spender { get; set; }

    /// <summary>
    /// The expiration of this transfer approval. 
    /// Can be a blockheight, time, or never.
    /// Of type => "never" | {"at_height": 999999} | {"at_time":999999}
    /// </summary>
    [JsonProperty("expires")]
    public object Expires { get; set; }
}

public class MintRunInfo
{
    /// <summary>
    /// The address that instantiated this contract.
    /// </summary>
    /// <value>The collection creator.</value>
    [JsonProperty("collection_creator")]
    public string CollectionCreator { get; set; }

    /// <summary>
    /// The address that minted this token.
    /// </summary>
    /// <value>The token creator.</value>
    [JsonProperty("token_creator")]
    public string TokenCreator { get; set; }

    /// <summary>
    /// The number of seconds since 01/01/1970 that this token was minted.
    /// </summary>
    /// <value>The time of minting.</value>
    [JsonProperty("time_of_minting")]
    public ulong TimeOfMinting { get; set; }

    /// <summary>
    /// The mint run this token was minted in. This represents batches of NFTs released at the same time.
    /// </summary>
    /// <value>The mint run.</value>
    [JsonProperty("mint_run")]
    public uint MintRun { get; set; }

    /// <summary>
    /// The serial number of this token.
    /// </summary>
    /// <value>The serial number.</value>
    [JsonProperty("serial_number")]
    public uint SerialNumber { get; set; }

    /// <summary>
    /// The number of tokens minted in this mint run.
    /// </summary>
    /// <value>The quantity minted this run.</value>
    [JsonProperty("quantity_minted_this_run")]
    public uint QuantityMintedThisRun { get; set; }
}

public class Snip721Approval
{
    /// <summary>
    /// The whitelisted address.
    /// </summary>
    [JsonProperty("address")]
    public string Address { get; set; }

    /// <summary>
    /// The expiration for view_owner permission. 
    /// Can be a blockheight, time, or never.
    /// Of type => "never" | {"at_height": 999999} | {"at_time":999999}
    /// </summary>
    [JsonProperty("view_owner_expiration")]
    public object ViewOwnerExpiration { get; set; }

    /// <summary>
    /// The expiration for view__private_metadata permission. 
    /// Can be a blockheight, time, or never.
    /// Of type => "never" | {"at_height": 999999} | {"at_time":999999}
    /// </summary>
    [JsonProperty("view_private_metadata_expiration")]
    public object ViewPrivateMetadataExpiration { get; set; }

    /// <summary>
    /// The expiration for transfer permission. 
    /// Can be a blockheight, time, or never.
    /// Of type => "never" | {"at_height": 999999} | {"at_time":999999}
    /// </summary>
    [JsonProperty("transfer_expiration")]
    public object TransferExpiration { get; set; }
}

public class Tx
{
    [JsonProperty("tx_id")]
    public ulong TxId { get; set; }

    [JsonProperty("block_height")]
    public ulong BlockHeight { get; set; }

    [JsonProperty("block_time")]
    public ulong BlockTime { get; set; }

    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    [JsonProperty("action")]
    public TxAction Action { get; set; }

    [JsonProperty("memo")]
    public string Memo { get; set; }
}

public class TxAction
{
    /// <summary>
    /// The address that minted the token.
    /// </summary>
    /// <value>The minter.</value>
    [JsonProperty("minter")]
    public string Minter { get; set; }

    /// <summary>
    /// The address of the newly minted token's owner.
    /// </summary>
    /// <value>The recipient.</value>
    [JsonProperty("recipient")]
    public string Recipient { get; set; }
}

/// <summary>
/// AccessLevel determines the type of access being granted or revoked to the specified address.
/// </summary>
public enum AccessLevel
{
    /// <summary>
    /// Revoke any approval (both token and inventory-wide) previously granted to the specified address (or for everyone if using SetGlobalApproval).
    /// </summary>
    none = 0,

    /// <summary>
    /// Grant approval only on the token specified in the message.
    /// </summary>
    approve_token = 1,

    /// <summary>
    /// Revoke a previous approval on the specified token.
    /// </summary>
    revoke_token = 2,

    /// <summary>
    /// Grant approval for all tokens in the message signer's inventory. 
    /// This approval will also apply to any tokens the signer acquires after granting all approval.
    /// </summary>
    all = 3
}

/// <summary>
/// ContractStatus indicates which messages the contract will execute.
/// </summary>
public enum ContractStatus
{
    /// <summary>
    /// The contract will execute all messages.
    /// </summary>
    normal = 0,

    /// <summary>
    /// The contract will not allow any minting, burning, sending, or transferring of tokens.
    /// </summary>
    stop_transactions = 1,

    /// <summary>
    /// The contract will only execute a SetContractStatus message.
    /// </summary>
    stop_all = 2
}
public class ReceiverInfo
{
    /// <summary>
    /// Code hash of the recipient contract (not optional).
    /// </summary>
    [JsonProperty("recipient_code_hash")]
    public string RecipientCodeHash { get; set; }

    /// <summary>
    /// True if the recipient contract implements BatchReceiveNft in addition to ReceiveNft.
    /// </summary>
    [JsonProperty("also_implements_batch_receive_nft")]
    public bool? AlsoImplementsBatchReceiveNft { get; set; }
}