using _1DV607_WS2.Model.BLL;
using _1DV607_WS2.Model.DAL;
using _1DV607_WS2.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_WS2.Controller
{
    public class Control
    {
        private Menu menu;
        public Control(Menu menu)
        {
            this.menu = menu;
        }

        private MemberDAL _memberDAL;
        private MemberDAL MemberDAL
        {
            get { return _memberDAL ?? (_memberDAL = new MemberDAL()); }
        }
        private BoatDAL _boatDAL;
        private BoatDAL BoatDAL
        {
            get { return _boatDAL ?? (_boatDAL = new BoatDAL()); }
        }


        public void start()
        {
            int menuChoice;
            do
            {

                menuChoice = this.menu.mainMenu();
                switch (menuChoice)
                {
                    case 0:
                        {
                            
                            return;
                        }
                    case 1:
                        {
                            MemberBLL member = this.menu.createMemberMenu();
                            SaveMember(member);
                            this.menu.memberCreatedMenu(member);

                            break;
                        }
                    case 2:
                        {
                            int memberId = this.menu.getMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.MemberId = memberId;
                            member = GetMember(member);
                            if (member != null)
                            {
                                member = this.menu.updateMemberMenu(member);
                                SaveMember(member);
                                member = GetMember(member);
                                this.menu.memberUpdatedMenu(member);
                            }
                            else
                            {
                                MemberBLL voidMember = new MemberBLL();
                                voidMember.MemberId = memberId;
                                this.menu.memberUpdatedMenu(voidMember, false);
                            }
                            break;
                        }
                    case 3:
                        {
                            int memberId = this.menu.getMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.MemberId = memberId;
                            member = GetMember(member);
                            if (member != null)
                            {
                                this.menu.showMemberMenu(member);
                            }
                            else
                            {
                                MemberBLL voidMember = new MemberBLL();
                                voidMember.MemberId = memberId;
                                this.menu.showMemberMenu(voidMember, false);
                            }
                            break;
                        }
                    case 4:
                        {

                            int memberId = this.menu.getMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.MemberId = memberId;
                            member = GetMember(member);
                            if (member != null)
                            {
                                DeleteMember(memberId);
                                member = GetMember(member);
                                if (member != null)
                                    this.menu.memberDeletedMenu(memberId, false);
                                else
                                    this.menu.memberDeletedMenu(memberId);
                            }
                            else
                            {
                                MemberBLL voidMember = new MemberBLL();
                                voidMember.MemberId = memberId;
                                this.menu.showMemberMenu(voidMember, false);
                            }
                            break;
                        }
                    case 5:
                        {

                            int memberId = this.menu.getMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.MemberId = memberId;
                            member = GetMember(member);
                            if (member != null)
                            {
                                BoatBLL boat = this.menu.createBoatMenu(memberId);
                                SaveBoat(boat);
                                this.menu.boatCreatedMenu(boat);
                            }
                            else
                            {
                                this.menu.boatCreatedMenu(null, false);
                            }
                            break;
                        }
                    case 6:
                        {
                            int memberId = this.menu.getMemberMenu();

                            IEnumerable<BoatBLL> boats;
                            boats = GetBoats(memberId);
                            BoatBLL boat = this.menu.selectBoatMenu(boats);
                            if (boat != null)
                            {
                                boat = this.menu.updateBoatMenu(boat);
                                SaveBoat(boat);
                                boat = GetBoat(boat);
                                this.menu.boatUpdatedMenu(boat);
                            }
                            else
                            {
                                BoatBLL voidBoat = new BoatBLL();
                                voidBoat.MemberId = memberId;
                                this.menu.boatUpdatedMenu(voidBoat, false);
                            }
                            break;
                        }
                    case 7:
                        {
                            int memberId = this.menu.getMemberMenu();
                            IEnumerable<BoatBLL> boats;
                            boats = GetBoats(memberId);
                            BoatBLL boat = this.menu.selectBoatMenu(boats);
                            if (boat != null)
                            {
                                DeleteBoat(boat.BoatId);
                                boat = GetBoat(boat);
                                if (boat != null)
                                    this.menu.boatDeletedMenu(boat, false);
                                else
                                    this.menu.boatDeletedMenu(boat);
                            }
                            else
                            {
                                BoatBLL voidBoat = new BoatBLL();
                                voidBoat.MemberId = memberId;
                                this.menu.boatDeletedMenu(boat, false);
                            }
                            break;
                        }
                    case 8:
                        {
                            // members = new List<MemberBLL>(1000);
                            IEnumerable<MemberBLL> members = GetMembers();
                            IEnumerable<BoatBLL> boats = GetAllBoats();
                            BoatBLL[] boatArray = boats.Cast<BoatBLL>().ToArray();
                            this.menu.showMemberList(members, boats);
                            break;
                        }
                    case 9:
                        {
                            // members = new List<MemberBLL>(1000);
                            IEnumerable<MemberBLL> members = GetMembers();
                            IEnumerable<BoatBLL> boats = GetAllBoats();
                            BoatBLL[] boatArray = boats.Cast<BoatBLL>().ToArray();
                            this.menu.showMemberListVerbose(members, boats);

                            break;
                        }
                            
                    default:
                        {
                            Debug.Assert(true, "start(): forgot to extend switch case entries?");
                            break;
                        };
                }


            }
            while (true);
        }

// Member part
        public MemberBLL GetMember(MemberBLL member)
        {
            return MemberDAL.GetMember(member);
        }

        public IEnumerable<MemberBLL> GetMembers()
        {
            return MemberDAL.GetMembers();
        }


        public void SaveMember(MemberBLL member)
        {
            if (member == null || member.SSN == null)  // more validations ??
            {
                throw new Exception("member didn't validate correctly");
            }
            MemberBLL oldMember = new MemberBLL();
            oldMember.MemberId = member.MemberId;
            if (GetMember(oldMember) != null)
            {
                MemberDAL.UpdateMember(member);
            }
            else
            {
                MemberDAL.InsertMember(member);
            }
        }


        public void DeleteMember(int memberId)
        {
            MemberDAL.DeleteMember(memberId);
        }

 // Boat part
        public BoatBLL GetBoat(BoatBLL boat)
        {
            return BoatDAL.GetBoat(boat);
        }

        public IEnumerable<BoatBLL> GetBoats(int memberId)
        {
            return BoatDAL.GetBoats(memberId);
        }
        public IEnumerable<BoatBLL> GetAllBoats()
        {
            return BoatDAL.GetAllBoats();
        }


        public void SaveBoat(BoatBLL boat)
        {
            if (boat == null || boat.MemberId == 0)  // more validations ??
            {
                throw new Exception("boat didn't validate correctly");
            }
            BoatBLL oldBoat = new BoatBLL();
            oldBoat.BoatId = boat.BoatId;
            if (GetBoat(oldBoat) != null)
            {
                BoatDAL.UpdateBoat(boat);
            }
            else
            {
                BoatDAL.InsertBoat(boat);
            }
        }


        public void DeleteBoat(int boatId)
        {
            BoatDAL.DeleteBoat(boatId);
        }

    }
}
