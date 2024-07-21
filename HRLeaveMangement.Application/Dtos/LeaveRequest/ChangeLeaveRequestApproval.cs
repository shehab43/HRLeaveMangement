using HRLeaveMangement.Application.Dtos.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Dtos.LeaveRequest
{
    public class ChangeLeaveRequestApproval:BaseDto
    {
        public bool? Approved { get; set; }

    }
}
