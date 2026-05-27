namespace BankApp;

public class Transaction
{
    public DateTime Date { get; }
    public string Type { get; }
    public decimal Amount { get; }
    public decimal BalanceAfter { get; }

    public Transaction(DateTime date, string type, decimal amount, decimal balanceAfter)
    {
        Date = date;
        Type = type;
        Amount = amount;
        BalanceAfter = balanceAfter;
    }

    public override string ToString()
    {
        return $"{Date:dd.MM.yyyy HH:mm} | {Type,-10} | {Amount,10:F2} Kč | Zůstatek: {BalanceAfter:F2} Kč";
    }
}