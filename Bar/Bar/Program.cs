using System;
using System.Threading;

namespace Bar
{
    class Program
    {
        static void menu()
        {
            Console.WriteLine(" Witamy w barze!");
            Console.WriteLine(" Wybierz jedną z opcji:" +
                "\n1.Wejdź do baru" +
                "\n2.Cholera trochę się cykam" +
                "\n3.Może się nie skapną że nie jestem pełnoletni");
        }
        static void CzyAbyNapewno()
        {
            Console.Clear();
            Console.WriteLine(" To jak będzie?" +
                "\n1.Tobie nie odmówię" +
                "\n2.Nie mogę bo mama mi nie pozwala ;(" +
                "\n3.Zdecyduj za mnie");
        }
        static void wyborNapoju()
        {
            Console.Clear();
            Console.WriteLine(" Witaj! Za barem stoi: ????" +
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
                    int n = losuj(3);
                    if(n == 1)
                    {
                        Console.WriteLine("Wypiłeś szklankę wody, nic się nie stało");
                        Thread.Sleep(2200);
                        wyborNapoju();
                    }
                    if(n == 2)
                    {
                        Console.WriteLine("Wypiłeś szklankę wódki, zaliczasz zgona. Budzisz się następnego dnia");
                        Thread.Sleep(2200);
                        Console.Clear();
                    }
                    if(n == 3)
                    {
                        Console.WriteLine("Wypiłeś szklankę spirytusu, spotykasz św Piotra");
                        Thread.Sleep(5000);
                        System.Environment.Exit(0);
                    }
                    break;
                case "5":
                    Console.Clear();
                    break;
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
                    wyborNapoju();
                    break;
                case "2":
                    //z cytrynką
                    wyborNapoju();
                    break;
                case "3":
                    wyborNapoju();
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
                    wyborNapoju();
                    break;
                case "2":
                    //dance obiekt
                    wyborNapoju();
                    break;
                case "3":
                    //koniec obiekt
                    wyborNapoju();
                    break;
                case "4":
                    Console.WriteLine("Dobrodzejuuu... .Za 6pkt otrzymujesz Bar.");
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
                    Thread.Sleep(2600);
                    wyborNapoju();
                    break;
                case "5":
                    wyborNapoju();
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
                    wyborNapoju();
                    break;
                case "2":
                    //woda obiekt
                    wyborNapoju();
                    break;
                case "3":
                    //soczek obiekt
                    wyborNapoju();
                    break;
                case "4":
                    wyborNapoju();
                    break;
            }
        }
        static int losuj(int n)
        {

            Random generator = new Random();
            int losuj = generator.Next(1, n + 1);
            return losuj;
        }
        static void Main()
        {
            int i = 0;
            while (i != 30)
            {
                menu();
                switch (Console.ReadLine())
                {
                    case "1":
                        wyborNapoju();
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
                                wyborNapoju();
                                break;
                            case "2":
                                Console.WriteLine("dzien++");
                                menu();
                                break;
                            case "3":
                                if (losuj(2) == 1)
                                {
                                    Console.WriteLine("Wchodzisz do baru!!!! :)");
                                    Thread.Sleep(1500);
                                    wyborNapoju();
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
                        Console.WriteLine(" Jendak się skapnęli");
                        Console.WriteLine(" Wypadasz z Baru!");
                        Thread.Sleep(1500);
                        System.Environment.Exit(0);
                        break;
                }

                i++;
            }
            Console.WriteLine("Twoja wątroba nie wytrzymała");
        }
    }
    
}
