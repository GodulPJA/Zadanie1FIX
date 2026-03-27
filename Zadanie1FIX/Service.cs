namespace Zadanie1FIX;

public class Service
{
    public List<User> Users { get; private set; } = new List<User>();
    public List<Tool> Tools { get; private set; } = new List<Tool>();
    public List<Rental> Rentals { get; private set; } = new List<Rental>();

    public void UtworzIDodajStudenta(string imie, string nazwisko)
    {
        Users.Add(new Student(imie, nazwisko));
    }

    public void UtworzIDodajPracownika(string imie, string nazwisko)
    {
        Users.Add(new Employee(imie, nazwisko));
    }

    public void UtworzIDodajLaptopa(string nazwa, Laptop.OS system, int rozmiar)
    {
        Tools.Add(new Laptop(nazwa, system, rozmiar, State.Wolny));
    }

    public void UtworzIDodajMikrofon(string nazwa, Mikrofon.Typ typ, string interfejs)
    {
        Tools.Add(new Mikrofon(nazwa, typ, interfejs, State.Wolny));
    }

    public void UtworzIDodajKabel(string nazwa, Kabel.Wtyczka wtyczka1, Kabel.Wtyczka wtyczka2, int dlugosc)
    {
        Tools.Add(new Kabel(nazwa, wtyczka1, wtyczka2, dlugosc, State.Wolny));
    }
}