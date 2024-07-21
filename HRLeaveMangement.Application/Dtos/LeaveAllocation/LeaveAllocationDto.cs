using HRLeaveMangement.Application.Dtos.common;
using HRLeaveMangement.Application.Dtos.LeaveType;
using HRLeaveMangement.Domine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Dtos.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto, ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }


        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
