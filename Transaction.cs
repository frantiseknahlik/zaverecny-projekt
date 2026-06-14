namespace BankApp;

/// Záznam o jedné bankovní transakci.
/// Uchovává datum, typ operace, částku a zůstatek po operaci.
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

 
    /// Vrátí textovou reprezentaci transakce pro výpis do konzole nebo souboru.
    public override string ToString()
    {
        return $"{Date:dd.MM.yyyy HH:mm} | {Type,-10} | {Amount,10:F2} Kč | Zůstatek: {BalanceAfter:F2} Kč";
    }
}