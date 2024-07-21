using HRLeaveMangement.Application.Dtos.LeaveRequest;
using HRLeaveMangement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand :IRequest<BaseResponseCommand>
    {
        public CreateRequestDto LeaveRequestDto { get; set; }
    }
}
