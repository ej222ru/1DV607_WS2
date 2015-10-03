using _1DV607_WS2.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_WS2.View
{
    public class Menu
    {

        public int mainMenu()
        {
            int ret = 0;

            ConsoleKeyInfo cki;
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
                            ret = 1;
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            ret = 2;
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
                            return 0;
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
            return ret;
        }


        public MemberBLL createMemberMenu()
        {
            string fName = readLine("First name: ");
            string lName = readLine("Last name: ");
            string SSN = readLine("SSN: ");

            MemberBLL member = new MemberBLL();
            member.FirstName = fName;
            member.LastName = lName;
            member.SSN = SSN;

            return member;
        }

        public int getMemberMenu()
        {
            int memberId;
            bool done = false;
            String input;
            do
            {
                input = readLine("Enter member id: ");
                if (Int32.TryParse(input, out memberId))
                    done = true;
                else
                {
                    Console.Write("You have to enter member id as intger numbers!");
                    pressKeyToContinue();
                }
            }
            while (!done);

            return memberId;
        }        
        public MemberBLL updateMemberMenu(MemberBLL member)
        {


            Console.WriteLine("First name: " + member.FirstName);
            Console.WriteLine("Last name: " + member.LastName);
            Console.WriteLine("SSN: " + member.SSN);

            Console.WriteLine("Just press ENTER for fields you don't want to change");

            string fName = readLine("First name: ", false);
            string lName = readLine("Last name: ", false);
            string SSN = readLine("SSN: ", false);
            if (fName != "")
                member.FirstName = fName;
            if (lName != "")
                member.LastName = lName;
            if (SSN != "")
                member.SSN = SSN;
            return member;
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
                if (mandatory && String.IsNullOrWhiteSpace(input))
                {
                    Console.Write("You have to enter something!");
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
            Console.WriteLine("Press any key to continue");
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
