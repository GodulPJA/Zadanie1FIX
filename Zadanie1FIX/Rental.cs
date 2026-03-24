namespace Zadanie1FIX;

public class Rental
{
    private DateTime startDate { get; }
    private DateTime endDate { set; get; }
    private DateTime accualEndDate { set; get; } //zwrot terminowy będzie sprawdzany w klasie interfesju prównując daty
    private int additionalCost { set; get; }
    Tool atool;
    public Guid Id { get; set; }
    public User User { get; set; }
    public Rental(Tool tool1,User user)
    {
        atool = tool1;
        Id = Guid.NewGuid();
        User = user;
        startDate = DateTime.Now;
    }
}