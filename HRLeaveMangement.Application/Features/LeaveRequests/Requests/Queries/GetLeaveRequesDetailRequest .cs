using HRLeaveMangement.Application.Dtos.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveRequest.Requests.Queries
{
    public class GetLeaveRequesDetailRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
