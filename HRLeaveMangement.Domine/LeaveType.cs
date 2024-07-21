using HRLeaveMangement.Domine.comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Domine
{
    public class LeaveType : BaseDomianEntity
    {
        //public int id { get; set; }

        public string name { get; set; }

        public int DefaultDays { get; set; }

        //public DateTime DateCreated { get; set; }
    }
}
