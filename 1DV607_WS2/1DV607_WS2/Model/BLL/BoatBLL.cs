using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum BoatType {Sailboat=1, Motorsailer, kayak_Canoe, Other};

namespace _1DV607_WS2.Model.BLL
{
    public class BoatBLL
    {
        public int BoatId { get; set; }

        public int MemberId { get; set; }
        public BoatType BoatType { get; set; }
        public int Length { get; set; }

    }
}
