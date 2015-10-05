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
        public BoatBLL createBoatMenu(int memberId, BoatBLL boat)
        {
            BoatType boatType = createBoatTypeMenu();
            int length = (int)Menu.readInt("Boat length: ");

            boat.MemberId = memberId;
            boat.BoatType = boatType;
            boat.BoatLength = length;

            return boat;
        }


        public BoatType createBoatTypeMenu()
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
                            Menu.pressKeyToContinue();
                            done = false;
                            break;
                        };
                }
            }
            while (!done);

            return ret;
        }
        private string translateBoatType(BoatType boatType)
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

        public void showBoat(BoatBLL boat)
        {
            Console.WriteLine("Boat Id: " + boat.BoatId);
            Console.WriteLine("Member Id: " + boat.MemberId);
            Console.WriteLine("BoatType: " + translateBoatType(boat.BoatType));
            Console.WriteLine("BoatLength: " + boat.BoatLength);
        }
        public void showBoatRow(BoatBLL boat, int index)
        {
            Console.WriteLine("  " + index + "   -  " + "BoatId: " + boat.BoatId + "  MemberId: " + boat.MemberId + "  BoatType: " + translateBoatType(boat.BoatType) + "  Boat length: " + boat.BoatLength);
        }
        public BoatBLL selectBoatMenu(IEnumerable<BoatBLL> boats)
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
                    showBoatRow(boat, index++);
                }
                cki = Console.ReadKey(true);
                Console.Clear();
                ret = (int)(cki.KeyChar - 48);  // get the integer value corresponding to the char
                if (ret <= boatArray.Length && ret > 0) 
                    done = true;
                else
                {
                    Console.WriteLine("You must select a valid value");
                    Menu.pressKeyToContinue();
                }
            }
            while (!done);

            return boatArray[ret-1];
        }
        public BoatBLL updateBoatMenu(BoatBLL boat)
        {
            Console.WriteLine("Just press ENTER for fields you don't want to change");

            int? memberId = Menu.readInt("memberId: ", false);
            int? boatType;

            bool done = false;
            do
            {
                Console.WriteLine("press 1 for " + translateBoatType(BoatType.Sailboat));
                Console.WriteLine("press 2 for " + translateBoatType(BoatType.Motorsailer));
                Console.WriteLine("press 3 for " + translateBoatType(BoatType.kayak_Canoe));
                Console.WriteLine("press 4 for " + translateBoatType(BoatType.Other));
                Console.WriteLine("or ENTER to leave it unchanged ");

                boatType = Menu.readInt("Boat Type: ", false);
                if (boatType > 0 && boatType < 5 || boatType == null)
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("You have to select a menualternative <1-4>");
                    Menu.pressKeyToContinue();
                }
            }
            while (!done);

            int?  boatLength = Menu.readInt("Boat length: ", false);
            if (memberId != null)
                boat.MemberId = (int)memberId;
            if (boatType != null)
                boat.BoatType = (BoatType)boatType;
            if (boatLength != null)
                boat.BoatLength = (int)boatLength;
            return boat;
        }

//****************
        public void boatCreatedMenu(BoatBLL boat, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  You registered a boat ****\n");
                showBoat(boat);
            }
            else
            {
                Console.WriteLine("****  Boat could not be registered ****\n");

            }
            Menu.pressKeyToContinue();
        }
        public void boatUpdatedMenu(BoatBLL boat, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  You updated a boat ****\n");
                showBoat(boat);
            }
            else
            {
                Console.WriteLine("****  Boat update failed ****\n");
                Console.WriteLine("MemberId: " + boat.MemberId + "  BoatId: " + boat.BoatId);

            }
            Menu.pressKeyToContinue();
        }
        public void boatDeletedMenu(BoatBLL boat, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  You deleted a boat ****\n");
            }
            else
            {
                Console.WriteLine("****  Boat delete failed ****\n");
                Console.WriteLine("MemberId: " + boat.MemberId + "  BoatId: " + boat.BoatId);

            }
            Menu.pressKeyToContinue();
        }
        public void showBoatMenu(BoatBLL boat, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  boat ****\n");
                showBoat(boat);
            }
            else
            {
                Console.WriteLine("****  Boat info not found ****\n");
                Console.WriteLine("Member Id:  " + boat.MemberId + "Boat Id:" + boat.BoatId);

            }
            Menu.pressKeyToContinue();
        }

    }
}
