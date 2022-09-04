using SecretNET.AccessControl;
using SecretNET.Tx;

namespace SecretNET.SNIP721;

/// <summary>
/// Client for SNIP20 reference contract (https://github.com/baedrik/snip721-reference-impl at 2022-08-01).
/// </summary>
public class Snip721Tx
{
    // secret Network
    private TxClient _tx;
    private Snip721TxSimulate _txSimulte;

    public Snip721Tx(TxClient tx)
    {
        _tx = tx;
        _txSimulte = new Snip721TxSimulate(tx);
    }

    /// <summary>
    /// Gets the simulate.
    /// </summary>
    /// <value>The simulate.</value>
    public Snip721TxSimulate Simulate
    {
        get { return _txSimulte; }
    }  


    /// <summary>
    /// Instantiates / configures the NFT contract (https://github.com/baedrik/snip721-reference-impl at 2022-07-11).
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="txOptions"></param>
    /// <returns></returns>
    public async Task<InstantiateContractSecretTx> Instantiate(MsgInstantiate msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.InstantiateContract(msg, txOptions);
    }

    /// <summary>
    /// MintNft mints a single token. Only an authorized minting address my execute MintNft.
    /// SNIP-722 adds the ability to optionally mint non-transferable tokens, which are NFTs that can never have a different owner than the address it was minted to.
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="txOptions"></param>
    /// <returns></returns>
    public async Task<SingleSecretTx<MintNftResponse>> MintNft(MsgMintNft msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<MintNftResponse>(msg, txOptions);
    }

    /// <summary>
    /// BatchMintNft mints a list of tokens. Only an authorized minting address my execute BatchMintNft.
    /// SNIP-722 adds the ability to optionally mint non-transferable tokens, which are NFTs that can never have a different owner than the address it was minted to.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;BatchMintNftResponse&gt;.</returns>
    public async Task<SingleSecretTx<BatchMintNftResponse>> BatchMintNft(MsgBatchMintNft msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<BatchMintNftResponse>(msg, txOptions);
    }

    /// <summary>
    /// MintNftClones mints copies of an NFT, giving each one a MintRunInfo that indicates its serial number and the number of identical NFTs minted with it. 
    /// If the optional mint_run_id is provided, the contract will also indicate which mint run these tokens were minted in, where the first use of the mint_run_id will be mint run number 1, 
    /// the second time MintNftClones is called with that mint_run_id will be mint run number 2, etc... 
    /// If no mint_run_id is provided, the MintRunInfo will not include a mint_run.
    /// SNIP-722 adds the ability to optionally mint non-transferable tokens, which are NFTs that can never have a different owner than the address it was minted to.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;MintNftClonesResponse&gt;.</returns>
    public async Task<SingleSecretTx<MintNftClonesResponse>> MintNftClones(MsgMintNftClones msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<MintNftClonesResponse>(msg, txOptions);
    }

    /// <summary>
    /// SendNft is used to transfer ownership of the token to the contract address, and then call the recipient's BatchReceiveNft (or ReceiveNft) if the recipient contract has registered its receiver interface with the NFT contract or if its ReceiverInfo is provided. If the recipient contract registered (or if the ReceiverInfo indicates) that it implements BatchReceiveNft, a BatchReceiveNft callback will be performed with only the single token ID in the token_ids array.
    /// 
    /// While SendNft keeps the contract field name in order to maintain CW-721 compliance, Secret Network does not have the same limitations as Cosmos, and it is possible to use SendNft to transfer token ownership to a personal address(not a contract) or to a contract that does not implement any Receiver Interface.
    /// 
    /// SendNft requires a valid token_id and the message sender must either be the owner or an address with valid transfer approval.If the recipient address is the same as the current owner, the contract will throw an error.If the token is transferred to a new owner, its single-token approvals will be cleared.If the BatchReceiveNft(or ReceiveNft) callback fails, the entire transaction will be reverted(even the transfer will not take place).
    /// This implementation will throw an error if trying to send a SNIP-722 non-transferable token.
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="txOptions"></param>
    /// <returns></returns>
    public async Task<SingleSecretTx<SendNftResponse>> SendNft(MsgSendNft msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<SendNftResponse>(msg, txOptions);
    }

    /// <summary>
    /// AddMinters will add the provided addresses to the list of authorized minters. This can only be called by the admin address.
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="txOptions"></param>
    /// <returns></returns>
    public async Task<SingleSecretTx<AddMinterResponse>> AddMinter(MsgAddMinter msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<AddMinterResponse>(msg, txOptions);
    }

    /// <summary>
    /// SetMetadata will set the public and/or private metadata to the corresponding input if the message sender is either the token owner or 
    /// an approved minter and they have been given this power by the configuration value chosen during instantiation. 
    /// The private metadata of a sealed token may not be altered until after it has been unwrapped.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;SetMetadataResponse&gt;.</returns>
    public async Task<SingleSecretTx<SetMetadataResponse>> SetMetadata(MsgSetMetadata msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<SetMetadataResponse>(msg, txOptions);
    }

    /// <summary>
    /// If a token_id is supplied, SetRoyaltyInfo will update the specified token's RoyaltyInfo to the input. If no RoyaltyInfo is provided, 
    /// it will delete the RoyaltyInfo and replace it with the contract's default RoyaltyInfo (if there is one). 
    /// If no token_id is provided, SetRoyaltyInfo will update the contract's default RoyaltyInfo to the input, or delete it if no RoyaltyInfo is provided.
    /// Only an authorized minter may update the contract's default RoyaltyInfo.
    /// Only a token's creator may update its RoyaltyInfo, and only if they are also the current owner.
    /// 
    /// This implementation will throw an error if trying to set the royalty of a SNIP-722 non-transferable token, because they can never be transferred as part of a sale.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;SetRoyaltyInfoResponse&gt;.</returns>
    public async Task<SingleSecretTx<SetRoyaltyInfoResponse>> SetRoyaltyInfo(MsgSetRoyaltyInfo msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<SetRoyaltyInfoResponse>(msg, txOptions);
    }

    /// <summary>
    /// Reveal unwraps the sealed private metadata, irreversibly marking the token as unwrapped. 
    /// If the unwrapped_metadata_is_private configuration value is true, the formerly sealed metadata will remain private, otherwise it will be made public.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;RevealResponse&gt;.</returns>
    public async Task<SingleSecretTx<RevealResponse>> Reveal(MsgReveal msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<RevealResponse>(msg, txOptions);
    }

    /// <summary>
    /// MakeOwnershipPrivate is used when the token contract was instantiated with the public_owner configuration value set to true. 
    /// It allows an address to make all of its tokens have private ownership by default. 
    /// The owner may still use SetGlobalApproval or SetWhitelistedApproval to make ownership public as desired.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;MakeOwnershipPrivateResponse&gt;.</returns>
    public async Task<SingleSecretTx<MakeOwnershipPrivateResponse>> MakeOwnershipPrivate(MsgMakeOwnershipPrivate msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<MakeOwnershipPrivateResponse>(msg, txOptions);
    }

    /// <summary>
    /// The owner of a token can use SetGlobalApproval to make ownership and/or private metadata viewable by everyone. 
    /// This can be set for a single token or for an owner's entire inventory of tokens by choosing the appropriate AccessLevel. 
    /// SetGlobalApproval can also be used to revoke any global approval previously granted.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;SetGlobalApprovalResponse&gt;.</returns>
    public async Task<SingleSecretTx<SetGlobalApprovalResponse>> SetGlobalApproval(MsgSetGlobalApproval msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<SetGlobalApprovalResponse>(msg, txOptions);
    }

    /// <summary>
    /// The owner of a token can use SetWhitelistedApproval to grant an address permission to view ownership, view private metadata, 
    /// and/or to transfer a single token or every token in the owner's inventory. 
    /// SetWhitelistedApproval can also be used to revoke any approval previously granted to the address.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;SetWhitelistedApprovalResponse&gt;.</returns>
    public async Task<SingleSecretTx<SetWhitelistedApprovalResponse>> SetWhitelistedApproval(MsgSetWhitelistedApproval msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<SetWhitelistedApprovalResponse>(msg, txOptions);
    }

    /// <summary>
    /// Approve is used to grant an address permission to transfer a single token. 
    /// This can only be performed by the token's owner or, in compliance with CW-721, an address that has inventory-wide approval to transfer the owner's tokens. 
    /// Approve is provided to maintain compliance with CW-721, but the owner can use SetWhitelistedApproval to accomplish the same thing if specifying 
    /// a token_id and approve_token AccessLevel for transfer.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;ApproveResponse&gt;.</returns>
    public async Task<SingleSecretTx<ApproveResponse>> Approve(MsgApprove msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<ApproveResponse>(msg, txOptions);
    }

    /// <summary>
    /// Revoke is used to revoke from an address the permission to transfer this single token. 
    /// This can only be performed by the token's owner or, in compliance with CW-721, an address that has inventory-wide approval to transfer the owner's tokens (referred to as an operator later). 
    /// However, one operator may not revoke transfer permission of even one single token away from another operator. 
    /// Revoke is provided to maintain compliance with CW-721, but the owner can use SetWhitelistedApproval to accomplish the same thing 
    /// if specifying a token_id and revoke_token AccessLevel for transfer.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;RevokeResponse&gt;.</returns>
    public async Task<SingleSecretTx<RevokeResponse>> Revoke(MsgRevoke msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<RevokeResponse>(msg, txOptions);
    }

    /// <summary>
    /// ApproveAll is used to grant an address permission to transfer all the tokens in the message sender's inventory. 
    /// This will include the ability to transfer any tokens the sender acquires after granting this inventory-wide approval. 
    /// This also gives the address the ability to grant another address the approval to transfer a single token. 
    /// ApproveAll is provided to maintain compliance with CW-721, but the message sender can use SetWhitelistedApproval to accomplish the same thing by using all AccessLevel for transfer.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;ApproveAllResponse&gt;.</returns>
    public async Task<SingleSecretTx<ApproveAllResponse>> ApproveAll(MsgApproveAll msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<ApproveAllResponse>(msg, txOptions);
    }

    /// <summary>
    /// RevokeAll is used to revoke all transfer approvals granted to an address. RevokeAll is provided to maintain compliance with CW-721, 
    /// but the message sender can use SetWhitelistedApproval to accomplish the same thing by using none AccessLevel for transfer.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;RevokeAllResponse&gt;.</returns>
    public async Task<SingleSecretTx<RevokeAllResponse>> RevokeAll(MsgRevokeAll msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<RevokeAllResponse>(msg, txOptions);
    }

    /// <summary>
    /// TransferNft is used to transfer ownership of the token to the recipient address. 
    /// This requires a valid token_id and the message sender must either be the owner or an address with valid transfer approval. 
    /// If the recipient address is the same as the current owner, the contract will throw an error. If the token is transferred to a new owner, its single-token approvals will be cleared.
    /// 
    /// This implementation will throw an error if trying to transfer a SNIP-722 non-transferable token.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;TransferNftResponse&gt;.</returns>
    public async Task<SingleSecretTx<TransferNftResponse>> TransferNft(MsgTransferNft msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<TransferNftResponse>(msg, txOptions);
    }

    /// <summary>
    /// Transfers the NFT.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="recipient">Address receiving the token.</param>
    /// <param name="tokenId">ID of the token to be transferred.</param>
    /// <param name="memo">Memo for the transfer transaction that is only viewable by addresses involved in the transfer (recipient, sender, previous owner).</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;TransferNftResponse&gt;.</returns>
    public async Task<SingleSecretTx<TransferNftResponse>> TransferNft(string contractAddress, string recipient, string tokenId, string memo = null, string padding = null, string codeHash = null, TxOptions? txOptions = null)
    {
        var msg = new MsgTransferNft(new TransferNftRequest(recipient, tokenId, memo, padding), contractAddress, codeHash);
        return await _tx.Compute.ExecuteContract<TransferNftResponse>(msg, txOptions);
    }

    /// <summary>
    /// BatchTransferNft is used to perform multiple token transfers. The message sender may specify a list of tokens to transfer to one recipient address 
    /// in each Transfer object, and any memo provided will be applied to every token transferred in that one Transfer object. 
    /// The message sender may provide multiple Transfer objects to perform transfers to multiple addresses, providing a different memo for each address if desired. 
    /// Each individual transfer of a token will show separately in transaction histories. The message sender must have permission 
    /// to transfer all the tokens listed (either by being the owner or being granted transfer approval) and every listed token_id must be valid. 
    /// A contract may use the VerifyTransferApproval query to verify that it has permission to transfer all the tokens.
    /// 
    /// If the message sender does not have permission to transfer any one of the listed tokens, the entire message will fail(no tokens will be transferred) 
    /// and the error will provide the ID of the first token encountered in which the sender does not have the required permission.
    /// If any token transfer involves a recipient address that is the same as its current owner, the contract will throw an error.
    /// Any token that is transferred to a new owner will have its single-token approvals cleared.
    /// 
    /// This implementation will throw an error if trying to transfer a SNIP-722 non-transferable token.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;BatchTransferNftResponse&gt;.</returns>
    public async Task<SingleSecretTx<BatchTransferNftResponse>> BatchTransferNft(MsgBatchTransferNft msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<BatchTransferNftResponse>(msg, txOptions);
    }

    /// <summary>
    /// BatchSendNft is used to perform multiple token transfers, and then call the recipient contracts' BatchReceiveNft (or ReceiveNft) if they have registered their receiver interface
    /// with the NFT contract or if their ReceiverInfo is provided. The message sender may specify a list of tokens to send to one recipient address in each Send object, 
    /// and any memo or msg provided will be applied to every token transferred in that one Send object. 
    /// If the list of transferred tokens belonged to multiple previous owners, a separate BatchReceiveNft callback will be performed for each of the previous owners. 
    /// If the contract only implements ReceiveNft, one ReceiveNft will be performed for every sent token. 
    /// Therefore it is highly recommended to implement BatchReceiveNft if there is the possibility of being sent multiple tokens at one time. 
    /// This will significantly reduce gas costs.
    /// 
    /// The message sender may provide multiple Send objects to perform sends to multiple addresses, providing a different memo and msg for each address if desired.
    /// Each individual transfer of a token will show separately in transaction histories.
    /// The message sender must have permission to transfer all the tokens listed (either by being the owner or being granted transfer approval) and every token ID must be valid.
    /// A contract may use the VerifyTransferApproval query to verify that it has permission to transfer all the tokens.
    /// If the message sender does not have permission to transfer any one of the listed tokens, the entire message will fail (no tokens will be transferred) and the error will 
    /// provide the ID of the first token encountered in which the sender does not have the required permission.
    /// If any token transfer involves a recipient address that is the same as its current owner, the contract will throw an error.
    /// Any token that is transferred to a new owner will have its single-token approvals cleared.If any BatchReceiveNft(or ReceiveNft) callback fails, the entire transaction will 
    /// be reverted (even the transfers will not take place).
    /// 
    /// This implementation will throw an error if trying to send a SNIP-722 non-transferable token.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;BatchSendNftResponse&gt;.</returns>
    public async Task<SingleSecretTx<BatchSendNftResponse>> BatchSendNft(MsgBatchSendNft msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<BatchSendNftResponse>(msg, txOptions);
    }

    /// <summary>
    /// BurnNft is used to burn a single token, providing an optional memo to include in the burn's transaction history if desired. 
    /// If the contract has not enabled burn functionality using the init configuration enable_burn, BurnNft will result in an error, 
    /// unless the token being burned is a SNIP-722 non-transferable token. 
    /// This is because an owner should always be able to dispose of an unwanted, non-transferable token. 
    /// Only the token owner and anyone else with valid transfer approval may burn this token.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;BurnNftResponse&gt;.</returns>
    public async Task<SingleSecretTx<BurnNftResponse>> BurnNft(MsgBurnNft msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<BurnNftResponse>(msg, txOptions);
    }

    /// <summary>
    /// BatchBurnNft is used to burn multiple tokens. The message sender may specify a list of tokens to burn in each Burn object, and any memo provided will 
    /// be applied to every token burned in that one Burn object. The message sender will usually list every token to be burned in one Burn object, but if a different memo 
    /// is needed for different tokens being burned, multiple Burn objects may be listed. 
    /// Each individual burning of a token will show separately in transaction histories. The message sender must have permission to transfer/burn all 
    /// the tokens listed (either by being the owner or being granted transfer approval). 
    /// A contract may use the VerifyTransferApproval query to verify that it has permission to transfer/burn all the tokens. 
    /// If the message sender does not have permission to transfer/burn any one of the listed tokens, the entire message will fail (no tokens will be burned) 
    /// and the error will provide the ID of the first token encountered in which the sender does not have the required permission.
    /// 
    /// A SNIP-722 non-transferable token can always be burned even if burn functionality has been disabled using the init configuration.
    /// This is because an owner should always be able to dispose of an unwanted, non-transferable token.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;BatchBurnNftResponse&gt;.</returns>
    public async Task<SingleSecretTx<BatchBurnNftResponse>> BatchBurnNft(MsgBatchBurnNft msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<BatchBurnNftResponse>(msg, txOptions);
    }

    /// <summary>
    /// CreateViewingKey is used to generate a random viewing key to be used to authenticate account-specific queries. 
    /// The entropy field is a client-supplied string used as part of the entropy supplied to the rng that creates the viewing key.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;CreateViewingKeyResponse&gt;.</returns>
    public async Task<SingleSecretTx<CreateViewingKeyResponse>> CreateViewingKey(MsgCreateViewingKey msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<CreateViewingKeyResponse>(msg, txOptions);
    }

    /// <summary>
    /// SetViewingKey is used to set the viewing key to a predefined string. It will replace any key that currently exists. 
    /// It would be best for users to call CreateViewingKey to ensure a strong key, but this function is provided so that contracts can also utilize viewing keys.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;SetViewingKeyResponse&gt;.</returns>
    public async Task<SingleSecretTx<SetViewingKeyResponse>> SetViewingKey(MsgSetViewingKey msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<SetViewingKeyResponse>(msg, txOptions);
    }

    /// <summary>
    /// RemoveMinters will remove the provided addresses from the list of authorized minters. This can only be called by the admin address.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;RemoveMintersResponse&gt;.</returns>
    public async Task<SingleSecretTx<RemoveMintersResponse>> RemoveMinters(MsgRemoveMinters msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<RemoveMintersResponse>(msg, txOptions);
    }

    /// <summary>
    /// SetMinters will precisely define the list of authorized minters. 
    /// This can only be called by the admin address.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;SetMintersResponse&gt;.</returns>
    public async Task<SingleSecretTx<SetMintersResponse>> SetMinters(MsgSetMinters msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<SetMintersResponse>(msg, txOptions);
    }

    /// <summary>
    /// SetContractStatus allows the contract admin to define which messages the contract will execute. 
    /// This can only be called by the admin address.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;SetContractStatusResponse&gt;.</returns>
    public async Task<SingleSecretTx<SetContractStatusResponse>> SetContractStatus(MsgSetContractStatus msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<SetContractStatusResponse>(msg, txOptions);
    }

    /// <summary>
    /// ChangeAdmin will allow the current admin to transfer admin privileges to another address (which will be the only admin address). 
    /// This can only be called by the current admin address.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;ChangeAdminResponse&gt;.</returns>
    public async Task<SingleSecretTx<ChangeAdminResponse>> ChangeAdmin(MsgChangeAdmin msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<ChangeAdminResponse>(msg, txOptions);
    }

    /// <summary>
    /// A contract will use RegisterReceiveNft to notify the NFT contract that it implements ReceiveNft and possibly also BatchReceiveNft (see below). 
    /// This enables the NFT contract to call the registered contract whenever it is Sent a token (or tokens). 
    /// In order to comply with CW-721, ReceiveNft only informs the recipient contract that it has been sent a single token, and it only informs the recipient contract 
    /// who the token's previous owner was, not who sent the token (which may be different addresses) despite calling the previous owner sender (see below). 
    /// BatchReceiveNft, on the other hand, can be used to inform a contract that it was sent multiple tokens, and notifies the recipient of both, the token's previous owner and the sender. 
    /// If a contract implements BatchReceiveNft, the NFT contract will always call BatchReceiveNft even if there is only one token being sent, 
    /// in which case the token_ids array will only have one element.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;RegisterReceiveNftResponse&gt;.</returns>
    public async Task<SingleSecretTx<RegisterReceiveNftResponse>> RegisterReceiveNft(MsgRegisterReceiveNft msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<RegisterReceiveNftResponse>(msg, txOptions);
    }

    /// <summary>
    /// RevokePermit allows a user to disable the use of a permit for authenticated queries.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SingleSecretTx&lt;RevokePermitResponse&gt;.</returns>
    public async Task<SingleSecretTx<RevokePermitResponse>> RevokePermit(MsgRevokePermit msg, TxOptions? txOptions = null)
    {
        return await _tx.Compute.ExecuteContract<RevokePermitResponse>(msg, txOptions);
    }

}
