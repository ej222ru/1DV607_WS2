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
        public MemberBLL createMemberMenu(MemberBLL member)
        {
            string fName = Menu.readLine("First name: ");
            string lName = Menu.readLine("Last name: ");
            string SSN = Menu.readLine("SSN: ");

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
                input = Menu.readLine("Enter member id: ");
                if (Int32.TryParse(input, out memberId))
                    done = true;
                else
                {
                    Console.Write("You have to enter member id as intger numbers!");
                    Menu.pressKeyToContinue();
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

            string fName    = Menu.readLine("First name: ", false);
            string lName    = Menu.readLine("Last name: ", false);
            string SSN      = Menu.readLine("SSN: ", false);
            if (fName != "")
                member.FirstName = fName;
            if (lName != "")
                member.LastName = lName;
            if (SSN != "")
                member.SSN = SSN;
            return member;
        }

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
            Menu.pressKeyToContinue();
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
            Menu.pressKeyToContinue();
        }
 
 
    }
}
