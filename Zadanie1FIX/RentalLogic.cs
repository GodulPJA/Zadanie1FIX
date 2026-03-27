namespace Zadanie1FIX;

public class RentalLogic
{
    Service service;
    private const int DziennaKara = 100;
    
    public RentalLogic(Service service)
    {
        this.service = service;
    }
    
    public bool WypozyczSprzet(User user, Tool tool, DateTime endDate)
    {
        if (tool.CurrentState != State.Wolny)
        {
            throw new InvalidOperationException("Sprzęt nie jest obecnie wolny."); 
        }

        if (user.ActiveRentals >= user.MaxActiveRentals)
        {
            throw new InvalidOperationException("Użytkownik osiągnął limit aktywnych wypożyczeń."); 
        }
        
        tool.CurrentState = State.Wynajety;
        user.ActiveRentals++;
        service.Rentals.Add(new Rental(tool, user, endDate));
        
        return true;
    }
    
    public bool ZwrotSprzetu(Tool tool)
    {
        Rental aktywneWypozyczenie = null;

        foreach (var rent in service.Rentals)
        {
            if (rent.atool == tool && rent.accualEndDate == DateTime.MinValue)
            {
                aktywneWypozyczenie = rent;
                break;
            }
        }

        if (aktywneWypozyczenie == null) throw new InvalidOperationException("Brak aktywnego wypożyczenia dla tego sprzętu."); 

        aktywneWypozyczenie.accualEndDate = DateTime.Now;
        aktywneWypozyczenie.atool.CurrentState = State.Wolny;
        aktywneWypozyczenie.User.ActiveRentals--;

        if (aktywneWypozyczenie.accualEndDate > aktywneWypozyczenie.endDate) 
        {
            TimeSpan opoznienie = aktywneWypozyczenie.accualEndDate - aktywneWypozyczenie.endDate;
            int dniOpoznienia = (int)opoznienie.TotalDays;
            
            if (dniOpoznienia > 0)
            {
                aktywneWypozyczenie.additionalCost = dniOpoznienia * DziennaKara;
            }
        }
        
        return true;
    }
    
    public List<Tool> PokazDostepne()
    {
        List<Tool> dostepne = new List<Tool>();
        foreach (var t in service.Tools)
        {
            if (t.CurrentState == State.Wolny)
            {
                dostepne.Add(t);
            }
        }
        return dostepne;
    }
    
    public List<Rental> PobierzPrzeterminowane()
    {
        List<Rental> zalegle = new List<Rental>();
        DateTime teraz = DateTime.Now;

        foreach (var r in service.Rentals)
        {
            if (r.accualEndDate == DateTime.MinValue && r.endDate < teraz)
            {
                zalegle.Add(r);
            }
        }
        return zalegle;
    }
    
    public List<Rental> AktywneUsera(User user)
    {
        List<Rental> aktywne = new List<Rental>();
        foreach (var r in service.Rentals)
        {
            if (r.User == user && r.accualEndDate == DateTime.MinValue)
            {
                aktywne.Add(r);
            }
        }
        return aktywne;
    }
    
    public bool AwariaSprzetu(Tool tool)
    {
        if (tool.CurrentState == State.Wynajety)
        {
            throw new InvalidOperationException("Nie można zgłosić awarii sprzętu, który jest u klienta."); 
        }
        
        tool.CurrentState = State.Niedostepny;
        
        return true;
    }
    
    public string Raport()
    {
        int wolne = 0;
        int wynajete = 0;
        int niedostepne = 0;

        foreach (var tool in service.Tools)
        {
            if (tool.CurrentState == State.Wolny) wolne++;
            else if (tool.CurrentState == State.Wynajety) wynajete++;
            else if (tool.CurrentState == State.Niedostepny) niedostepne++;
        }

        int przeterminowane = PobierzPrzeterminowane().Count;
        
        int sumaKar = 0;
        foreach (var r in service.Rentals)
        {
            sumaKar += r.additionalCost;
        }

        return $"Sprzęt wolny: {wolne}\n" +
               $"Sprzęt wynajęty: {wynajete}\n" +
               $"Sprzęt w serwisie/niedostępny: {niedostepne}\n" +
               $"Przeterminowane wypożyczenia: {przeterminowane}\n" +
               $"Kara: {sumaKar} PLN\n";
    }
}