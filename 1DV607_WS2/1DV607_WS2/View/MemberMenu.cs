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
            Console.WriteLine("SSN:        " + member.SSN);
            Console.WriteLine("First name: " + member.FirstName);
            Console.WriteLine("Last name:  " + member.LastName);
            Console.WriteLine("Member Id:  " + member.MemberId);
        }
        public void ShowMemberList(IEnumerable<MemberDetailsBLL> memberDetails)
        {
            Console.WriteLine("****  Members ****\n");
            foreach (MemberDetailsBLL member in memberDetails)
            {
                Console.WriteLine("Member SSN:" + member.SSN + " " + member.FirstName + " " + member.LastName + " has " + member.Boats.Count() + " boats");
            }
            Menu.PressKeyToContinue();
        }


        public void ShowMemberListVerbose(IEnumerable<MemberDetailsBLL> memberDetails)
        {
            int noOfBoats = 0;
            Console.WriteLine("****  Members ****\n");
            foreach (MemberDetailsBLL member in memberDetails)
            {
                Console.WriteLine("\nMember SSN:" + member.SSN + " " + member.FirstName + " " + member.LastName);
                foreach (BoatBLL boat in member.Boats)
                {
                    boatMenu.ShowBoatRow(boat, ++noOfBoats);
                }
            }

            Menu.PressKeyToContinue();
        }
 

 
    }
}
