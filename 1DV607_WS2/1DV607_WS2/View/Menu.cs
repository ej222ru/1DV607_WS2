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
        private BoatMenu boatMenu;

        public Menu()
        {
            boatMenu = new BoatMenu();
        }
        public int mainMenu()
        {
            ConsoleKeyInfo cki;
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Välj funktion: ");
                    Console.WriteLine("  1   -  skapa en medlem");
                    Console.WriteLine("  2  -   uppdatera medlem");
                    Console.WriteLine("  3  -   visa medlem");
                    Console.WriteLine("  4   -  ta bort medlem");
                    Console.WriteLine("");
                    Console.WriteLine("  5   -  lägg till båt");
                    Console.WriteLine("  6   -  uppdatera båt");
                    Console.WriteLine("  7   -  ta bort båt");
                    Console.WriteLine("");
                    Console.WriteLine("  8   -  om du vill lista medlemmar");
                    Console.WriteLine("  9   -  om du vill lista medlemmar utförligt");
                    Console.WriteLine("");
                    Console.WriteLine("  Esc - avslutar.");
                    Console.WriteLine("");
                    cki = Console.ReadKey(true);
                    Console.Clear();
                    switch (cki.Key)
                    {
                        case ConsoleKey.D1:
                           {
                                return 1;
                           }
                        case ConsoleKey.D2:
                            {
                                return 2;
                            }
                        case ConsoleKey.D3:
                            {
                                return 3;
                            }
                        case ConsoleKey.D4:
                            {
                                return 4;
                            }
                        case ConsoleKey.D5:
                            {
                                return 5;
                            }
                        case ConsoleKey.D6:
                            {
                                return 6;
                            }
                        case ConsoleKey.D7:
                            {
                                return 7;
                            }
                        case ConsoleKey.D8:
                            {
                                return 8;
                            }
                        case ConsoleKey.D9:
                            {
                                return 9;
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

                    };
                }
                while (true);
                return 0;
            }
            catch
            {
                // do nothing
            }
            return 0;
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

//*********************
        public BoatBLL createBoatMenu(int memberId)
        {
            return boatMenu.createBoatMenu(memberId);
        }

        public BoatBLL selectBoatMenu(IEnumerable<BoatBLL> boats)
        {
            return boatMenu.selectBoatMenu(boats);
        }

        public BoatBLL updateBoatMenu(BoatBLL boat)
        {
            boatMenu.showBoat(boat);
            return boatMenu.updateBoatMenu(boat);
        }






        public void boatCreatedMenu(BoatBLL boat, bool succeeded = true)
        {
            boatMenu.boatCreatedMenu(boat, succeeded);
        }
        public void boatUpdatedMenu(BoatBLL boat, bool succeeded = true)
        {
            boatMenu.boatUpdatedMenu(boat, succeeded);
        }
        public void boatDeletedMenu(BoatBLL boat, bool succeeded = true)
        {
            boatMenu.boatDeletedMenu(boat, succeeded);
        }

//*****************

        public void memberCreatedMenu(MemberBLL member)
        {
            Console.WriteLine("****  You created member ****\n");
            showMember(member);
            pressKeyToContinue();
        }
        public void memberUpdatedMenu(MemberBLL member, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  You updated member ****\n");
                showMember(member);
            }
            else
            {
                Console.WriteLine("****  Member update failed ****\n");
                Console.WriteLine("Member Id:  " + member.MemberId);

            }
            pressKeyToContinue();
        }
        public void showMemberMenu(MemberBLL member, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  member ****\n");
                showMember(member);
            }
            else
            {
                Console.WriteLine("****  Member info not found ****\n");
                Console.WriteLine("Member Id:  " + member.MemberId);

            }
            pressKeyToContinue();
        }
        public void memberDeletedMenu(int memberId, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  member deleted ****\n");
                Console.WriteLine("Member Id:  " + memberId);
            }
            else
            {
                Console.WriteLine("****  Member could not be deleted ****\n");
                Console.WriteLine("Member Id:  " + memberId);
            }
            pressKeyToContinue();
        }


//************
        public void showMember(MemberBLL member)
        {
                Console.WriteLine("Member Id:  " + member.MemberId);
                Console.WriteLine("First name: " + member.FirstName);
                Console.WriteLine("Last name:  " + member.LastName);
                Console.WriteLine("SSN:        " + member.SSN);
        }
        public void showMemberList(IEnumerable<MemberBLL> members, IEnumerable<BoatBLL> boats)
        {
            Console.WriteLine("****  Members ****\n");
            int noOfBoats = 0;
            foreach (MemberBLL member in members)
            {
                noOfBoats = 0;
                foreach (BoatBLL boat in boats)
                {
                    if (member.MemberId == boat.MemberId)
                        noOfBoats++;
                }
                Console.WriteLine("MemberId:" + member.MemberId + " " + member.FirstName + " " + member.LastName + "  Boats: " + noOfBoats);
            }
            pressKeyToContinue();
        }
        public void showMemberListVerbose(IEnumerable<MemberBLL> members, IEnumerable<BoatBLL> boats)
        {
            Console.WriteLine("****  Members ****\n");
            int noOfBoats = 0;
            foreach (MemberBLL member in members)
            {
                noOfBoats = 0;
                Console.WriteLine("\nMemberId:" + member.MemberId + " " + member.FirstName + " " + member.LastName + "  SSN: " + member.SSN);
                foreach (BoatBLL boat in boats)
                {
                    if (member.MemberId == boat.MemberId)
                        boatMenu.showBoatRow(boat, ++noOfBoats);
                }
            }
            pressKeyToContinue();
        }
 
 
 //************
        public static string readLine(string text, bool mandatory = true)
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

        public static int? readInt(string text, bool mandatory = true)
        {
            int intInput;
            int? ret = null;
            bool done = false;
            String input;
            do
            {
                input = readLine(text, mandatory);

                if (Int32.TryParse(input, out intInput))
                {
                    ret = intInput;
                    done = true;
                }
                else
                {
                    if (mandatory)
                    {
                        Console.Write("You have to enter an integer number!");
                        pressKeyToContinue();
                    }
                    else if (String.IsNullOrWhiteSpace(input))
                    {

                        done = true;
                    }
                }
            }
            while (!done);

            return ret;
        }



        public static void pressKeyToContinue()
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
