using Zadanie1FIX;

Service srv = new Service();
RentalLogic RL = new RentalLogic(srv);
srv.UtworzIDodajStudenta("Kamil", "Kowalski");
srv.UtworzIDodajMikrofon("c110", Mikrofon.Typ.Piezo,"XLR");
srv.UtworzIDodajMikrofon("Tracer generic", Mikrofon.Typ.Pojemnosciowy,"USB");

while (true)
{
    Console.WriteLine("Wybierz opcję: ");
    Console.WriteLine("1. Pokaż dostępny sprzęt");
    Console.WriteLine("2. Wypożycz sprzęt");
    Console.WriteLine("3. Zwróć sprzęt");
    Console.WriteLine("4. Zgłoś awarię sprzętu");
    Console.WriteLine("5. Pokaż raport");
    Console.WriteLine("6. Dodaj użytkownika");
    Console.WriteLine("7. Dodaj sprzęt");
    Console.WriteLine("8. Pokaż cały sprzęt");
    Console.WriteLine("9. Pokaż aktywne wypożyczenia użytkownika");
    Console.WriteLine("10. Pokaż przeterminowane wypożyczenia");
    Console.WriteLine("0. Wyjdź");
    
    string opcja = Console.ReadLine();

    switch (opcja)
    {
        case "1":
            foreach (var t in RL.PokazDostepne()) Console.WriteLine(t.Name);
            break;

        case "2":
            Console.WriteLine("Użytkownicy:");
            for (int i = 0; i < srv.Users.Count; i++)
                Console.WriteLine($"[{i}] {srv.Users[i].FirstName} {srv.Users[i].LastName}");
            
            Console.Write("Podaj indeks usera: ");
            int u = int.Parse(Console.ReadLine());

            Console.WriteLine("Sprzęt:");
            for (int i = 0; i < srv.Tools.Count; i++)
                Console.WriteLine($"[{i}] {srv.Tools[i].Name} ({srv.Tools[i].CurrentState})");
            
            Console.Write("Podaj indeks sprzętu: ");
            int s = int.Parse(Console.ReadLine());
            
            try 
            { 
                RL.WypozyczSprzet(srv.Users[u], srv.Tools[s], DateTime.Now.AddDays(7)); 
                Console.WriteLine("Wypożyczono."); 
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            break;

        case "3":
            Console.WriteLine("Aktywne wypożyczenia:");
            
            List<Rental> aktywne = new List<Rental>();
            foreach (var r in srv.Rentals)
            {
                if (r.accualEndDate == DateTime.MinValue) aktywne.Add(r);
            }

            if (aktywne.Count == 0)
            {
                Console.WriteLine("Brak sprzętu do zwrotu.");
                break;
            }

            for (int i = 0; i < aktywne.Count; i++)
            {
                Console.WriteLine($"[{i}] {aktywne[i].User.FirstName} {aktywne[i].User.LastName} - {aktywne[i].atool.Name}");
            }

            Console.Write("Podaj indeks do zwrotu: ");
            int z = int.Parse(Console.ReadLine());
            
            try 
            { 
                RL.ZwrotSprzetu(aktywne[z].atool); 
                Console.WriteLine("Zwrócono."); 
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            break;

        case "4":
            Console.WriteLine("Sprzęt:");
            for (int i = 0; i < srv.Tools.Count; i++)
                Console.WriteLine($"[{i}] {srv.Tools[i].Name} ({srv.Tools[i].CurrentState})");

            Console.Write("Podaj indeks sprzętu: ");
            int a = int.Parse(Console.ReadLine());
            
            try 
            { 
                RL.AwariaSprzetu(srv.Tools[a]); 
                Console.WriteLine("Zgłoszono awarię."); 
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            break;

        case "5":
            Console.WriteLine(RL.Raport());
            break;
        case "6":
            Console.WriteLine("Kogo dodajesz? (1-Student, 2-Pracownik)");
            string typUsera = Console.ReadLine();
            Console.Write("Imię: ");
            string imie = Console.ReadLine();
            Console.Write("Nazwisko: ");
            string nazwisko = Console.ReadLine();
            
            if (typUsera == "1") srv.UtworzIDodajStudenta(imie, nazwisko);
            else if (typUsera == "2") srv.UtworzIDodajPracownika(imie, nazwisko);
            
            Console.WriteLine("Dodano użytkownika.");
            break;
        case "7":
            Console.WriteLine("Jaki sprzęt? (1-Laptop, 2-Mikrofon, 3-Kabel)");
            string typSprzetu = Console.ReadLine();
            Console.Write("Nazwa/Model: ");
            string nazwa = Console.ReadLine();

            if (typSprzetu == "1")
            {
                Console.WriteLine("System operacyjny: [0] Windows, [1] Linux, [2] Mac");
                Console.Write("Wybierz: ");
                Laptop.OS wybranyOS = (Laptop.OS)int.Parse(Console.ReadLine());

                Console.Write("Rozmiar: ");
                int rozmiar = int.Parse(Console.ReadLine());

                srv.UtworzIDodajLaptopa(nazwa, wybranyOS, rozmiar);
                Console.WriteLine("Dodano laptopa.");
            }
            else if (typSprzetu == "2")
            {
                Console.WriteLine("Typ mikrofonu: [0] Pojemnosciowy, [1] Dynamiczny, [2] Wstegowe, [3] Piezo");
                Console.Write("Wybierz: ");
                Mikrofon.Typ wybranyTyp = (Mikrofon.Typ)int.Parse(Console.ReadLine());

                Console.Write("Interfejs (np. USB, XLR): ");
                string interfejs = Console.ReadLine();

                srv.UtworzIDodajMikrofon(nazwa, wybranyTyp, interfejs);
                Console.WriteLine("Dodano mikrofon.");
            }
            else if (typSprzetu == "3")
            {
                Console.WriteLine("Dostępne wtyczki: [0] USBC, [1] USBA, [2] HDMI, [3] USBB, [4] VGA, [5] DP");
                
                Console.Write("Wybierz wtyczkę 1: ");
                Kabel.Wtyczka w1 = (Kabel.Wtyczka)int.Parse(Console.ReadLine());

                Console.Write("Wybierz wtyczkę 2: ");
                Kabel.Wtyczka w2 = (Kabel.Wtyczka)int.Parse(Console.ReadLine());

                Console.Write("Długość: ");
                int dlugosc = int.Parse(Console.ReadLine());

                srv.UtworzIDodajKabel(nazwa, w1, w2, dlugosc);
                Console.WriteLine("Dodano kabel.");
            }
            break;
        case "8":
            if (srv.Tools.Count == 0) Console.WriteLine("Brak sprzętu.");
            else foreach (var t in srv.Tools) Console.WriteLine($"{t.Name} (Status: {t.CurrentState})");
            break;
        case "9":
            Console.WriteLine("Użytkownicy:");
            if (srv.Users.Count == 0) 
            {
                Console.WriteLine("Brak użytkowników.");
                break;
            }
            for (int i = 0; i < srv.Users.Count; i++)
                Console.WriteLine($"[{i}] {srv.Users[i].FirstName} {srv.Users[i].LastName}");
            
            Console.Write("Podaj indeks usera: ");
            int idU = int.Parse(Console.ReadLine());
            
            var aktywneUsera = RL.AktywneUsera(srv.Users[idU]);
            if (aktywneUsera.Count == 0)
            {
                Console.WriteLine("Ten użytkownik nie ma aktywnych wypożyczeń.");
            }
            else
            {
                Console.WriteLine($"Wypożyczenia ({srv.Users[idU].FirstName}):");
                foreach (var r in aktywneUsera)
                    Console.WriteLine($"- {r.atool.Name} (Do: {r.endDate.ToShortDateString()})");
            }
            break;
        case "10":
            var przeterminowane = RL.PobierzPrzeterminowane();
            if (przeterminowane.Count == 0)
            {
                Console.WriteLine("Brak przeterminowanych wypożyczeń.");
            }
            else
            {
                Console.WriteLine("Przeterminowane wypożyczenia:");
                foreach (var r in przeterminowane)
                    Console.WriteLine($"- {r.User.FirstName} {r.User.LastName} zalega z: {r.atool.Name} (Termin minął: {r.endDate.ToShortDateString()})");
            }
            break;
        
        case "0":
            return;
            
        default:
            Console.WriteLine("Zły wybór.");
            break;
    }
}