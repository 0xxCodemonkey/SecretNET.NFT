namespace SecretNET.SNIP721;

/// <summary>
/// Client for SNIP721 reference contract (https://github.com/baedrik/snip721-reference-impl at 2022-08-01).
/// </summary>
public class Snip721Client
{
    SecretNetworkClient _secretNetworkClient = null;

    Snip721Querier _queries = null;
    Snip721Tx _txClient = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="Snip721Client"/> class.
    /// </summary>
    /// <param name="secretNetworkClient">The secret network client.</param>
    public Snip721Client(SecretNetworkClient secretNetworkClient)
	{
        _secretNetworkClient = secretNetworkClient;
    }

    /// <summary>
    /// SNIP721 Queries.
    /// </summary>
    /// <value>The query.</value>
    public Snip721Querier Query
    {
        get
        {
            if (_queries == null)
            {
                _queries = new Snip721Querier(_secretNetworkClient);
            }
            return _queries;
        }
    }

    /// <summary>
    /// SNIP721 Transactions.
    /// </summary>
    /// <value>The tx.</value>
    public Snip721Tx Tx
    {
        get
        {
            if (_txClient == null)
            {
                _txClient = new Snip721Tx(_secretNetworkClient.Tx);
            }
            return _txClient;
        }
    }
}
