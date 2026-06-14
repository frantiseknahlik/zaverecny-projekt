# BankApp

Jednoduchá konzolová aplikace v C#, která simuluje bankovní systém. Jde o závěrečný projekt do školy (Zadání 3 – Bankovní systém).

## Co aplikace dělá

Aplikace spravuje bankovní účty a umožňuje nad nimi provádět operace. Má dva typy účtů:

- **Běžný účet** (CheckingAccount) – může jít do mínusu do určitého limitu (kontokorent)
- **Spořicí účet** (SavingsAccount) – nejde do mínusu, dá se mu přičíst úrok

Každá operace se ukládá do historie transakcí (datum, typ, částka, zůstatek po operaci).

## Jak spustit

V kořenové složce projektu spusť:

```
dotnet run
```

Po spuštění jsou v aplikaci připravené dva ukázkové účty:

- `123456` – Jan Novák, běžný účet (kontokorent 5000)
- `654321` – Jana Nováková, spořicí účet (úrok 2 %)

## Jak se ovládá

Aplikace se ovládá příkazy, které píšeš do konzole. Některé příkazy (vklad, výběr, historie, export, statistiky) pracují s **aktuálně vybraným účtem**, takže nejdřív použij `vybrat`.

| Příkaz | Popis |
|--------|-------|
| `seznam` | vypíše všechny účty |
| `vybrat` | vybere účet podle čísla (pro další operace) |
| `novy` | vytvoří nový účet (běžný nebo spořicí) |
| `vklad` | vloží peníze na vybraný účet |
| `vyber` | vybere peníze z vybraného účtu |
| `prevod` | převede peníze z jednoho účtu na druhý |
| `historie` | zobrazí historii transakcí vybraného účtu |
| `export` | uloží výpis vybraného účtu do textového souboru |
| `mesic` | posune čas o měsíc – připíše úroky na spořicí účty |
| `statistiky` | zobrazí statistiky vybraného účtu (vklady, výběry, nejvyšší výběr) |
| `exit` | ukončí program |

**Pozor na zadávání desetinných čísel:** kvůli českému prostředí se jako desetinný oddělovač používá **čárka**, ne tečka (např. úrok `0,02`, ne `0.02`).

## Ošetření chyb

- Nelze vložit nebo vybrat zápornou částku.
- Nelze vybrat víc, než povoluje zůstatek (spořicí účet) nebo limit kontokorentu (běžný účet) – v takovém případě se vyhodí vlastní výjimka `InsufficientFundsException`.
- Nelze převést peníze na neexistující účet.
- Neplatný vstup (např. text místo částky) program nezhroutí – ošetřeno přes `TryParse`.

## Soubory

- `Account.cs` – abstraktní třída pro účty (společné vlastnosti a operace)
- `CheckingAccount.cs` – běžný účet s kontokorentem
- `SavingsAccount.cs` – spořicí účet s úrokem
- `IOverdraftable.cs` – rozhraní pro účty s kontokorentem
- `Transaction.cs` – třída pro jednu transakci
- `Bank.cs` – správa účtů (vyhledávání, převody, export, statistiky)
- `Exceptions.cs` – vlastní výjimka `InsufficientFundsException`
- `Program.cs` – hlavní smyčka programu (zpracování příkazů)

## Použití AI

Celý projekt jsem programoval sám. AI (Claude) jsem použil jen jako pomocníka u pár věcí – na začátku s nápadem a rozvržením, když jsem si nebyl jistý nějakým OOP konceptem, a na konci na hledání chyb a doladění. Hlavní logiku (třídy, dědičnost, výjimky) jsem psal sám a rozumím jí. Níže jsou prompty, které jsem použil.

### Použité prompty

1. "Jak bych mohl pojmout bankovní systém v konzoli, ať to dává smysl rozdělit na třídy?"
   - Probrali jsme nápad – abstraktní Account a z ní běžný a spořicí účet. Podle toho jsem si to pak napsal.

2. "Můžeš mi vysvětlit, kdy použít abstraktní třídu a kdy rozhraní?"
   - Claude mi to vysvětlil na příkladu, podle toho jsem se rozhodl pro IOverdraftable.

3. "Proč mi nejde zadat úrok 0.02, ale 0,02 jo?"
   - Zjistili jsme, že je to kvůli českému prostředí (desetinná čárka). Opravil jsem nápovědu.

4. "Projdi mi kód, jestli tam nejsou nějaké chyby nebo nedotažené věci."
   - Pomohl mi najít pár drobností a doplnit komentáře ke kódu.

5. "Pomoz mi sepsat README k projektu."
   - Claude mi pomohl dát dohromady tenhle README – popis aplikace, přehled příkazů a sekci o použití AI.
