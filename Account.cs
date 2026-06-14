namespace BankApp;

/// Abstraktní třída reprezentující bankovní účet.
/// Každý typ účtu musí dědit z této třídy.
public abstract class Account
{
    public string AccountNumber { get; }
    public string OwnerName { get; }
    public decimal Balance { get; protected set; }
    
    private List<Transaction> _transactions = new List<Transaction>();
    public IReadOnlyList<Transaction> Transactions => _transactions;

    protected Account(string accountNumber, string ownerName, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = initialBalance;
    }
    
    /// Vloží peníze na účet. Částka musí být kladná.
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Částka musí být kladná.");
        
        Balance += amount;
        _transactions.Add(new Transaction(DateTime.Now, "Vklad", amount, Balance));
    }
    
    /// Výběr peněz z účtu. Každý typ účtu implementuje vlastní logiku.
    public abstract void Withdraw(decimal amount);


    /// Vypíše historii všech transakcí na účtu.
    public void PrintHistory()
    {
        if (_transactions.Count == 0)
        {
            Console.WriteLine("Žádné transakce.");
            return;
        }
        foreach (var t in _transactions)
            Console.WriteLine(t);
    }

    protected void AddTransaction(string type, decimal amount)
    {
        _transactions.Add(new Transaction(DateTime.Now, type, amount, Balance));
    }
}