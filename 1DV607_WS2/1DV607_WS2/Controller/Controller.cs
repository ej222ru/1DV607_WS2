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
                            BoatBLL boat = this.menu.createBoatMenu(memberId);
                            SaveBoat(boat);
                            this.menu.boatCreatedMenu(boat);
                            break;
                        }
                    case 6:
                        {
                            break;
                        }
                    case 7:
                        {
                            break;
                        }
                    case 8:
                        {
                            // members = new List<MemberBLL>(1000);
                            IEnumerable<MemberBLL> members = GetMembers();
                            this.menu.showMemberList(members);

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

            if (GetMember(member) != null)
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

        public IEnumerable<BoatBLL> GetBoats()
        {
            return BoatDAL.GetBoats();
        }


        public void SaveBoat(BoatBLL boat)
        {
            if (boat == null || boat.MemberId == 0)  // more validations ??
            {
                throw new Exception("boat didn't validate correctly");
            }

            if (GetBoat(boat) != null)
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
