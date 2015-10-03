using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_WS2.Model.BLL
{
    public class MemberBLL
    {
        // Egenskapernas namn och typ ges av tabellen
        // Member i databasen.
        public int MemberId { get; set; }
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
