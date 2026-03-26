using Zadanie1FIX;

Service srv = new Service();
RentalLogic RL = new RentalLogic(srv);
srv.UtworzIDodajStudenta("Kamil", "Kowalski");
srv.UtworzIDodajMikrofon("c110", Mikrofon.Typ.Piezo,"XLR");
srv.UtworzIDodajMikrofon("Tracer generic", Mikrofon.Typ.Pojemnosciowy,"USB");
Console.WriteLine(RL.WypozyczSprzet(srv.Users[0],srv.Tools[0],DateTime.Now));
foreach (var rental in srv.Rentals)
{
    Console.WriteLine($"{rental.User.FirstName} {rental.User.LastName}");
    Console.WriteLine($"{rental.atool.CurrentState}");
   
}