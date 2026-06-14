namespace BankApp;

/// Správce všech bankovních účtů.
/// Umožňuje přidávání, vyhledávání a operace mezi účty.
public class Bank
{
    private List<Account> _accounts = new List<Account>();
    
    /// Přidá nový účet do banky.
    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }
    
    /// Najde účet podle čísla. Vrátí null pokud účet neexistuje.
    public Account? FindAccount(string accountNumber)
    {
        foreach (var account in _accounts)
        {
            if (account.AccountNumber == accountNumber)
                return account;
        }
        return null;
    }
    
    /// Vypíše všechny účty v bance.
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
    
    /// Převede peníze z jednoho účtu na druhý.
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
    
    /// Exportuje historii transakcí účtu do textového souboru.
    public void ExportHistory(string accountNumber)
    {
        Account? account = FindAccount(accountNumber);
        if (account == null)
            throw new ArgumentException($"Účet {accountNumber} neexistuje.");

        string fileName = $"vypis_{accountNumber}_{DateTime.Now:yyyy-MM-dd_HH-mm}.txt";
        
        using StreamWriter writer = new StreamWriter(fileName);
        writer.WriteLine($"=== Výpis účtu {account.AccountNumber} ===");
        writer.WriteLine($"Majitel: {account.OwnerName}");
        writer.WriteLine($"Aktuální zůstatek: {account.Balance:F2} Kč");
        writer.WriteLine($"Datum výpisu: {DateTime.Now:dd.MM.yyyy HH:mm}");
        writer.WriteLine("-----------------------------------");
        
        foreach (var t in account.Transactions)
            writer.WriteLine(t);
        
        Console.WriteLine($"Výpis uložen do souboru: {fileName}");
    }
    
    /// Posune čas o měsíc — přičte úroky na všechny spořicí účty.
    public void AdvanceMonth()
    {
        foreach (var account in _accounts)
        {
            if (account is SavingsAccount savings)
                savings.ApplyInterest();
        }
        Console.WriteLine("Čas posunut o měsíc. Úroky byly připsány na spořicí účty.");
    }
    
    /// Vypíše statistiky účtu — celkové vklady, výběry a nejvyšší výběr.
    public void PrintStatistics(string accountNumber)
    {
        Account? account = FindAccount(accountNumber);
        if (account == null)
            throw new ArgumentException($"Účet {accountNumber} neexistuje.");

        var transactions = account.Transactions;
        
        if (transactions.Count == 0)
        {
            Console.WriteLine("Žádné transakce.");
            return;
        }

        decimal totalDeposits = 0;
        decimal totalWithdrawals = 0;
        decimal highest = 0;

        foreach (var t in transactions)
        {
            if (t.Type == "Vklad")
                totalDeposits += t.Amount;
            else if (t.Type == "Výběr")
            {
                totalWithdrawals += t.Amount;
                if (t.Amount > highest)
                    highest = t.Amount;
            }
        }

        Console.WriteLine($"=== Statistiky účtu {accountNumber} ===");
        Console.WriteLine($"Celkové vklady:  {totalDeposits:F2} Kč");
        Console.WriteLine($"Celkové výběry:  {totalWithdrawals:F2} Kč");
        Console.WriteLine($"Nejvyšší výběr:  {highest:F2} Kč");
        Console.WriteLine($"Počet transakcí: {transactions.Count}");
    }
}