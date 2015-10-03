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

        public void start()
        {
            bool start = false;
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
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
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


        public MemberBLL GetMember(MemberBLL member)
        {
            return MemberDAL.GetMember(member);
        }

    }
}
