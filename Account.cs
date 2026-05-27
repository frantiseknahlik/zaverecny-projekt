namespace BankApp;

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

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Částka musí být kladná.");
        
        Balance += amount;
        _transactions.Add(new Transaction(DateTime.Now, "Vklad", amount, Balance));
    }

    public abstract void Withdraw(decimal amount);

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