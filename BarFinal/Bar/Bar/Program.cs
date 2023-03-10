using System;
using System.Collections.Generic;
using System.Threading;

namespace Bar
{

    class Program
    {

        static void Menu()
        {
            Console.Clear();
            Gracz.ZeroPromile();
            Console.WriteLine("Witaj {0} {1}. O wieku {2} lat", Gracz.Imie, Gracz.Nazwisko, Gracz.Wiek);
            Console.Write("W portfelu masz " + Gracz.WypPortfel() + "zł                              Promile: " + Gracz.promile + "\n");
            Console.WriteLine(" Wybierz jedną z opcji:" +
                "\n1.Wejdź do baru" +
                "\n2.Cholera trochę się cykam" +
                "\n3.Może się nie skapną że nie jestem pełnoletni" +
                "\n4.Masz za mało mamony? Idź do pracy!");
        }
        static void CzyAbyNapewno()
        {
            Console.Clear();
            Console.WriteLine(" To jak będzie?" +
                "\n1.Tobie nie odmówię" +
                "\n2.Nie mogę bo mama mi nie pozwala ;(" +
                "\n3.Zdecyduj za mnie");
        }
        static void WyborNapoju()
        {
            Console.Clear();
            if (Gracz.promile > 2.2)
            {
                Gracz.zgon();
                Menu();

            }
            else
            {
                Console.Write("W portfelu masz " + Gracz.WypPortfel() + "zł                              Promile: " + Gracz.promile + "\n");
                Console.Write("Żeby wytrzeźwieć, wyjdź z baru\n");

                Console.WriteLine(" Witaj! Za barem stoi: " + Nasz_bar.barman_teraz.ToString() +
                    "\nWybierz czego chcesz się dziś napić:" +
                    "\n1. Wódka" +
                    "\n2. Shot" +
                    "\n3. Napój" +
                    "\n4. Lubię niespodzianki" +
                    "\n5. Wyjdź");


                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Wódki();
                        break;
                    case "2":
                        Console.Clear();
                        Shoty();
                        break;
                    case "3":
                        Console.Clear();
                        Napoj();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Masz do wyboru 3 szklanki z wodą z wódką i spirytusem, wybierz mądrze." +
                            "\n Podaj liczbę od 1 do 3");
                        Console.ReadLine();
                        int n = Losuj(3);
                        if (n == 1)
                        {
                            Console.WriteLine("Wypiłeś szklankę wody, nic się nie stało");
                            Console.WriteLine("\n Aby kontynuować wciśnij klawisz");
                            Console.ReadKey();
                            WyborNapoju();
                        }
                        if (n == 2)
                        {
                            Gracz.ZeroPromile();
                            Console.WriteLine("Wypiłeś szklankę wódki, zaliczasz zgona. Budzisz się następnego dnia");
                            Console.WriteLine("\n Aby kontynuować wciśnij klawisz");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        if (n == 3)
                        {
                            Console.WriteLine("Wypiłeś szklankę spirytusu, spotykasz św Piotra");
                            Console.WriteLine("\n Aby kontynuować wciśnij klawisz");
                            Console.ReadKey();
                            System.Environment.Exit(0);
                        }
                        break;
                    case "5":
                        Console.Clear();
                        break;
                }
            }
        }
        static void Wódki()
        {
            Console.WriteLine("1.Czysta" +
                "\n2.Z Cytryną" +
                "\n3.Wróć");
            switch (Console.ReadLine())
            {
                case "1":
                    //czysta obiekt
                    Console.Clear();
                    NowyNapoj w = new Wodka();
                    if (Gracz.WypPortfel() < w.ObliczKoszt())
                    {
                        Console.Clear();
                        Console.WriteLine("Masz za mało hajsiku :(, idź do pracy");
                        Thread.Sleep(2300);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("{0}, płacisz {1} zł, Dochodzi do Cb {2} promila.", w.Nazwa(), w.ObliczKoszt(), w.ObliczPromile());
                        Gracz.ZmianaPortfela(-w.ObliczKoszt());
                        Gracz.ZmianaPromili(w.ObliczPromile());
                    }
                    Console.WriteLine("\n Aby kontynuować wciśnij klawisz");
                    Console.ReadKey();
                    WyborNapoju();
                    break;
                case "2":
                    //z cytrynką
                    Console.Clear();
                    NowyNapoj wZc = new Wodka();
                    wZc = new CytrynaDekorator(wZc);
                    if (Gracz.WypPortfel() < wZc.ObliczKoszt())
                    {
                        Console.Clear();
                        Console.WriteLine("Masz za mało hajsiku :(, idź do pracy");
                        Thread.Sleep(2300);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("{0}, płacisz {1} zł dochodzi do Cb {2} promila.", wZc.Nazwa(), wZc.ObliczKoszt(), wZc.ObliczPromile());
                        Gracz.ZmianaPortfela(-wZc.ObliczKoszt());
                        Gracz.ZmianaPromili(wZc.ObliczPromile());
                    }
                    Console.WriteLine("\n Aby kontynuować wciśnij klawisz");
                    Console.ReadKey();
                    WyborNapoju();
                    break;
                case "3":
                    WyborNapoju();
                    break;
            }
        }
        static void Shoty()
        {
            Console.WriteLine("1.Szybki ogier" +
                "\n2.Dance Machina" +
                "\n3.To twój koniec" +
                "\n4.6pktPLZ" +
                "\n5.Wróć");
            switch (Console.ReadLine())
            {
                case "1":
                    //szybki obiekt
                    Console.Clear();
                    NowyNapoj szybki = new Shot();
                    szybki = new SzybkiOgier(szybki);
                    if (Gracz.WypPortfel() < szybki.ObliczKoszt())
                    {
                        Console.Clear();
                        Console.WriteLine("Masz za mało hajsiku :(, idź do pracy");
                        Thread.Sleep(2300);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("{0}, płacisz {1} zł, dochodzi do Cb {2} promila.", szybki.Nazwa(), szybki.ObliczKoszt(), szybki.ObliczPromile());
                        Gracz.ZmianaPortfela(-szybki.ObliczKoszt());
                        Gracz.ZmianaPromili(szybki.ObliczPromile());
                    }

                    Console.WriteLine("\n Aby kontynuować wciśnij klawisz");
                    Console.ReadKey();
                    WyborNapoju();
                    break;
                case "2":
                    //dance obiekt
                    Console.Clear();
                    NowyNapoj dance = new Shot();
                    dance = new DanceMachina(dance);
                    if (Gracz.WypPortfel() < dance.ObliczKoszt())
                    {
                        Console.Clear();
                        Console.WriteLine("Masz za mało hajsiku :(, idź do pracy");
                        Thread.Sleep(2300);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("{0}, płacisz {1} zł", dance.Nazwa(), dance.ObliczKoszt());
                        Gracz.ZmianaPortfela(-dance.ObliczKoszt());
                        Gracz.ZmianaPromili(dance.ObliczPromile());
                    }

                    Console.WriteLine("\n Aby kontynuować wciśnij klawisz");
                    Console.ReadKey();
                    WyborNapoju();
                    break;
                case "3":
                    //koniec obiekt
                    Console.Clear();
                    NowyNapoj koniec = new Shot();
                    koniec = new ToTwojKoniec(koniec);
                    if (Gracz.WypPortfel() < koniec.ObliczKoszt())
                    {
                        Console.Clear();
                        Console.WriteLine("Masz za mało hajsiku :(, idź do pracy");
                        Thread.Sleep(2300);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("{0}, płacisz {1} zł", koniec.Nazwa(), koniec.ObliczKoszt());
                        Gracz.ZmianaPortfela(-koniec.ObliczKoszt());
                        Gracz.ZmianaPromili(koniec.ObliczPromile());
                    }

                    Console.WriteLine("\n Aby kontynuować wciśnij klawisz");
                    Console.ReadKey();
                    WyborNapoju();
                    break;
                case "4":
                    // pkt obiekt
                    Console.Clear();
                    NowyNapoj pkt = new Shot();
                    pkt = new Pkt(pkt);
                    if (Gracz.WypPortfel() < pkt.ObliczKoszt())
                    {
                        Console.Clear();
                        Console.WriteLine("Masz za mało hajsiku :(, idź do pracy");
                        Thread.Sleep(2300);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Kupujesz {0}, płacisz {1} zł", pkt.Nazwa(), pkt.ObliczKoszt());
                        Gracz.ZmianaPortfela(-pkt.ObliczKoszt());
                        Gracz.ZmianaPromili(pkt.ObliczPromile());
                    }

                    Console.WriteLine("\n Aby kontynuować wciśnij klawisz");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Dobrodzeju. Za 6pkt otrzymujesz Bar.");
                    Console.WriteLine("```````````````````````````" +
                        "\n````````¶¶¶¶¶¶````````¶¶¶¶¶¶ ´´ ´" +
                        "\n`````´´¶¶¶¶¶¶¶¶¶`````¶¶¶¶¶¶¶¶¶´´´´" +
                        "\n`````´¶¶¶¶¶¶¶¶¶¶¶¶`¶¶¶¶¶¶¶¶¶¶¶¶´´" +
                        "\n`````¶¶¶¶¶..Serduszko...¶¶¶¶¶¶¶¶´´´" +
                        "\n`````¶¶¶¶...Uśmiechu...¶¶¶¶¶¶¶¶¶ ´´´" +
                        "\n`````¶¶¶¶¶...Radości...¶¶¶¶¶¶¶¶¶´´´" +
                        "\n`````´¶¶¶¶¶...I...¶¶¶¶¶¶¶¶¶¶¶¶¶´´" +
                        "\n`````´´´¶¶¶...Przyjaźni...¶¶¶´´´" +
                        "\n`````´´´´´¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶´´" +
                        "\n`````´´´´´´´¶¶¶¶¶¶¶¶¶¶¶¶¶´´´" +
                        "\n`````´´´´´´´´´¶¶¶¶¶¶¶¶´´´" +
                        "\n`````´´´´´´´´´´´¶¶¶¶´´´");
                    //6pkt obiekt
                    //budżet + 20000
                    Thread.Sleep(2700);
                    WyborNapoju();
                    break;
                case "5":
                    WyborNapoju();
                    break;
            }
        }
        static void Napoj()
        {
            Console.WriteLine("1.Cola" +
                "\n2.Woda" +
                "\n3.Sok z Gumijagód" +
                "\n4.Wróć");
            switch (Console.ReadLine())
            {
                case "1":
                    //cola obiekt
                    Console.Clear();
                    NowyNapoj cola = new Napoj();
                    cola = new Cola(cola);
                    if (Gracz.WypPortfel() < cola.ObliczKoszt())
                    {
                        Console.Clear();
                        Console.WriteLine("Masz za mało hajsiku :(, idź do pracy");
                        Thread.Sleep(2300);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("{0}, płacisz {1} zł", cola.Nazwa(), cola.ObliczKoszt());
                        Gracz.ZmianaPortfela(-cola.ObliczKoszt());
                    }

                    Console.WriteLine("\n Aby kontynuować wciśnij klawisz");
                    Console.ReadKey();
                    WyborNapoju();

                    break;
                case "2":
                    //woda obiekt
                    Console.Clear();
                    NowyNapoj woda = new Napoj();
                    woda = new Woda(woda);
                    if (Gracz.WypPortfel() < woda.ObliczKoszt())
                    {
                        Console.Clear();
                        Console.WriteLine("Masz za mało hajsiku :(, idź do pracy");
                        Thread.Sleep(2300);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("{0}, płacisz {1} zł", woda.Nazwa(), woda.ObliczKoszt());
                        Gracz.ZmianaPortfela(-woda.ObliczKoszt());
                    }

                    Console.WriteLine("\n Aby kontynuować wciśnij klawisz");
                    Console.ReadKey();
                    WyborNapoju();
                    break;
                case "3":
                    //soczek obiekt
                    Console.Clear();
                    NowyNapoj soczek = new Napoj();
                    soczek = new SokZGumijagod(soczek);
                    if (Gracz.WypPortfel() < soczek.ObliczKoszt())
                    {
                        Console.Clear();
                        Console.WriteLine("Masz za mało hajsiku :(, idź do pracy");
                        Thread.Sleep(2300);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("{0}, płacisz {1} zł", soczek.Nazwa(), soczek.ObliczKoszt());
                        Gracz.ZmianaPortfela(-soczek.ObliczKoszt());
                    }

                    Console.WriteLine("\n Aby kontynuować wciśnij klawisz");
                    Console.ReadKey();
                    WyborNapoju();
                    break;
                case "4":
                    WyborNapoju();
                    break;
            }
        }
        static int Losuj(int n)
        {

            Random generator = new Random();
            int losuj = generator.Next(1, n + 1);
            return losuj;
        }
        static void Main()
        {
            Barman b1 = new Barman("Staszek", "Pientaszek", 20, 0.70);
            Barman b2 = new Barman("Johny", "Perfect", 30, 0.99);
            Barman b3 = new Barman("Andrzej", "Średni", 25, 0.80);
            Nasz_bar.DodajBarmana(b1);
            Nasz_bar.DodajBarmana(b2);
            Nasz_bar.DodajBarmana(b3);
            int i = 0;

            Console.Write("Podaj swoje imie:");
            string imie = "";
            imie = Console.ReadLine();

            Console.Write("Podaj swoje Nazwisko:");
            string Nazwisko = "";
            Nazwisko = Console.ReadLine();

            Console.Write("Podaj swój wiek:");
            int wiek;
            wiek = int.Parse(Console.ReadLine());

            Gracz.nowa_postac(imie, Nazwisko, wiek);
            Console.Clear();

            while (i != 20)
            {
                Menu();
                switch (Console.ReadLine())
                {
                    case "1":
                        Nasz_bar.LosujBarmana();
                        WyborNapoju();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(" Z nami się nie napijesz?");
                        Thread.Sleep(1500);
                        CzyAbyNapewno();
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("Swój chłop!!!");
                                Thread.Sleep(1500);
                                Nasz_bar.LosujBarmana();
                                WyborNapoju();
                                break;
                            case "2":
                                Console.Clear();
                                Console.WriteLine("Wracasz na następny dzień\n");
                                break;
                            case "3":
                                if (Losuj(2) == 1)
                                {
                                    Console.WriteLine("Wchodzisz do baru!!!! :)");
                                    Thread.Sleep(1500);
                                    Nasz_bar.LosujBarmana();
                                    WyborNapoju();
                                }
                                else
                                {
                                    Console.WriteLine("Pech, wychodzisz :(");
                                    Thread.Sleep(1500);
                                    System.Environment.Exit(0);
                                }
                                break;
                        }
                        break;

                    case "3":
                        Console.Clear();
                        if (Gracz.Wiek < 18)
                        {
                            Console.WriteLine(" Jendak się skapnęli");
                            Console.WriteLine(" Wypadasz z Baru!");
                            Thread.Sleep(1500);
                            System.Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Nie żartuj sobie, Wchodzisz ;) ");
                            Thread.Sleep(1500);
                            Nasz_bar.LosujBarmana();
                            WyborNapoju();
                        }
                        break;


                    case "4":
                        Console.Clear();
                        Console.WriteLine("Dostałeś Pracę: " +
                                    "\nPomoc Panoramixowi przy tworzeniu Magicznego Napoju");

                        Console.WriteLine("\nPanoramix zdradził Ci skład magicznego napoju:" +
                                    "\nJemioła, Korzenie, Homar, Czterolistna Koniczyna, Ryba" +
                                    "\nMarchew, Ropa Naftowa, Sól");

                        Console.WriteLine("\nTwoim zadaniem jest zdobyć Czterolistną Koniczynę," +
                                    "\nkupić Świeżą Rybę(Pamiętaj, byle nie u Ahigieniksa)" +
                                    "\ni pozbierać Marchew (przynajmniej 4) ");
                        Console.WriteLine("\nWciśnij klawisz kiedy będziesz gotowy");
                        Console.ReadKey();
                        Console.Clear();
                        static void Wypisz(int x)
                        {
                            if (x == 1)
                            {
                                Console.WriteLine("\n2.Kup rybę u Ahigeniksa" +
                                    "\n3.Sam złów rybę");
                            }
                            else if (x == 2)
                            {
                                Console.WriteLine("\n1.Zbieraj marchew" +
                                      "\n3.Sam złów rybę");
                            }
                            else if (x == 3)
                            {
                                Console.WriteLine("\n1.Zbieraj marchew" +
                                    "\n2.Kup rybę u Ahigeniksa");
                            }
                            else
                            {
                                Console.WriteLine("\n1.Zbieraj marchew" +
                                      "\n2.Kup rybę u Ahigeniksa" +
                                      "\n3.Sam złów rybę");
                            }
                        }

                        Wypisz(4);
                        int x = 1;
                        while (x <= 2)
                        {
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    int suma = 1;
                                    while (suma <= 4)
                                    {
                                        if (4 - suma == 0)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Jeszcze {0} (Wciśnij klawisz)", 4 - suma);
                                            Console.ReadKey();
                                            suma += 1;
                                        }
                                    }
                                    Console.WriteLine("Zdobyłeś już wszystkie (Aby kontynuować wciśnij klawisz) ");
                                    Console.ReadKey();
                                    Console.Clear();
                                    x++;
                                    if (x > 2)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Wypisz(1);
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("Ale Panoramix się wkurzy..., może powininienem jednak sam złowić rybę?");
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Brawo Ja!");
                                    x++;
                                    if (x > 2)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Wypisz(3);
                                    }
                                    break;
                            }

                        }
                        Console.Clear();
                        Console.WriteLine("\nUdało Ci się wykonać zadanie! Zyskujesz + 10 zł");
                        Gracz.ZmianaPortfela(10);
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }

                i++;
            }
            Console.WriteLine("Twoja wątroba nie wytrzymała");
        }
    }

    public static class Nasz_bar
    {

        public static List<Barman> barmani = new List<Barman>();
        public static Barman barman_teraz;

        public static void DodajBarmana(Barman b)
        {
            barmani.Add(b);
        }

        public static void LosujBarmana()
        {
            Random generator = new Random();
            int losuj = generator.Next(0, barmani.Count);
            barman_teraz = barmani[losuj];

        }
    }

    abstract public class Osoba
    {
        public string Imie;
        public string Nazwisko;
        public double wiek;

        public Osoba(string imie, string nazwisko, double wiek)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.wiek = wiek;
        }

    }
    static class Gracz
    {
        static public string Imie;
        static public string Nazwisko;
        static public int Wiek;
        private static double portfel = 25.0;
        static public double promile =
            0.0;

        static public void nowa_postac(string imie, string nazwisko, int wiek)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
        }
        static public void ZmianaPortfela(double ile)
        {
            portfel += ile;

        }
        static public double WypPortfel()
        {
            return portfel;

        }
        static public void ZmianaPromili(double ile)
        {
            promile += ile;

        }
        static public void ZeroPromile()
        {
            promile = 0;

        }
        static public void zgon()
        {
            Console.WriteLine("No to poleciałeś.....");
            Thread.Sleep(1000);
            Console.WriteLine("Tyyyle wczoraj wypiłeś ,że zaliczyłeś zgona. " +
                "\nBudzisz się caaaały obolały w swoim łóżku następnego dnia. " +
                "\nNie wstyd Ci??!");
            Console.WriteLine("\nAby przejść dalej, naciśnij kalwisz");
            Console.ReadKey();
            Console.Clear();
        }

    }

    public class Barman : Osoba
    {
        double szansa;
        public Barman(string imie, string nazwisko, int wiek, double szansa) : base(imie, nazwisko, wiek)
        {
            this.szansa = szansa;
        }
        public override string ToString()
        {
            return this.Imie + " " + this.Nazwisko;
        }

    }
    public abstract class NowyNapoj
    {
        public abstract double ObliczKoszt();
        public abstract string Nazwa();
        public abstract double ObliczPromile();

    }
    public class Wodka : NowyNapoj
    {
        public override double ObliczKoszt()
        {
            return 4;
        }
        public override string Nazwa()
        {
            return "Kieliszek Wódeczki dla szefa";
        }
        public override double ObliczPromile()
        {
            return 0.5;
        }

    }
    public class Shot : NowyNapoj
    {
        public override double ObliczKoszt()
        {
            return 6;
        }
        public override string Nazwa()
        {
            return "Shocik dla szefa";
        }
        public override double ObliczPromile()
        {
            return 0.3;
        }
    }
    public class Napoj : NowyNapoj
    {
        public override double ObliczKoszt()
        {
            return 5;
        }
        public override string Nazwa()
        {
            return "Napój";
        }
        public override double ObliczPromile()
        {
            return 0.0;
        }

    }
    public class NapojeDekorator : NowyNapoj
    {
        protected NowyNapoj _napoje;
        public NapojeDekorator(NowyNapoj napoje)
        {
            _napoje = napoje;
        }
        public override double ObliczKoszt()
        {
            return _napoje.ObliczKoszt();
        }
        public override string Nazwa()
        {
            return _napoje.Nazwa();
        }
        public override double ObliczPromile()
        {
            return _napoje.ObliczPromile();
        }
    }
    //do wodeczki
    public class CytrynaDekorator : NapojeDekorator
    {
        public CytrynaDekorator(NowyNapoj napoje) : base(napoje)
        {
        }
        public override double ObliczKoszt()
        {
            return _napoje.ObliczKoszt() + 0.50;
        }
        public override string Nazwa()
        {
            return _napoje.Nazwa() + " ,z Cytryną";
        }
        public override double ObliczPromile()
        {
            return _napoje.ObliczPromile() - 0.05;
        }
    }
    //shoty
    public class SzybkiOgier : NapojeDekorator
    {
        public SzybkiOgier(NowyNapoj napoje) : base(napoje)
        {
        }
        public override double ObliczKoszt()
        {
            return _napoje.ObliczKoszt();
        }
        public override string Nazwa()
        {
            return _napoje.Nazwa() + " ,Szybki Ogier";
        }
        public override double ObliczPromile()
        {
            return _napoje.ObliczPromile() + 0.05;
        }
    }
    public class DanceMachina : NapojeDekorator
    {
        public DanceMachina(NowyNapoj napoje) : base(napoje)
        {
        }
        public override double ObliczKoszt()
        {
            return _napoje.ObliczKoszt();
        }
        public override string Nazwa()
        {
            return _napoje.Nazwa() + " ,Dance Machina";
        }
        public override double ObliczPromile()
        {
            return _napoje.ObliczPromile() + 0.1;
        }
    }
    public class ToTwojKoniec : NapojeDekorator
    {
        public ToTwojKoniec(NowyNapoj napoje) : base(napoje)
        {
        }
        public override double ObliczKoszt()
        {
            return _napoje.ObliczKoszt();
        }
        public override string Nazwa()
        {
            return _napoje.Nazwa() + " ,To twój koniec";
        }
        public override double ObliczPromile()
        {
            return _napoje.ObliczPromile() + 0.3;
        }
    }
    public class Pkt : NapojeDekorator
    {
        public Pkt(NowyNapoj napoje) : base(napoje)
        {
        }
        public override double ObliczKoszt()
        {
            return _napoje.ObliczKoszt();
        }
        public override string Nazwa()
        {
            return _napoje.Nazwa() + " ,Dobry wybór";
        }
        public override double ObliczPromile()
        {
            return _napoje.ObliczPromile() + 0.05;
        }
    }
    // napoje
    public class Cola : NapojeDekorator
    {
        public Cola(NowyNapoj napoje) : base(napoje)
        {
        }
        public override double ObliczKoszt()
        {
            return _napoje.ObliczKoszt();
        }
        public override string Nazwa()
        {
            return _napoje.Nazwa() + " ,Cola, bez Koki HEH";
        }
    }
    public class Woda : NapojeDekorator
    {
        public Woda(NowyNapoj napoje) : base(napoje)
        {
        }
        public override double ObliczKoszt()
        {
            return _napoje.ObliczKoszt();
        }
        public override string Nazwa()
        {
            return _napoje.Nazwa() + " ,Woda";
        }
    }
    public class SokZGumijagod : NapojeDekorator
    {
        public SokZGumijagod(NowyNapoj napoje) : base(napoje)
        {
        }
        public override double ObliczKoszt()
        {
            return _napoje.ObliczKoszt();
        }
        public override string Nazwa()
        {
            return _napoje.Nazwa() + " ,sok z gumijagód";
        }
    }

}
