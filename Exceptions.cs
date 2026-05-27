namespace BankApp;

public class InsufficientFundsException : Exception
{
public decimal Amount { get; }
public decimal Limit { get; }

public InsufficientFundsException(decimal amount, decimal limit)
    : base($"Nelze vybrat {amount:F2} Kč, překračuje povolený limit {limit:F2} Kč.")
{
    Amount = amount;
    Limit = limit;
}
}