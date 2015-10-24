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
        public enum UserAction {EndSession, CreateMember, UpdateMember, ViewMember, DeleteMember, RegisterBoat, UpdateBoat, DeleteBoat, ListMembers, ListMembersVerbose};
        private MemberMenu memberMenu;
        private BoatMenu boatMenu;

        public Menu()
        {
            this.boatMenu = new BoatMenu();
            this.memberMenu = new MemberMenu(this.boatMenu);
        }
        public UserAction mainMenu()
        {
            ConsoleKeyInfo cki;
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Select function: ");
                    Console.WriteLine("  1   -  create a member");
                    Console.WriteLine("  2  -   update member");
                    Console.WriteLine("  3  -   view member");
                    Console.WriteLine("  4   -  delete member");
                    Console.WriteLine("");
                    Console.WriteLine("  5   -  register boat");
                    Console.WriteLine("  6   -  update boat");
                    Console.WriteLine("  7   -  delete boat");
                    Console.WriteLine("");
                    Console.WriteLine("  8   -  list members");
                    Console.WriteLine("  9   -  list members verbose");
                    Console.WriteLine("");
                    Console.WriteLine("  Esc - end session.");
                    Console.WriteLine("");
                    cki = Console.ReadKey(true);
                    Console.Clear();
                    switch (cki.Key)
                    {
                        case ConsoleKey.D1:
                           {
                               return UserAction.CreateMember;
                           }
                        case ConsoleKey.D2:
                            {
                                return UserAction.UpdateMember;
                            }
                        case ConsoleKey.D3:
                            {
                                return UserAction.ViewMember;
                            }
                        case ConsoleKey.D4:
                            {
                                return UserAction.UpdateMember;
                            }
                        case ConsoleKey.D5:
                            {
                                return UserAction.RegisterBoat;
                            }
                        case ConsoleKey.D6:
                            {
                                return UserAction.UpdateBoat;
                            }
                        case ConsoleKey.D7:
                            {
                                return UserAction.DeleteBoat;
                            }
                        case ConsoleKey.D8:
                            {
                                return UserAction.ListMembers;
                            }
                        case ConsoleKey.D9:
                            {
                                return UserAction.ListMembersVerbose;
                            }
                        case ConsoleKey.Escape:
                            {
                                return UserAction.EndSession;
                            }
                        default :
                            {
                                Console.WriteLine("Select available menu option <1-9> or ESC");
                                PressKeyToContinue();
                                break;
                            };

                    };
                }
                while (true);
            }
            catch
            {
                // do nothing
            }
            return 0;
        }

//********************* Boat stuff 
        public BoatBLL CreateBoatMenu(string SSN, BoatBLL boat)
        {
            return boatMenu.CreateBoatMenu(SSN, boat);
        }

        public BoatBLL SelectBoatMenu(IEnumerable<BoatBLL> boats)
        {
            return boatMenu.SelectBoatMenu(boats);
        }

        public BoatBLL UpdateBoatMenu(BoatBLL boat)
        {
            boatMenu.ShowBoat(boat);
            return boatMenu.UpdateBoatMenu(boat);
        }

        public void BoatCreatedMenu(BoatBLL boat, bool succeeded = true)
        {
            boatMenu.BoatCreatedMenu(boat, succeeded);
        }
        public void BoatUpdatedMenu(BoatBLL boat, bool succeeded = true)
        {
            boatMenu.BoatUpdatedMenu(boat, succeeded);
        }
        public void BoatDeletedMenu(BoatBLL boat, bool succeeded = true)
        {
            boatMenu.BoatDeletedMenu(boat, succeeded);
        }

//***************** Member stuff
        public MemberBLL CreateMemberMenu(MemberBLL member)
        {
            return memberMenu.CreateMemberMenu(member);
        }
        public string GetMemberMenu()
        {
            return memberMenu.GetMemberMenu();
        }
        public MemberBLL UpdateMemberMenu(MemberBLL member)
        {
            return memberMenu.UpdateMemberMenu(member);
        }
        public void ShowMemberList(IEnumerable<MemberDetailsBLL> memberDetails)
        {
            memberMenu.ShowMemberList(memberDetails);
        }

        public void ShowMemberListVerbose(IEnumerable<MemberDetailsBLL> memberDetails)
        {
            memberMenu.ShowMemberListVerbose(memberDetails);
        }


        public void MemberCreatedMenu(MemberBLL member)
        {
            Console.WriteLine("****  You created member ****\n");
            memberMenu.ShowMember(member);
            PressKeyToContinue();
        }
        public void MemberUpdatedMenu(MemberBLL member, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  You updated member ****\n");
                memberMenu.ShowMember(member);
            }
            else
            {
                Console.WriteLine("****  Member update failed ****\n");
                Console.WriteLine("Member SSN:  " + member.SSN);

            }
            PressKeyToContinue();
        }
        public void ShowMemberMenu(MemberBLL member, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  member ****\n");
                memberMenu.ShowMember(member);
            }
            else
            {
                Console.WriteLine("****  Member info not found ****\n");
                Console.WriteLine("Member SSN:  " + member.SSN);

            }
            PressKeyToContinue();
        }
        public void MemberDeletedMenu(string SSN, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  member deleted ****\n");
                Console.WriteLine("Member SSN:  " + SSN);
            }
            else
            {
                Console.WriteLine("****  Member could not be deleted ****\n");
                Console.WriteLine("Member SSN:  " + SSN);
            }
            PressKeyToContinue();
        }


//************

        

        /* 
         *  A few generic help methods
         */
        public static string ReadLine(string text, bool mandatory = true)
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
                    PressKeyToContinue();
                }
                else
                {
                    done = true;
                }
            }
            while (!done);
            return input;
        }

        public static int? ReadInt(string text, bool mandatory = true)
        {
            int intInput;
            int? ret = null;
            bool done = false;
            String input;
            do
            {
                input = ReadLine(text, mandatory);

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
                        PressKeyToContinue();
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

        public static void PressKeyToContinue()
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
