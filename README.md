System został podzielony na wyspecjalizowane klasy aby każda z nich odpowiadała za inny aspekt działania programu:
  1.Klasy danych:
    Tool
    User
    Rental
  Trzymają one tylko i wyłącznie informacje o obiektach(z czego się składają i jakie mają atrybuty)
  2.Klasa Service(nazywa się service bo na początku myślałem że będzie serwować dane) odpowiedzialna za magazynowanie i dodawanie obiektów.
  3.Klasa RentalLogic zajmująca się wszystkimi operacjami możliwymi na listach z punku wyżej(tutaj zaimplementowane są wymagania funkcjonalne)
  4.Enumy(są enumami :))

Kod jest spójny(coheasive) ze względu na oddzielenie klas danych od klas odpowiedzialnych za logikę każda klasa ma swoje zadanie zgodne z nazwą(poza Service) 

W projekcie zadbano o low coupling pozbawiając konsoli jakiejkolwiek logiki(Program.cs zajmuje się tylko wywoływaniem metod z RentalLogic i wyświetlaniem ich zwracanych wartości)

Dziedziczenie wynikało z potrzeb rozróżnienia specyficznych typów konkretnych klas

Klasa RentalLogic jest trochę duża ale w tak małym projekcie nie widziałem sensu rozdzielania jej na mniejsze części ponieważ klasa faktycznie zajmuje się tylko logiką a jej rozdzielanie na logikę dla userów toolow i rentali spowolniło by to moją pracę i zmniejszyło czytelność kodu
