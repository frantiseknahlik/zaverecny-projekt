# BankApp

Jednoduchá konzolová aplikace v C# která simuluje bankovní systém. Jde o závěrečný projekt do školy.

## Co aplikace dělá

Aplikace má dva typy účtů:
- Běžný účet - může jít do mínusu do určitého limitu (kontokorent)
- Spořicí účet - nejde do mínusu, dá se přičíst úrok

## Jak se ovládá

Aplikace se ovládá příkazy které píšete do konzole:

- `seznam` - vypíše všechny účty
- `vybrat` - vybere účet podle čísla
- `vklad` - vloží peníze na účet
- `vyber` - vybere peníze z účtu
- `prevod` - převede peníze z jednoho účtu na druhý
- `historie` - zobrazí historii transakcí
- `exit` - ukončí program

## Soubory

- `Account.cs` - abstraktní třída pro účty
- `CheckingAccount.cs` - běžný účet s kontokorentem
- `SavingsAccount.cs` - spořicí účet
- `Transaction.cs` - třída pro transakce
- `Bank.cs` - správa účtů
- `Exceptions.cs` - vlastní výjimka když není dost peněz
- `Program.cs` - hlavní smyčka programu

## Použití AI

Při práci jsem používal Claude který mi pomáhal s vysvětlováním OOP konceptů a postupně mě provázel tvorbou jednotlivých souborů. Kód jsme psali společně krok za krokem.
