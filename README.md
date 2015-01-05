ProgramingStudy
===============

Biblioteka ProgramingStudy w .NET zawiera bazę do nauki programowania w języku C#. 

Docelowych efektem jest utworzenie solucji do nauki C# metodą "koans". Metoda ta bazuje na założeniu, że języka można się nauczyć poprzez uzupełnianie testów jednostkowych tak aby zwracały poprawną wartość. Przykłąd takiego podejścia można zaobserwować tutaj: https://github.com/ChrisMarinos/FSharpKoans (nauka F# włąsnie za pomocą takiej metody).

Projekt podzielony jest na etapy:

* Etap 1 to stworzenie materiału do nauki.
* Etap 2 będzie stworzeniem projektu do nauki C# poprzez metodę "koansę.


###Szybki start Etap 1:

Projekt składa się z programu konsolowego, który umożliwia szybkie uruchomienie prostych zagadnień poznanych w czasie nauki programowania.

Założenia:

- Zagadnienia tworzymy poprzez utworzenie nowej klasy, która implementuje interfejs IStudyTest. 
- Następnie tworzymy treść zagadnienia w nowo utworzonej klasie.
- Następnie zmieniamy w klasie Program nazwę wywoływanego zagadnienia 

Przykład:
Stworzyliśmy zagadnienie EnumTest (w którym coś tam sprawdzamy na enumach). Teraz wystarczy przypisać do pola StudyTest instancję naszego zagadnienia i uruchomić program.

public static readonly IStudyTest StudyTest = new EnumTest();

- Program wykona to co się znajduje w metodzie Study() (z interfejsu IStudyTest). Dodatkowo wyświetli kiedy metoda się uruchomiła oraz kiedy metoda się zatrzymała.






