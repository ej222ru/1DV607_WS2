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
                    case 0:  // ESC  terminate
                        {
                            
                            return;
                        }
                    case 1: //create a member
                        {
                            MemberBLL member = new MemberBLL();
                            member = this.menu.createMemberMenu(member);
                            saveMember(member);
                            this.menu.memberCreatedMenu(member);

                            break;
                        }
                    case 2: // update member
                        {
                            int memberId = this.menu.getMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.MemberId = memberId;
                            member = getMember(member);
                            if (member != null)
                            {
                                member = this.menu.updateMemberMenu(member);
                                saveMember(member);
                                member = getMember(member);
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
                    case 3: // view member
                        {
                            int memberId = this.menu.getMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.MemberId = memberId;
                            member = getMember(member);
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
                    case 4: // delete member
                        {

                            int memberId = this.menu.getMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.MemberId = memberId;
                            member = getMember(member);
                            if (member != null)
                            {
                                deleteMember(memberId);
                                member = getMember(member);
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
                    case 5: // register boat
                        {

                            int memberId = this.menu.getMemberMenu();
                            BoatBLL boat = new BoatBLL();
                            MemberBLL member = new MemberBLL();
                            member.MemberId = memberId;
                            member = getMember(member);
                            if (member != null)
                            {
                                boat = this.menu.createBoatMenu(memberId, boat);
                                saveBoat(boat);
                                this.menu.boatCreatedMenu(boat);
                            }
                            else
                            {
                                this.menu.boatCreatedMenu(null, false);
                            }
                            break;
                        }
                    case 6: // update boat
                        {
                            int memberId = this.menu.getMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.MemberId = memberId;
                            member = getMember(member);
                            if (member != null)
                            {
                                IEnumerable<BoatBLL> boats;
                                boats = getBoats(memberId);
                                BoatBLL boat = this.menu.selectBoatMenu(boats);
                                if (boat != null)
                                {
                                    boat = this.menu.updateBoatMenu(boat);
                                    saveBoat(boat);
                                    boat = GetBoat(boat);
                                    this.menu.boatUpdatedMenu(boat);
                                }
                                else
                                {
                                    BoatBLL voidBoat = new BoatBLL();
                                    voidBoat.MemberId = memberId;
                                    this.menu.boatUpdatedMenu(voidBoat, false);
                                }
                            }
                            else
                            {
                                MemberBLL voidMember = new MemberBLL();
                                voidMember.MemberId = memberId;
                                this.menu.showMemberMenu(voidMember, false);
                            }
                            break;
                        }
                    case 7: // delete boat
                        {
                            int memberId = this.menu.getMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.MemberId = memberId;
                            member = getMember(member);
                            if (member != null)
                            {
                                IEnumerable<BoatBLL> boats;
                                boats = getBoats(memberId);
                                BoatBLL boat = this.menu.selectBoatMenu(boats);
                                if (boat != null)
                                {
                                    deleteBoat(boat.BoatId);
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
                            }
                            else
                            {
                                MemberBLL voidMember = new MemberBLL();
                                voidMember.MemberId = memberId;
                                this.menu.showMemberMenu(voidMember, false);
                            }
                            break;
                        }
                    case 8: // list members
                        {
                            IEnumerable<MemberBLL> members = getMembers();
                            IEnumerable<BoatBLL> boats = getAllBoats();
                            BoatBLL[] boatArray = boats.Cast<BoatBLL>().ToArray();
                            this.menu.showMemberList(members, boats);
                            break;
                        }
                    case 9: // list members verbose
                        {
                            IEnumerable<MemberBLL> members = getMembers();
                            IEnumerable<BoatBLL> boats = getAllBoats();
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
        public MemberBLL getMember(MemberBLL member)
        {
            return MemberDAL.getMember(member);
        }

        public IEnumerable<MemberBLL> getMembers()
        {
            return MemberDAL.getMembers();
        }


        public void saveMember(MemberBLL member)
        {
            if (member == null || member.SSN == null)  // more validations ??
            {
                throw new Exception("member didn't validate correctly");
            }
            MemberBLL oldMember = new MemberBLL();
            oldMember.MemberId = member.MemberId;
            if (getMember(oldMember) != null)
            {
                MemberDAL.updateMember(member);
            }
            else
            {
                MemberDAL.insertMember(member);
            }
        }


        public void deleteMember(int memberId)
        {
            MemberDAL.deleteMember(memberId);
        }

 // Boat part
        public BoatBLL GetBoat(BoatBLL boat)
        {
            return BoatDAL.GetBoat(boat);
        }

        public IEnumerable<BoatBLL> getBoats(int memberId)
        {
            return BoatDAL.getBoats(memberId);
        }
        public IEnumerable<BoatBLL> getAllBoats()
        {
            return BoatDAL.getAllBoats();
        }


        public void saveBoat(BoatBLL boat)
        {
            if (boat == null || boat.MemberId == 0)  // more validations ??
            {
                throw new Exception("boat didn't validate correctly");
            }
            BoatBLL oldBoat = new BoatBLL();
            oldBoat.BoatId = boat.BoatId;
            if (GetBoat(oldBoat) != null)
            {
                BoatDAL.updateBoat(boat);
            }
            else
            {
                BoatDAL.insertBoat(boat);
            }
        }


        public void deleteBoat(int boatId)
        {
            BoatDAL.deleteBoat(boatId);
        }

    }
}
