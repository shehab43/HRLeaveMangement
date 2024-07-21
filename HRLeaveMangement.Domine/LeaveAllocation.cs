using HRLeaveMangement.Domine.comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Domine
{
    public class LeaveAllocation :BaseDomianEntity
    {
        //public int id { get; set; }

        public int NumberOfDays { get; set; }

        //public DateTime DateCreated { get; set; }

        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
