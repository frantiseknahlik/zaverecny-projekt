namespace BankApp;

public class Bank
{
    private List<Account> _accounts = new List<Account>();

    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }

    public Account? FindAccount(string accountNumber)
    {
        foreach (var account in _accounts)
        {
            if (account.AccountNumber == accountNumber)
                return account;
        }
        return null;
    }

    public void PrintAllAccounts()
    {
        if (_accounts.Count == 0)
        {
            Console.WriteLine("Žádné účty.");
            return;
        }
        foreach (var account in _accounts)
        {
            Console.WriteLine($"{account.AccountNumber} | {account.OwnerName} | {account.Balance:F2} Kč | {account.GetType().Name}");
        }
    }

    public void Transfer(string fromNumber, string toNumber, decimal amount)
    {
        Account? from = FindAccount(fromNumber);
        Account? to = FindAccount(toNumber);

        if (from == null)
            throw new ArgumentException($"Účet {fromNumber} neexistuje.");
        if (to == null)
            throw new ArgumentException($"Účet {toNumber} neexistuje.");

        from.Withdraw(amount);
        to.Deposit(amount);
    }
}