using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_WS2.View
{
    class MainMenu
    {

        public void mainMenu()
        {
            ConsoleKeyInfo cki;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Välj funktion: ");
                    Console.WriteLine("  1   -  skapa en medlem");
                    Console.WriteLine("  2  -   uppdatera medlem");
                    Console.WriteLine("  3   -  ta bort medlem");
                    Console.WriteLine("");
                    Console.WriteLine("  4   -  lägg till båt");
                    Console.WriteLine("  5   -  uppdatera båt");
                    Console.WriteLine("  6   -  ta bort båt");
                    Console.WriteLine("");
                    Console.WriteLine("  7   -  om du vill lista medlemmar");
                    Console.WriteLine("  8   -  om du vill lista medlemmar utförligt");
                    Console.WriteLine("");
                    Console.WriteLine("  Esc - avslutar.");
                    Console.WriteLine("");
                    cki = Console.ReadKey(true);
                    Console.Clear();

                    switch (cki.Key)
                    {
                        case ConsoleKey.D1:
                            {
                                createMemberMenu();
                                break;
                            }
                        case ConsoleKey.D2:
                            {
                                break;
                            }
                        case ConsoleKey.D3:
                            {
                                break;
                            }
                        case ConsoleKey.D4:
                            {
                                break;
                            }
                        case ConsoleKey.D5:
                            {
                                break;
                            }
                        case ConsoleKey.D6:
                            {
                                break;
                            }
                        case ConsoleKey.D7:
                            {
                                break;
                            }
                        case ConsoleKey.D8:
                            {
                                break;
                            }
                        case ConsoleKey.Escape:
                            {
                                return;
                            }
                        default :
                            {
                                Console.WriteLine("Du måste välja ett tillgängligt menyalternativ <1-8> eller ESC");
                                pressKeyToContinue();
                                break;
                            };
                    }
                }
                catch
                {
                    // do nothing
                }
            }
            while (true);
        }


        private void createMemberMenu()
        {
            string fName = readLine("Förnamn: ");

        }

        private string readLine(string text, bool mandatory = true)
        {
            bool done = false;
            String input;
            do
            {
                Console.WriteLine("");
                Console.Write(text);
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.Write("Du måste mata in något!");
                    pressKeyToContinue();
                }
                else
                {
                    done = true;
                }
            }
            while (!done);
            return input;
        }

        void pressKeyToContinue()
        {
            Console.WriteLine("");
            Console.WriteLine("Tryck valfri tangent för att fortsätta");
            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            switch (cki.Key)
            {
                default:
                    return;
            }
        }

    }
}
