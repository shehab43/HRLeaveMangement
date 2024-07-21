using HRLeaveMangement.Application.Dtos.LeaveType;
using HRLeaveMangement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseResponseCommand>
    {
        public int Id { get; set; }
        public CreateLeaveTypeDto CreateleaveTypeDto { get; set; }
    }
}
