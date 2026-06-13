namespace BankApp;
public class CheckingAccount : Account, IOverdraftable
{
    public decimal OverdraftLimit { get; }

    public CheckingAccount(string accountNumber, string ownerName, decimal initialBalance, decimal overdraftLimit)
        : base(accountNumber, ownerName, initialBalance)
    {
        OverdraftLimit = overdraftLimit;
    }

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