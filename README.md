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

Při práci jsem používal Claude, který mi pomáhal s vysvětlováním OOP konceptů (dědičnost, abstraktní třídy, rozhraní, zapouzdření) a postupně mě provázel tvorbou jednotlivých souborů. Kód jsme psali krok za krokem a snažil jsem se každé části rozumět.

<!-- 
POZNÁMKA PRO TEBE (smaž tenhle komentář před odevzdáním):
Pokud jsi kód generoval pomocí AI, zadání vyžaduje seznam VŠECH promptů, které jsi použil,
+ popis výstupu. Doplň sem své skutečné prompty, např. ve formátu:

### Použité prompty
1. "Vysvětli mi, jak funguje abstraktní třída v C#" – Claude vysvětlil princip a ukázal příklad.
2. "Pomoz mi navrhnout třídu Account pro bankovní systém" – navrhl vlastnosti a metody třídy.
... (doplň všechny, které sis pamatuješ / použil)
-->
