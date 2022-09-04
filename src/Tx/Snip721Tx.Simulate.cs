using SecretNET.AccessControl;
using SecretNET.Tx;

namespace SecretNET.SNIP721;

public class Snip721TxSimulate
{
    private TxClient _tx;

    public Snip721TxSimulate(TxClient tx)
    {
        _tx = tx;
    }

    // https://github.com/baedrik/snip721-reference-impl

    /// <summary>
    /// Simulates an request.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="txOptions">The tx options.</param>
    /// <returns>SimulateResponse.</returns>
    public async Task<SimulateResponse> Simulate(MsgBase msg, TxOptions? txOptions = null)
    {
        return await _tx.Simulate(msg, txOptions);
    }

}
