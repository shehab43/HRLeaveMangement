using HRLeaveMangement.Application.Dtos.LeaveRequest;
using HRLeaveMangement.Domine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveAllocation.Requests.Queries
{
    public class GetLeaveAllocationListRequest:IRequest<List<LeaveRequestDto>>
    {
    }
}
