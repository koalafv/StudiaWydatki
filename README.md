<h1>Wydatki</h1>

<h6>Opis projektu:</h6>
  <p>• Program Wydatki pomaga w nadzorowaniu swoich wydatków. Umożliwia dodawanie wydatków do określonych kategorii, zarówno jako wydatki jednorazowe, jak i cykliczne, które program będzie automatycznie dodawać co miesiąc. Użytkownik może   generować miesięczne raporty podsumowujące wszystkie wydatki według kategorii oraz ogólne sumy wydatków. Projekt został zrealizowany w technologii C# WPF oraz wykorzystuje bazę danych TSQL.</p>

Wymagania systemowe:
  •	System operacyjny: Windows 7 lub nowszy
  •	.NET Framework: 4.7.2 lub nowszy
  •	SQL Server: 2016 lub nowszy
  
Instrukcja instalacji:
  1.	Pobierz projekt
    •	Sklonuj repozytorium: https://github.com/koalafv/StudiaWydatki.git
  2.	Skonfiguruj bazę danych
    •	Z pobranego projektu, wgraj lokalnie bazę podesłana 
    •	Zmień w „app.config” connection string, który odnosi się do twojego hosta.
  3.	Uruchom aplikację
    •	Skompiluj i uruchom projekt za pomocą Visual Studio.

Instrukcja użytkowania:
  1.	Zaloguj się
    •	Dodaj do bazy danych w tabeli „Users” login oraz hasło i datę dodania.
    • Example: insert into Users (usr_Login,usr_Password,usr_date) values ('Studia','studia123!',GETDATE())
  2.	Dodawanie wydatków
    •	Wybierz kategorię wydatku.
    •	Wprowadź kwotę i opis wydatku.
    •	Wybierz, czy wydatek jest jednorazowy, czy cykliczny (miesięczny).
  3.	Generowanie raportów
    •	Przejdź do sekcji "Raporty".
    •	Wybierz miesiąc i zobacz raport.
  4.	Przeglądanie listy wydatków
    •	Przejdź do sekcji "Lista wydatków".
    •	Wybierz odpowiedni filtr, aby zobaczyć szczegóły wydatków.

Licencja:
  • Projekt na studia
  
Autorzy i współtwórcy:
  •	Patryk Kot
  •	Łukasz Kramorz

Kontakt:
  1. Jeśli masz pytania lub sugestie, skontaktuj się z nami:
    •	chx103888@student.chorzow.merito.pl
    •	chx102138@student.chorzow.merito.pl



