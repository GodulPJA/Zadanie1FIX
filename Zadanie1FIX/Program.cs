using Zadanie1FIX;

Service srv = new Service();
RentalLogic RL = new RentalLogic(srv);
srv.UtworzIDodajStudenta("Kamil", "Kowalski");
srv.UtworzIDodajMikrofon("c110", Mikrofon.Typ.Piezo,"XLR");
srv.UtworzIDodajMikrofon("Tracer generic", Mikrofon.Typ.Pojemnosciowy,"USB");
// foreach (var tool in srv.Tools)
// {
//     Console.WriteLine($"{tool.CurrentState}");
// }
// Console.WriteLine(RL.WypozyczSprzet(srv.Users[0],srv.Tools[0],DateTime.Now));
// foreach (var tool in srv.Tools)
// {
//     Console.WriteLine($"{tool.CurrentState}");
// }
// Console.WriteLine(RL.WypozyczSprzet(srv.Users[0],srv.Tools[0],DateTime.Now));
//
// foreach (var rental in srv.Rentals)
// {
//     Console.WriteLine("-------------------------------------------------");
//     Console.WriteLine($"{rental.atool.CurrentState}");
//     Console.WriteLine("-------------------------------------------------");
//
// }
// Console.WriteLine(RL.ZwrotSprzetu(srv.Tools[0]));
// Console.WriteLine(RL.ZwrotSprzetu(srv.Tools[0]));
// foreach (var rental in srv.Rentals)
// {
//     Console.WriteLine("-------------------------------------------------");
//     Console.WriteLine($"{rental.atool.CurrentState}");
//     Console.WriteLine("-------------------------------------------------");
//
// }
foreach (var tool in RL.PokazDostepne())
{
    Console.WriteLine($"{tool.Name} {tool.CurrentState}");
}     
RL.WypozyczSprzet(srv.Users[0], srv.Tools[0], DateTime.Now.AddDays(-2));
Console.WriteLine("wypozyczono tool 0");
Console.WriteLine("-------------------------------------------------");
foreach (var tool in RL.PokazDostepne())
{
    Console.WriteLine($"{tool.Name} {tool.CurrentState}");
}     
RL.ZwrotSprzetu(srv.Tools[0]);
Console.WriteLine("zwrocono tool 0");

Console.WriteLine("-------------------------------------------------");
foreach (var tool in RL.PokazDostepne())
{
    Console.WriteLine($"{tool.Name} {tool.CurrentState}");
}     
Console.WriteLine($"{srv.Rentals[0].additionalCost}");
Console.WriteLine("Dłużnicy:");
RL.WypozyczSprzet(srv.Users[0], srv.Tools[1], DateTime.Now.AddDays(-11));
foreach (var przeterminowane in RL.PobierzPrzeterminowane())
{
    Console.WriteLine($"{przeterminowane.Id} {przeterminowane.User.LastName}");
}
RL.ZwrotSprzetu(srv.Tools[1]);
Console.WriteLine($"{srv.Rentals[1].additionalCost}");
