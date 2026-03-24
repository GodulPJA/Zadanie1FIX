namespace Zadanie1FIX;

public class Rental
{
    public DateTime startDate { get; }
    public DateTime endDate { set; get; }
    public DateTime accualEndDate { set; get; } //zwrot terminowy będzie sprawdzany w klasie interfesju prównując daty
    public int additionalCost { set; get; }
    Tool atool;
    public Guid Id { get; set; }
    public User User { get; set; }
    public Rental(Tool tool1,User user, DateTime EndDate)
    {
        atool = tool1;
        Id = Guid.NewGuid();
        User = user;
        startDate = DateTime.Now;
        endDate = EndDate;
    }
}