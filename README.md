<h1>Wydatki - Projekt Na Studia<h1>
<h2>Opis projektu:</h2>
  <h5>Program Wydatki pomaga w nadzorowaniu swoich wydatków. Umożliwia dodawanie wydatków do określonych kategorii, zarówno jako wydatki jednorazowe, jak i cykliczne, które program będzie automatycznie dodawać co miesiąc. Użytkownik może   generować miesięczne raporty podsumowujące wszystkie wydatki według kategorii oraz ogólne sumy wydatków. Projekt został zrealizowany w technologii C# WPF oraz wykorzystuje bazę danych TSQL.</h5>

<h2>Wymagania systemowe:</h2>
  <h5>• System operacyjny: Windows 7 lub nowszy<br>
  • .NET Framework: 4.7.2 lub nowszy<br>
  • SQL Server: 2016 lub nowszy</h5>

<h2>Instrukcja instalacji:</h2>
  <h5>•	Sklonuj repozytorium: https://github.com/koalafv/StudiaWydatki.git<br>
    •	Z pobranego projektu, wgraj lokalnie bazę, która będzie w głownym folderze <br>
    •	Zmień w „app.config” connection string, który odnosi się do twojego hosta.<br>
    •	Skompiluj i uruchom projekt za pomocą Visual Studio.</h5>

<h2>Instrukcja Obsługi:</h2>
    <pre>1.	Tworzenie własnego konta</pre>
    <h5>•	Zalogowanie się na konto administratora.<br>
      Login - "a"<br>
      Hasło - "a"<br>
   • Wejdz do "Panel Admina" i stwórz swoje konto, po czym zaloguj się i korzystaj z aplikacji
  <pre>2.	Dodawanie wydatków</pre>
    •	Wybierz kategorię wydatku.<br>
    •	Wprowadź kwotę i opis wydatku.<br>
    •	Wybierz, czy wydatek jest jednorazowy, czy cykliczny (miesięczny).<br>
     <br><pre>3.	Generowanie raportów</pre>
    •	Przejdź do sekcji "Raporty".<br>
    •	Wybierz miesiąc i zobacz raport.<br><br>
      <pre>4.	Przeglądanie listy wydatków</pre>
    •	Przejdź do sekcji "Lista wydatków".<br>
    •	Wybierz odpowiedni filtr, aby zobaczyć szczegóły wydatków. </h5>

<h2>Diagram (Użytkownik):</h2>
<img src="https://cdn.discordapp.com/attachments/1234064529093038172/1234064726741225524/Im9DNcnUBEYAAAAASUVORK5CYII.png?ex=667fcb56&is=667e79d6&hm=67036c5000f17836fe5793dfb9d4ca2bf683306da9fe0bb537eeee21715c666e&">
<h2>Diagram klas</h2>
<img src="https://cdn.discordapp.com/attachments/1234064529093038172/1254381031264620574/image.png?ex=667fe05f&is=667e8edf&hm=c1341cd1092dd4843b2e4e0ad3aaa8abde46ef4c4a6321440aae061f0f1fa198&">
<h2>Licencja:</h2>
  <h5>• Projekt na studia</h5>

<h2>Wzorce projektowe:</h2>
<h5>Dbamy o czysty kod, dlatego wszystkie zmienne w klasie umieszczamy na górze: najpierw stałe, potem prywatne.<br> Metody są uporządkowane tak, aby kod czytało się jak opis: najpierw publiczne, potem prywatne.</h5>

<h2>Obiektowość</h2>
<h5>Nasza aplikacja wykorzystuje dziedziczenie, hermetyzację i interfejsy. W celu optymalizacji kodu, funkcje widoków są zorganizowane w jednej klasie bazowej, z której inne klasy dziedziczą. Interfejsy ułatwiły nam tworzenie metod wspólnych dla różnych widoków, takich jak czyszczenie pól tekstowych.<br>
<br>
W systemie mamy dwóch typów użytkowników: zwykłego użytkownika i administratora. Zwykły użytkownik może zarządzać swoimi wydatkami, a administrator dodatkowo ma uprawnienia do zarządzania użytkownikami w bazie danych.<br>
<br>
Taka struktura kodu sprawia, że nasza aplikacja jest przejrzysta, łatwa w utrzymaniu i rozwijaniu.







</h5>

<h2>Autorzy i współtwórcy:</h2>
  <h5>•	Patryk Kot<br>
  •	Łukasz Kramorz</h5>

<h2>Kontakt</h2>
   </h>•	chx103888@student.chorzow.merito.pl<br>
    •	chx102138@student.chorzow.merito.pl</h5>



