using BankApp;
// BankApp
Bank bank = new Bank();

bank.AddAccount(new CheckingAccount("123456", "Jan Novák", 10000, 5000));
bank.AddAccount(new SavingsAccount("654321", "Jana Nováková", 20000, 0.02m));

Console.WriteLine("=== Vítejte v BankApp ===");
Console.WriteLine("Příkazy: seznam, vybrat, vklad, vyber, prevod, historie, exit");

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

        case "exit":
            Console.WriteLine("Nashledanou!");
            return;

        default:
            Console.WriteLine("Neznámý příkaz. Dostupné příkazy: seznam, vybrat, vklad, vyber, prevod, historie, exit");
            break;
    }
}