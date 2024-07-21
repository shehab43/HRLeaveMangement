using HRLeaveMangement.Application.Dtos.LeaveAllocation;
using HRLeaveMangement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand :IRequest<BaseResponseCommand>
    {
        public  CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }
    }
}
