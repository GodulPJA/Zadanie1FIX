namespace Zadanie1FIX;

public class Rental
{
    //todo sprawdzić jakiej zmiennej daty użyć
    
    Tool atool;
    public Guid Id { get; set; }
    public User User { get; set; }
    public Rental(Tool tool1,User user)
    {
        atool = tool1;
        Id = Guid.NewGuid();
        User = user;
    }
}