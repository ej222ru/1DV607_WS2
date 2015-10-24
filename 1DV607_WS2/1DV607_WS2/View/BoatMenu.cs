using _1DV607_WS2.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_WS2.View
{
    public class BoatMenu
    {
        public BoatBLL CreateBoatMenu(string SSN, BoatBLL boat)
        {
            BoatType boatType = CreateBoatTypeMenu();
            int length = (int)Menu.ReadInt("Boat length: ");

            boat.SSN = SSN;
            boat.BoatType = boatType;
            boat.BoatLength = length;

            return boat;
        }


        public BoatType CreateBoatTypeMenu()
        {
// public enum BoatType {Sailboat=1, Motorsailer, kayak_Canoe, Other};
            BoatType ret = 0;
            bool done = true;
            do
            {
                done = true;
                ConsoleKeyInfo cki;
                Console.WriteLine("");
                Console.WriteLine("select boat type: ");
                Console.WriteLine("  1   -  Sailboat");
                Console.WriteLine("  2  -   Motorsailer");
                Console.WriteLine("  3  -   Kayak/Canoe");
                Console.WriteLine("  4   -  Other");
                Console.WriteLine("");
                cki = Console.ReadKey(true);
                Console.Clear();

                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        {
                            ret = BoatType.Sailboat;
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            ret = BoatType.Motorsailer;
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            ret = BoatType.kayak_Canoe;
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            ret = BoatType.Other;
                            break;
                        }
                    default :
                        {
                            Console.WriteLine("You have to select a menualternative <1-4>");
                            Menu.PressKeyToContinue();
                            done = false;
                            break;
                        };
                }
            }
            while (!done);

            return ret;
        }
        private string TranslateBoatType(BoatType boatType)
        {
            string ret="";
            switch (boatType)
            {
                case BoatType.Sailboat:
                    {
                        ret = "Sailboat";
                        break;
                    }
                case BoatType.Motorsailer:
                    {
                        ret = "Motorsailer";
                        break;
                    }
                case BoatType.kayak_Canoe:
                    {
                        ret = "Kayak/Canoe";
                        break;
                    }
                case BoatType.Other:
                    {
                        ret = "Other";
                        break;
                    }
            }
            return ret;
        }

        public void ShowBoat(BoatBLL boat)
        {
            Console.WriteLine("Boat Id: " + boat.BoatId);
            Console.WriteLine("Owner: " + boat.SSN);
            Console.WriteLine("BoatType: " + TranslateBoatType(boat.BoatType));
            Console.WriteLine("BoatLength: " + boat.BoatLength);
        }
        public void ShowBoatRow(BoatBLL boat, int index)
        {
            Console.WriteLine("  " + index + "   -  " + "BoatId: " + boat.BoatId + "  Owner: " + boat.SSN + "  BoatType: " + TranslateBoatType(boat.BoatType) + "  Boat length: " + boat.BoatLength);
        }
        public BoatBLL SelectBoatMenu(IEnumerable<BoatBLL> boats)
        {
            bool done = false;
            int ret = 0;
            ConsoleKeyInfo cki;
            BoatBLL[] boatArray = boats.Cast<BoatBLL>().ToArray(); // make an array variable of the Ienumerable so I can get one specific item

            do
            {
                Console.WriteLine("");
                Console.WriteLine("select boat to update/delete: ");
                int index = 1;
                foreach (BoatBLL boat in boats)
                {
                    ShowBoatRow(boat, index++);
                }
                cki = Console.ReadKey(true);
                Console.Clear();
                ret = (int)(cki.KeyChar - 48);  // get the integer value corresponding to the char
                if (ret <= boatArray.Length && ret > 0) 
                    done = true;
                else
                {
                    Console.WriteLine("You must select a valid value");
                    Menu.PressKeyToContinue();
                }
            }
            while (!done);

            return boatArray[ret-1];
        }
        public BoatBLL UpdateBoatMenu(BoatBLL boat)
        {
            Console.WriteLine("Just press ENTER for fields you don't want to change");

            string SSN = Menu.ReadLine("Owner SSN: ", false);
            int? boatType;

            bool done = false;
            do
            {
                Console.WriteLine("press 1 for " + TranslateBoatType(BoatType.Sailboat));
                Console.WriteLine("press 2 for " + TranslateBoatType(BoatType.Motorsailer));
                Console.WriteLine("press 3 for " + TranslateBoatType(BoatType.kayak_Canoe));
                Console.WriteLine("press 4 for " + TranslateBoatType(BoatType.Other));
                Console.WriteLine("or ENTER to leave it unchanged ");

                boatType = Menu.ReadInt("Boat Type: ", false);
                if (boatType > 0 && boatType < 5 || boatType == null)
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("You have to select a menualternative <1-4>");
                    Menu.PressKeyToContinue();
                }
            }
            while (!done);

            int?  boatLength = Menu.ReadInt("Boat length: ", false);
            if (SSN != null && SSN != "")
                boat.SSN = SSN;
            if (boatType != null)
                boat.BoatType = (BoatType)boatType;
            if (boatLength != null)
                boat.BoatLength = (int)boatLength;
            return boat;
        }

//****************
        public void BoatCreatedMenu(BoatBLL boat, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  You registered a boat ****\n");
                ShowBoat(boat);
            }
            else
            {
                Console.WriteLine("****  Boat could not be registered ****\n");

            }
            Menu.PressKeyToContinue();
        }
        public void BoatUpdatedMenu(BoatBLL boat, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  You updated a boat ****\n");
                ShowBoat(boat);
            }
            else
            {
                Console.WriteLine("****  Boat update failed ****\n");
                Console.WriteLine("Owner SSN: " + boat.SSN + "  BoatId: " + boat.BoatId);

            }
            Menu.PressKeyToContinue();
        }
        public void BoatDeletedMenu(BoatBLL boat, MemberBLL member, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  You deleted a boat ****\n");
                Console.WriteLine("For Owner SSN: " + member.SSN);
            }
            else
            {
                Console.WriteLine("****  Boat delete failed ****\n");
                if (boat.BoatId == 0)
                {
                    Console.WriteLine("Owner SSN: " + member.SSN + " doesn't have a boat registered ");
                }
                else
                {
                    Console.WriteLine("Owner SSN: " + member.SSN + "  BoatId: " + boat.BoatId);
                }
            }
            Menu.PressKeyToContinue();
        }
        public void ShowBoatMenu(BoatBLL boat, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  boat ****\n");
                ShowBoat(boat);
            }
            else
            {
                Console.WriteLine("****  Boat info not found ****\n");
                Console.WriteLine("Owner SSN:  " + boat.SSN + "Boat Id:" + boat.BoatId);

            }
            Menu.PressKeyToContinue();
        }

    }
}
