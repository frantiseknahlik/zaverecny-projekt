namespace BankApp;

/// Výjimka která se vyhodí když uživatel chce vybrat více peněz
/// než povoluje limit účtu.
public class InsufficientFundsException : Exception
{
    
    /// Požadovaná částka k výběru.
    public decimal Amount { get; }

    
    /// Maximální povolený limit výběru.
    public decimal Limit { get; }

    public InsufficientFundsException(decimal amount, decimal limit)
        : base($"Nelze vybrat {amount:F2} Kč, překračuje povolený limit {limit:F2} Kč.")
    {
        Amount = amount;
        Limit = limit;
    }
}