using HRLeaveMangement.Application.Dtos.common;
using HRLeaveMangement.Application.Dtos.LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Dtos.LeaveRequest
{
    public class UpdateLeaveRequestDto:BaseDto,ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        public int LeaveTypeId { get; set; }


        public string RequestComments { get; set; }


        public bool Cancelled { get; set; }
    }
}
