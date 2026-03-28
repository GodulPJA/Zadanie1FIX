namespace Zadanie1FIX;

public class Tool
{
    public Guid Id { get; private set; }
    public State CurrentState { get; set; }
    public string Name { get; set; }

    public Tool(string name, State state)
    {
        Id = Guid.NewGuid();
        Name = name;
        CurrentState = state;
    }
}

public class Laptop : Tool
{
    public int Rozmiar { get; set; }
    public OS SystemOperacyjny { get; set; }
    
    public enum OS
    {
        Windows,
        Linux,
        Mac
    }
   
    public Laptop(string name, OS system, int rozmiar, State state) : base(name, state)
    {
        SystemOperacyjny = system;
        Rozmiar = rozmiar;
    }
}
public class Mikrofon : Tool
{
    public string Interface { get; set; }
    public Typ TypElementu { get; set; }
    
    public enum Typ
    {
        Pojemnosciowy,
        Dynamiczny,
        Wstegowe,
        Piezo
        
    }
   
    public Mikrofon(string name, Typ typElementu, string interfejs, State state) : base(name, state)
    {
        TypElementu = typElementu;
        Interface = interfejs;
    }
}
public class Kabel : Tool
{
    public int Dlugosc { get; set; }
    public Wtyczka Wtyczka1 { get; set; }
    public Wtyczka Wtyczka2 { get; set; }
    public enum Wtyczka
    {
        USBC,
        USBA,
        HDMI,
        USBB,
        VGA,
        DP,
        
    }
   
    public Kabel(string name, Wtyczka Wtyczka, Wtyczka Wtyczkaa2,int dlugosc, State state) : base(name, state)
    {
        Wtyczka1 = Wtyczka;
        Wtyczka2 = Wtyczkaa2;
        Dlugosc = dlugosc;
    }
}