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
            _1DV607_WS2.View.Menu.UserAction menuChoice;
            do
            {

                menuChoice = this.menu.mainMenu();
                switch (menuChoice)
                {
                    case _1DV607_WS2.View.Menu.UserAction.EndSession :  
                        {
                            return;
                        }
                    case _1DV607_WS2.View.Menu.UserAction.CreateMember: 
                        {
                            MemberBLL member = new MemberBLL();
                            member = this.menu.CreateMemberMenu(member);
                            SaveMember(member);
                            this.menu.MemberCreatedMenu(member);

                            break;
                        }
                    case _1DV607_WS2.View.Menu.UserAction.UpdateMember: 
                        {
                            string SSN = this.menu.GetMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.SSN = SSN;
                            member = GetMember(member);
                            if (member != null)
                            {
                                member = this.menu.UpdateMemberMenu(member);
                                SaveMember(member);
                                member = GetMember(member);
                                this.menu.MemberUpdatedMenu(member);
                            }
                            else
                            {
                                MemberBLL voidMember = new MemberBLL();
                                voidMember.SSN = SSN;
                                this.menu.MemberUpdatedMenu(voidMember, false);
                            }
                            break;
                        }
                    case _1DV607_WS2.View.Menu.UserAction.ViewMember: 
                        {
                            string SSN = this.menu.GetMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.SSN = SSN;
                            member = GetMember(member);
                            if (member != null)
                            {
                                this.menu.ShowMemberMenu(member);
                            }
                            else
                            {
                                MemberBLL voidMember = new MemberBLL();
                                voidMember.SSN = SSN;
                                this.menu.ShowMemberMenu(voidMember, false);
                            }
                            break;
                        }
                    case _1DV607_WS2.View.Menu.UserAction.DeleteMember: 
                        {

                            string SSN = this.menu.GetMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.SSN = SSN;
                            member = GetMember(member);
                            if (member != null)
                            {
                                DeleteMember(SSN);
                                member = GetMember(member);
                                if (member != null)
                                    this.menu.MemberDeletedMenu(SSN, false);
                                else
                                    this.menu.MemberDeletedMenu(SSN);
                            }
                            else
                            {
                                MemberBLL voidMember = new MemberBLL();
                                voidMember.SSN = SSN;
                                this.menu.ShowMemberMenu(voidMember, false);
                            }
                            break;
                        }
                    case _1DV607_WS2.View.Menu.UserAction.RegisterBoat: 
                        {

                            string SSN = this.menu.GetMemberMenu();
                            BoatBLL boat = new BoatBLL();
                            MemberBLL member = new MemberBLL();
                            member.SSN = SSN;
                            member = GetMember(member);
                            if (member != null)
                            {
                                boat = this.menu.CreateBoatMenu(member.MemberId, boat);
                                SaveBoat(boat);
                                this.menu.BoatCreatedMenu(boat);
                            }
                            else
                            {
                                this.menu.BoatCreatedMenu(null, false);
                            }
                            break;
                        }
                    case _1DV607_WS2.View.Menu.UserAction.UpdateBoat: 
                        {
                            string SSN = this.menu.GetMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.SSN = SSN;
                            member = GetMember(member);
                            if (member != null)
                            {
                                IEnumerable<BoatBLL> boats;
                                boats = GetBoats(member.MemberId);
                                BoatBLL boat = this.menu.SelectBoatMenu(boats);
                                if (boat != null)
                                {
                                    boat = this.menu.UpdateBoatMenu(boat);
                                    SaveBoat(boat);
                                    boat = GetBoat(boat);
                                    this.menu.BoatUpdatedMenu(boat);
                                }
                                else
                                {
                                    BoatBLL voidBoat = new BoatBLL();
                                    voidBoat.MemberId = member.MemberId;
                                    this.menu.BoatUpdatedMenu(voidBoat, false);
                                }
                            }
                            else
                            {
                                MemberBLL voidMember = new MemberBLL();
                                voidMember.SSN = SSN;
                                this.menu.ShowMemberMenu(voidMember, false);
                            }
                            break;
                        }
                    case _1DV607_WS2.View.Menu.UserAction.DeleteBoat: 
                        {
                            string SSN = this.menu.GetMemberMenu();
                            MemberBLL member = new MemberBLL();
                            member.SSN = SSN;
                            member = GetMember(member);
                            if (member != null)
                            {
                                IEnumerable<BoatBLL> boats;
                                BoatBLL boat = null;
                                boats = GetBoats(member.MemberId);
                                if (boats.Count() != 0)
                                {
                                    boat = this.menu.SelectBoatMenu(boats);
                                }
                                if (boat != null)
                                {
                                    DeleteBoat(boat.BoatId);
                                    boat = GetBoat(boat);
                                    if (boat != null)
                                        this.menu.BoatDeletedMenu(boat, member, false);
                                    else
                                        this.menu.BoatDeletedMenu(boat, member);
                                }
                                else
                                {
                                    BoatBLL voidBoat = new BoatBLL();
                                    voidBoat.MemberId = member.MemberId;
                                    this.menu.BoatDeletedMenu(voidBoat, member, false);
                                }
                            }
                            else
                            {
                                MemberBLL voidMember = new MemberBLL();
                                voidMember.SSN = SSN;
                                this.menu.ShowMemberMenu(voidMember, false);
                            }
                            break;
                        }
                    case _1DV607_WS2.View.Menu.UserAction.ListMembers: 
                        {
                            IEnumerable<MemberBLL> members = GetMembers();
                            IEnumerable<BoatBLL> boats = GetAllBoats();
                            this.menu.ShowMemberList(members, boats);
                            break;
                        }
                    case _1DV607_WS2.View.Menu.UserAction.ListMembersVerbose: 
                        {
                            IEnumerable<MemberBLL> members = GetMembers();
                            IEnumerable<BoatBLL> boats = GetAllBoats();
                            this.menu.ShowMemberListVerbose(members, boats);

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
            oldMember.SSN = member.SSN;
            if (GetMember(oldMember) != null)
            {
                MemberDAL.UpdateMember(member);
            }
            else
            {
                MemberDAL.IinsertMember(member);
            }
        }


        public void DeleteMember(string SSN)
        {
            MemberDAL.DeleteMember(SSN);
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
