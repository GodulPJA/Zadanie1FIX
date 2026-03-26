namespace Zadanie1FIX;

public class RentalLogic
{
    Service service;
    public RentalLogic(Service service)
    {
        this.service = service;
    }
    public bool WypozyczSprzet(User user, Tool tool, DateTime endDate)
    {
        if (tool.CurrentState != State.Wolny)
        {
            return false;
        }

        if (user.ActiveRentals >= user.MaxActiveRentals)
        {
            return false;
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

        if (aktywneWypozyczenie == null) return false;

        aktywneWypozyczenie.accualEndDate = DateTime.Now;
        aktywneWypozyczenie.atool.CurrentState = State.Wolny;
        aktywneWypozyczenie.User.ActiveRentals--;

        if (aktywneWypozyczenie.accualEndDate > aktywneWypozyczenie.endDate) //todo to chyba lepiej będzie zapakować w oddzielną metodę calculateFees albo coś bo pewnie na dłużniku w konsoli będzie trzeba policzyć
        {
            TimeSpan opoznienie = aktywneWypozyczenie.accualEndDate - aktywneWypozyczenie.endDate;
            int dniOpoznienia = (int)opoznienie.TotalDays;
            
            if (dniOpoznienia > 0)
            {
                aktywneWypozyczenie.additionalCost = dniOpoznienia * 100;
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
}
