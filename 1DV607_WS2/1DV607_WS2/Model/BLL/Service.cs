using _1DV607_WS2.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _1DV607_WS2.Model.BLL
{
    public class Service
    {

        private MemberDAL _memberDAL;
        private MemberDAL MemberDAL
        {
            get { return _memberDAL ?? (_memberDAL = new MemberDAL()); }
        }

        public void SaveMember(MemberBLL member)
        {
            if (member == null || member.MemberId == 0 || member.SSN == null)  // more validations ??
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
