using BankApp;
// BankApp
Bank bank = new Bank();

bank.AddAccount(new CheckingAccount("123456", "Jan Novák", 10000, 5000));
bank.AddAccount(new SavingsAccount("654321", "Jana Nováková", 20000, 0.02m));

Console.WriteLine("=== Vítejte v BankApp ===");
Console.WriteLine("Příkazy: seznam, vybrat, novy, vklad, vyber, prevod, historie, export, mesic, statistiky, exit");
string? currentAccountNumber = null;

while (true)
{
    Console.Write("\n> ");
    string? input = Console.ReadLine()?.Trim().ToLower();

    switch (input)
    {
        case "seznam":
            bank.PrintAllAccounts();
            break;

        case "vybrat":
            Console.Write("Číslo účtu: ");
            string? num = Console.ReadLine()?.Trim();
            if (bank.FindAccount(num!) == null)
                Console.WriteLine("Účet nenalezen.");
            else
            {
                currentAccountNumber = num;
                Console.WriteLine($"Vybrán účet: {currentAccountNumber}");
            }
            break;

        case "vklad":
            if (currentAccountNumber == null) { Console.WriteLine("Nejprve vyberte účet."); break; }
            Console.Write("Částka: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
            { Console.WriteLine("Neplatná částka."); break; }
            try
            {
                bank.FindAccount(currentAccountNumber)!.Deposit(depositAmount);
                Console.WriteLine("Vklad proveden.");
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            break;

        case "vyber":
            if (currentAccountNumber == null) { Console.WriteLine("Nejprve vyberte účet."); break; }
            Console.Write("Částka: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
            { Console.WriteLine("Neplatná částka."); break; }
            try
            {
                bank.FindAccount(currentAccountNumber)!.Withdraw(withdrawAmount);
                Console.WriteLine("Výběr proveden.");
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            catch (InsufficientFundsException e) { Console.WriteLine(e.Message); }
            break;

        case "prevod":
            Console.Write("Z účtu: ");
            string? from = Console.ReadLine()?.Trim();
            Console.Write("Na účet: ");
            string? to = Console.ReadLine()?.Trim();
            Console.Write("Částka: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
            { Console.WriteLine("Neplatná částka."); break; }
            try
            {
                bank.Transfer(from!, to!, transferAmount);
                Console.WriteLine("Převod proveden.");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            break;

        case "historie":
            if (currentAccountNumber == null) { Console.WriteLine("Nejprve vyberte účet."); break; }
            bank.FindAccount(currentAccountNumber)!.PrintHistory();
            break;
        
        case "export":
            if (currentAccountNumber == null) { Console.WriteLine("Nejprve vyberte účet."); break; }
            try
            {
                bank.ExportHistory(currentAccountNumber);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            break;

        
        case "mesic":
            bank.AdvanceMonth();
            break;
        
        
        case "statistiky":
            if (currentAccountNumber == null) { Console.WriteLine("Nejprve vyberte účet."); break; }
            try
            {
                bank.PrintStatistics(currentAccountNumber);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            break;
        
        
        case "novy":
            Console.Write("Číslo účtu: ");
            string? newNumber = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(newNumber)) { Console.WriteLine("Neplatné číslo účtu."); break; }
            if (bank.FindAccount(newNumber) != null) { Console.WriteLine("Účet s tímto číslem už existuje."); break; }
    
            Console.Write("Jméno majitele: ");
            string? newOwner = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(newOwner)) { Console.WriteLine("Neplatné jméno."); break; }
    
            Console.Write("Počáteční zůstatek: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal initialBalance))
            { Console.WriteLine("Neplatná částka."); break; }
    
            Console.Write("Typ účtu (bezny/sporici): ");
            string? accountType = Console.ReadLine()?.Trim().ToLower();
    
            if (accountType == "bezny")
            {
                Console.Write("Limit kontokorentu: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal overdraft))
                { Console.WriteLine("Neplatný limit."); break; }
                bank.AddAccount(new CheckingAccount(newNumber, newOwner, initialBalance, overdraft));
                Console.WriteLine("Běžný účet vytvořen.");
            }
            else if (accountType == "sporici")
            {
                Console.Write("Úroková sazba (např. 0.02 = 2%): ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal rate))
                { Console.WriteLine("Neplatná sazba."); break; }
                bank.AddAccount(new SavingsAccount(newNumber, newOwner, initialBalance, rate));
                Console.WriteLine("Spořicí účet vytvořen.");
            }
            else
            {
                Console.WriteLine("Neznámý typ účtu.");
            }
            break;
        
        
        case "exit":
            Console.WriteLine("Nashledanou!");
            return;

        default:
            Console.WriteLine("Neznámý příkaz. Dostupné příkazy: seznam, vybrat, vklad, vyber, prevod, historie, exit");
            break;
    }
}