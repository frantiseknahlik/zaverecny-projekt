namespace BankApp;

/// Spořicí účet s úrokovou sazbou.
/// Nelze jít do záporného zůstatku.
public class SavingsAccount : Account
{

    /// Úroková sazba například 0,02 = 2 %.
    public decimal InterestRate { get; }

    public SavingsAccount(string accountNumber, string ownerName, decimal initialBalance, decimal interestRate)
        : base(accountNumber, ownerName, initialBalance)
    {
        InterestRate = interestRate;
    }
    
    /// Vybere peníze z účtu. Nelze vybrat více než je aktuální zůstatek.
    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Částka musí být kladná.");

        if (amount > Balance)
            throw new InsufficientFundsException(amount, Balance);

        Balance -= amount;
        AddTransaction("Výběr", amount);
    }
    
    /// Přičte úrok k zůstatku podle úrokové sazby.
    public void ApplyInterest()
    {
        decimal interest = Balance * InterestRate;
        Balance += interest;
        AddTransaction("Úrok", interest);
    }
}