namespace Zadanie1FIX;
public abstract class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ActiveRentals { get; set; }

    public abstract int MaxActiveRentals { get; } 
    public User(string firstName, string lastName)
    {
        Id = Guid.NewGuid(); 
        FirstName = firstName;
        LastName = lastName;
    }
}
public class Student : User
{
    public override int MaxActiveRentals => 2;

    public Student(string firstName, string lastName) : base(firstName, lastName) { }
}

public class Employee : User
{
    public override int MaxActiveRentals => 5;

    public Employee(string firstName, string lastName) : base(firstName, lastName) { }
}