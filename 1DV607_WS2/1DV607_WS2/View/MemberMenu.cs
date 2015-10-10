using _1DV607_WS2.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_WS2.View
{
    public class MemberMenu
    {
        private BoatMenu boatMenu;
        public MemberMenu(BoatMenu boatMenu)
        {
            this.boatMenu = boatMenu;
        }
        public MemberBLL CreateMemberMenu(MemberBLL member)
        {
            Boolean done = false;
            string fName = Menu.ReadLine("First name: ");
            string lName = Menu.ReadLine("Last name: ");
            string SSN = "";
            while (!done)
            {
                SSN = Menu.ReadLine("SSN (YYYYMMDDnnnn): ");
                if (SSN.Length < 12)
                {
                    Console.Write("SSN has to be 12 characters long and in the format YYYYMMDDnnnn");
                }
                else
                {
                    done = true;
                }
            }
            member.FirstName = fName;
            member.LastName = lName;
            member.SSN = SSN;

            return member;
        }
        public String GetMemberMenu()
        {
            bool done = false;
            String SSN="";
            do
            {
                while (!done)
                {
                    SSN = Menu.ReadLine("Enter member SSN (YYYYMMDDnnnn): ");
                    if (SSN.Length < 12)
                    {
                        Console.Write("SSN has to be 12 characters long and in the format YYYYMMDDnnnn");
                        Menu.PressKeyToContinue();
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
            while (!done);

            return SSN;
        }
        public MemberBLL UpdateMemberMenu(MemberBLL member)
        {
            Console.WriteLine("First name: " + member.FirstName);
            Console.WriteLine("Last name: " + member.LastName);

            Console.WriteLine("Just press ENTER for fields you don't want to change");

            string fName    = Menu.ReadLine("First name: ", false);
            string lName    = Menu.ReadLine("Last name: ", false);
            if (fName != "")
                member.FirstName = fName;
            if (lName != "")
                member.LastName = lName;
            return member;
        }

        public void ShowMember(MemberBLL member)
        {
            Console.WriteLine("Member Id:  " + member.MemberId);
            Console.WriteLine("First name: " + member.FirstName);
            Console.WriteLine("Last name:  " + member.LastName);
            Console.WriteLine("SSN:        " + member.SSN);
        }
        public void ShowMemberList(IEnumerable<MemberBLL> members, IEnumerable<BoatBLL> boats)
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
            Menu.PressKeyToContinue();
        }
        public void ShowMemberListVerbose(IEnumerable<MemberBLL> members, IEnumerable<BoatBLL> boats)
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
                        boatMenu.ShowBoatRow(boat, ++noOfBoats);
                }
            }
            Menu.PressKeyToContinue();
        }
 
 
    }
}
