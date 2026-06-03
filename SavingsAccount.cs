namespace BankApp;

public class SavingsAccount : Account
{
    public decimal InterestRate { get; }

    public SavingsAccount(string accountNumber, string ownerName, decimal initialBalance, decimal interestRate)
        : base(accountNumber, ownerName, initialBalance)
    {
        InterestRate = interestRate;
    }

    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Částka musí být kladná.");

        if (amount > Balance)
            throw new InsufficientFundsException(amount, Balance);

        Balance -= amount;
        AddTransaction("Výběr", amount);
    }

    public void ApplyInterest()
    {
        decimal interest = Balance * InterestRate;
        Balance += interest;
        AddTransaction("Úrok", interest);
    }
}