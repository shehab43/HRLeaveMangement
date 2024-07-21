using HRLeaveMangement.Domine.comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Domine
{
    public class LeaveRequest: BaseDomianEntity
    {
        //public int id { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public LeaveType LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public DateTime DateRequested { get; set; }

        public string RequestComments { get; set; }

        public DateTime? DateActioned { get; set; }

        public bool? Approved { get; set; }

        public bool cancelled { get; set; }
    }
}
