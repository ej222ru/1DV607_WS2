using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_WS2.Model.BLL
{
    public class MemberBLL
    {
        // corresponds to Member records in the Database
        public int MemberId { get; set; }
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class MemberDetailsBLL : MemberBLL
    {
        public IEnumerable<BoatBLL> Boats { get; set; }
        public MemberDetailsBLL(MemberBLL member)
        {
            MemberId = member.MemberId;
            SSN = member.SSN;
            FirstName = member.FirstName;
            LastName = member.LastName;
        }
    }


}
