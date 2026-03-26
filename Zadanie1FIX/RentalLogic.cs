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
}