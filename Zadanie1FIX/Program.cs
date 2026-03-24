using Zadanie1FIX;

Service srv = new Service();
srv.UtworzIDodajStudenta("Kamil", "Kowalski");
srv.UtworzIDodajMikrofon("c110", Mikrofon.Typ.Piezo,"XLR");
srv.UtworzIDodajMikrofon("Tracer generic", Mikrofon.Typ.Pojemnosciowy,"USB");

foreach (var tool in srv.Tools)
{
    Console.WriteLine($"{tool.Name}");
}
foreach (var user in srv.Users)
{
    Console.WriteLine($" {user.FirstName} {user.LastName} {user.ActiveRentals}");
}

//Todo wywalić te szybkie testy z góry i zaimplementować w Servuce