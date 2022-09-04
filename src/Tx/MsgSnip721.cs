using SecretNET.Tx;
using SecretNET.AccessControl;

namespace SecretNET.SNIP721;

public class MsgInstantiate : MsgInstantiateContract
{
    public MsgInstantiate(
        ulong codeId, 
        string label,
        InstantiateSnip721 initOptions, 
        string codeHash = null, 
        string sender = null):base(codeId, label, initOptions, codeHash, sender)
    {

    }
}

public class MsgSendNft : MsgExecuteContract<SendNftRequest>
{
    public MsgSendNft(
        SendNftRequest msg, 
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ):base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgAddMinter : MsgExecuteContract<AddMinterRequest>
{
    public MsgAddMinter(
        AddMinterRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgMintNft : MsgExecuteContract<MintNftRequest>
{
    public MsgMintNft(
        MintNftRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgBatchMintNft : MsgExecuteContract<BatchMintNftRequest>
{
    public MsgBatchMintNft(
        BatchMintNftRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgMintNftClones : MsgExecuteContract<MintNftClonesRequest>
{
    public MsgMintNftClones(
        MintNftClonesRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgSetMetadata : MsgExecuteContract<SetMetadataRequest>
{
    public MsgSetMetadata(
        SetMetadataRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgSetRoyaltyInfo : MsgExecuteContract<SetRoyaltyInfoRequest>
{
    public MsgSetRoyaltyInfo(
        SetRoyaltyInfoRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgReveal : MsgExecuteContract<RevealRequest>
{
    public MsgReveal(
        RevealRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgMakeOwnershipPrivate : MsgExecuteContract<MakeOwnershipPrivateRequest>
{
    public MsgMakeOwnershipPrivate(
        MakeOwnershipPrivateRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgSetGlobalApproval : MsgExecuteContract<SetGlobalApprovalRequest>
{
    public MsgSetGlobalApproval(
        SetGlobalApprovalRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgSetWhitelistedApproval : MsgExecuteContract<SetWhitelistedApprovalRequest>
{
    public MsgSetWhitelistedApproval(
        SetWhitelistedApprovalRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgApprove : MsgExecuteContract<ApproveRequest>
{
    public MsgApprove(
        ApproveRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgRevoke : MsgExecuteContract<RevokeRequest>
{
    public MsgRevoke(
        RevokeRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgApproveAll : MsgExecuteContract<ApproveAllRequest>
{
    public MsgApproveAll(
        ApproveAllRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgRevokeAll : MsgExecuteContract<RevokeAllRequest>
{
    public MsgRevokeAll(
        RevokeAllRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgTransferNft : MsgExecuteContract<TransferNftRequest>
{
    public MsgTransferNft(
        TransferNftRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgBatchTransferNft : MsgExecuteContract<BatchTransferNftRequest>
{
    public MsgBatchTransferNft(
        BatchTransferNftRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgBatchSendNft : MsgExecuteContract<BatchSendNftRequest>
{
    public MsgBatchSendNft(
        BatchSendNftRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgBurnNft : MsgExecuteContract<BurnNftRequest>
{
    public MsgBurnNft(
        BurnNftRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgBatchBurnNft : MsgExecuteContract<BatchBurnNftRequest>
{
    public MsgBatchBurnNft(
        BatchBurnNftRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgCreateViewingKey : MsgExecuteContract<CreateViewingKeyRequest>
{
    public MsgCreateViewingKey(
        CreateViewingKeyRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgSetViewingKey : MsgExecuteContract<SetViewingKeyRequest>
{
    public MsgSetViewingKey(
        SetViewingKeyRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgRemoveMinters : MsgExecuteContract<RemoveMintersRequest>
{
    public MsgRemoveMinters(
        RemoveMintersRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgSetMinters : MsgExecuteContract<SetMintersRequest>
{
    public MsgSetMinters(
        SetMintersRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgSetContractStatus : MsgExecuteContract<SetContractStatusRequest>
{
    public MsgSetContractStatus(
        SetContractStatusRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgChangeAdmin : MsgExecuteContract<ChangeAdminRequest>
{
    public MsgChangeAdmin(
        ChangeAdminRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgRegisterReceiveNft : MsgExecuteContract<RegisterReceiveNftRequest>
{
    public MsgRegisterReceiveNft(
        RegisterReceiveNftRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}

public class MsgRevokePermit : MsgExecuteContract<RevokePermitRequest>
{
    public MsgRevokePermit(
        RevokePermitRequest msg,
        string contractAddress,
        string codeHash = null,
        string sender = null,
        SecretNET.Tx.Coin[] sentFunds = null
        ) : base(contractAddress, msg, codeHash, sender, sentFunds)
    {
    }
}