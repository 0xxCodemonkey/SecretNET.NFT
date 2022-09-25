global using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text;

// SecretNET
using SecretNET;
using SecretNET.Tx;
using SecretNET.Common;
using SecretNET.Common.Storage;
using SecretNET.NFT;



// See https://aka.ms/new-console-template for more information

#region *** Helper functions / Objects ***

Action<string> writeHeadline = (text) =>
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"\r\n**************** {text} ****************\r\n");
    Console.ForegroundColor = ConsoleColor.White;
};

Action<string, SecretTx> logSecretTx = (name, tx) =>
{
    Console.WriteLine($"{name} Txhash: {tx?.Txhash}");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine($"(Gas used: {tx.GasUsed} - Gas wanted {tx.GasWanted})");
    Console.ForegroundColor = ConsoleColor.White;

    //Console.WriteLine($"\r\nCodeId: {JsonConvert.SerializeObject(tx.GetResponseJson(), Formatting.Indented)}");

    if (tx is SingleSecretTx<Secret.Compute.V1Beta1.MsgStoreCodeResponse>)
    {
        Console.WriteLine($"\r\nCodeId: {((SingleSecretTx<Secret.Compute.V1Beta1.MsgStoreCodeResponse>)tx).Response.CodeId}");
    }

    if (tx is SingleSecretTx<Secret.Compute.V1Beta1.MsgInstantiateContractResponse>)
    {
        Console.WriteLine($"\r\nContractAddress: {((SingleSecretTx<Secret.Compute.V1Beta1.MsgInstantiateContractResponse>)tx)?.Response?.Address}");
    }

    if (tx != null && (tx.Code > 0 || (tx.Exceptions?.Any()).GetValueOrDefault()))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        if (tx.Code > 0 && !string.IsNullOrWhiteSpace(tx.Codespace))
        {
            Console.WriteLine($"\r\n!!!!!!!!!!!! Something went wrong => Code: {tx.Code}; Codespace: {tx.Codespace} !!!!!!!!!!!!");
        }
        if ((tx.Exceptions?.Any()).GetValueOrDefault())
        {
            foreach (var ex in tx.Exceptions)
            {
                Console.WriteLine($"\r\n!!!!!!!!!!!! Exception: {ex.Message} !!!!!!!!!!!!");
            }
        }
        Console.WriteLine($"\r\n{tx.RawLog}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();
    }
};

// TxOptions
var txOptions = new TxOptions()
{
    GasLimit = 60_000,
    GasPriceInFeeDenom = 0.26F
};

var txOptionsExecute = new TxOptions()
{
    GasLimit = 300_000,
    GasPriceInFeeDenom = 0.26F
};

var txOptionsUpload = new TxOptions()
{
    GasLimit = 12_000_000,
    GasPriceInFeeDenom = 0.26F
};

#endregion

writeHeadline("Setup SecretNetworkClient / Wallet");

//var storageProvider = new InMemoryOnlyStorage(); // Temporary and most likely only for DEV
var storageProvider = new AesEncryptedFileStorage("","SuperSecurePassword");
var createWalletOptions = new CreateWalletOptions(storageProvider);

Wallet wallet = null;
if (await storageProvider.HasPrivateKey())
{
    var storedMnemonic = await storageProvider.GetFirstMnemonic();
    wallet = await Wallet.Create(storedMnemonic, options: createWalletOptions);
    Console.WriteLine("wallet.Address: " + wallet.Address);
}
else
{
    wallet = await Wallet.Create(options: createWalletOptions);
    Console.WriteLine("wallet.Address: " + wallet.Address);
    Console.WriteLine("Please first fund the wallet with some SCRT via https://faucet.pulsar.scrttestnet.com/ ");
    Console.ReadLine();
}

var gprcUrl = "https://grpc.testnet.secretsaturn.net"; // get from https://github.com/scrtlabs/api-registry
var chainId = "pulsar-2";

var createClientOptions = new CreateClientOptions(gprcUrl, chainId, wallet);
var secretClient = new SecretNetworkClient(createClientOptions);

// dedicated token contract / SNIP20 client
var snip721Client = new Snip721Client(secretClient);     // https://github.com/scrtlabs/snip20-reference-impl

// *** Get Subacccount for target address
var subaccountWallet = await wallet.GetSubaccount(1);
string targetAddress = subaccountWallet.Address;

Console.WriteLine($"\r\nTarget address: {targetAddress}");



// *** Upload SNIP721 / NFT Contract

writeHeadline("Upload SNIP721 Contract (snip721_722_reference_impl.wasm.gz)");

byte[] snip721WasmByteCode = File.ReadAllBytes(@"..\..\..\..\..\resources\snip721_722_reference_impl.wasm.gz");

var msgStoreCodeSnip721 = new MsgStoreCode(snip721WasmByteCode,
                        source: "https://github.com/baedrik/snip721-reference-impl", // Source is a valid absolute HTTPS URI to the contract's source code, optional
                        builder: "enigmampc/secret-contract-optimizer:latest"        // Builder is a valid docker image name with tag, optional
                        );

var snip721StoreCodeResponse = await secretClient.Tx.Compute.StoreCode(msgStoreCodeSnip721, txOptions: txOptionsUpload);
logSecretTx("SNIP712 StoreCode", snip721StoreCodeResponse);

// *** Init NFT Contract ***

writeHeadline("Init SNIP712 Contract with CodeId " + snip721StoreCodeResponse.Response.CodeId);

string snip721Address = null;
string snip721CodeHash = null;
var snip721_code_id = snip721StoreCodeResponse.Response.CodeId;
if (snip721_code_id > 0)
{

    var snip721InstantiateOptions = new InstantiateSnip721()
    {
        Name = "MAUI NFT " + snip721_code_id,
        Symbol = "MAUI",
        Entropy = "Secret NFT",
        Config = new ConfigSettings()
        {
            EnableBurn = true,
        }
    };

    Console.WriteLine("Snip721InstantiateOptions:\r\n" + JsonConvert.SerializeObject(snip721InstantiateOptions, Formatting.Indented) + "\r\n");

    var msgInstantiateSnip721Contract = new MsgInstantiate(snip721_code_id, $"MyFirst NFT {snip721_code_id}", snip721InstantiateOptions);

    var instantiateSnip721ContractResponse = await snip721Client.Tx.Instantiate(msgInstantiateSnip721Contract, txOptionsUpload);
    logSecretTx("InstantiateSnip721Contract", instantiateSnip721ContractResponse);

    snip721Address = instantiateSnip721ContractResponse.Response.Address;
    if (!string.IsNullOrEmpty(snip721Address))
    {
        Console.WriteLine("SNIP712 Address: " + snip721Address + "\r\n");
        snip721CodeHash = await secretClient.Query.Compute.GetCodeHash(snip721Address);
        Console.WriteLine("SNIP712 CodeHash: " + snip721CodeHash);
    }
}

//Console.ReadLine();


// *** Mint NFT ***

//string snip721Address = "Set manual if needed";
//string snip721CodeHash = "Set manual if needed";

writeHeadline("Mint NFT for " + snip721Address);

var mintOptions = MintNftRequest.Create(
    tokenId: "TokenId#" + new Random().Next(2, 99999),
    publicMetadata: new Metadata()
    {
        Extension = new Extension()
        {
            Name = "MAUI Apes",
            Image = "https://lh3.googleusercontent.com/aldaMpqq9wVOwNzq51bSWuDznk3QFQKSNF1OsGM9FCbcocP9J6SsH_qktsXIPB-wVQEJnMRrONnJ9_7aUJPjhtwF-UJ4JMbbz6g=s0",
            Description = "MAUI NFT Collection",
            Attributes = new Trait[]
            {
                new Trait()
                {
                    TraitType = "Name",
                    Value = "Ape X",
                }
            }
        }
    },
    privateMetadata: new Metadata()
    {
        Extension = new Extension()
        {
            Name = "Secrets of MAUI Apes",
            Image = "https://lh3.googleusercontent.com/aldaMpqq9wVOwNzq51bSWuDznk3QFQKSNF1OsGM9FCbcocP9J6SsH_qktsXIPB-wVQEJnMRrONnJ9_7aUJPjhtwF-UJ4JMbbz6g=s0",
            Description = "All the secrets of the MAUI Apes",
            Attributes = new Trait[]
            {
                new Trait()
                {
                    TraitType = "Secret Power",
                    Value = "Laser eyes",
                }
            }
        }
    },
    serialNumber: new SerialNumberType()
    {
        SerialNumber = 66
    },
    memo: "My Memo"
    );

Console.WriteLine("Snip721MintOptions:\r\n" + JsonConvert.SerializeObject(mintOptions, Formatting.Indented) + "\r\n");

var msgSnip721Mint = new MsgMintNft(mintOptions, snip721Address);

var snip721MintResponse = await snip721Client.Tx.MintNft(msgSnip721Mint, txOptionsUpload);
logSecretTx("snip721MintResponse", snip721MintResponse);
Console.WriteLine("Result:\r\n " + snip721MintResponse.GetResponseJson());

//Console.WriteLine();

Console.ReadLine();

// *** View NFT ***

// *** Transfer NFT ***


var payloadTransferMsg = new TransferNftRequest(targetAddress, snip721MintResponse.Response.Result.TokenId);
var sendMsg = new MsgTransferNft(payloadTransferMsg, snip721Address, snip721CodeHash);

var transferResult = await snip721Client.Tx.TransferNft(sendMsg, txOptions: txOptionsExecute);
logSecretTx("transferResult", snip721MintResponse);
