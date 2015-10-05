using _1DV607_WS2.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_WS2.View
{
    class BoatMenu
    {
        public BoatBLL createBoatMenu(int memberId)
        {
            BoatType boatType = createBoatTypeMenu();
            int length = Menu.readInt("Length: ");

            BoatBLL boat = new BoatBLL();
            boat.MemberId = memberId;
            boat.BoatType = boatType;
            boat.Length = length;

            return boat;
        }


        public BoatType createBoatTypeMenu()
        {
// public enum BoatType {Sailboat=1, Motorsailer, kayak_Canoe, Other};
            BoatType ret = 0;

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
                        break;
                    };
            }

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
            Console.WriteLine("Boat Id:  " + boat.BoatId);
            Console.WriteLine("Member Id:  " + boat.MemberId);
            Console.WriteLine("BoatType: " + translateBoatType(boat.BoatType));
            Console.WriteLine("Length:  " + boat.Length);
        }


//****************
        public void boatCreatedMenu(BoatBLL boat)
        {
            Console.WriteLine("****  You registered a boat ****\n");
            showBoat(boat);
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
        public void boatDeletedMenu(int boatId, bool succeeded = true)
        {
            if (succeeded)
            {
                Console.WriteLine("****  boat deleted ****\n");
                Console.WriteLine("Boat Id:  " + boatId);
            }
            else
            {
                Console.WriteLine("****  Boat could not be deleted ****\n");
                Console.WriteLine("Boat Id:  " + boatId);
            }
            Menu.pressKeyToContinue();
        }
    }
}
