## Decyzje projektowe

- Podzieliłem kod na Models i Services, żeby oddzielić dane od logiki.
- Klasy w Models odpowiadają tylko za przechowywanie danych.
- Cała logika wypożyczania znajduje się w LoanService.
- Sprzęt ma klasę bazową Equipment, żeby nie powtarzać wspólnych pól.
- Użytkownicy mają klasę bazową User, a Student i Employee mają różne limity wypożyczeń.
- Status sprzętu jest zapisany jako enum, żeby łatwo sprawdzać dostępność.
