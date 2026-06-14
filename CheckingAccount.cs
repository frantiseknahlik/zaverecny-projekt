namespace BankApp;

/// Běžný účet s podporou kontokorentu.
public class CheckingAccount : Account, IOverdraftable
{
    /// Maximální povolený záporný zůstatek.
    public decimal OverdraftLimit { get; }

    public CheckingAccount(string accountNumber, string ownerName, decimal initialBalance, decimal overdraftLimit)
        : base(accountNumber, ownerName, initialBalance)
    {
        OverdraftLimit = overdraftLimit;
    }
    
    /// Vybere peníze z účtu. Povoluje záporný zůstatek do výše OverdraftLimit.
    /// Pokud výběr překročí limit, vyhodí InsufficientFundsException.
    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Částka musí být kladná.");

        if (Balance - amount < -OverdraftLimit)
            throw new InsufficientFundsException(amount, OverdraftLimit);

        Balance -= amount;
        AddTransaction("Výběr", amount);
    }
}