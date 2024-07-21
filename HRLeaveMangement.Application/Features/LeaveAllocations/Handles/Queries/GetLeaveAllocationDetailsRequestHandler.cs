using AutoMapper;
using HRLeaveMangement.Application.Contracts.Persistence;
using HRLeaveMangement.Application.Dtos.LeaveRequest;
using HRLeaveMangement.Application.Features.LeaveAllocation.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveAllocation.Handles.Queries
{
    public class GetLeaveAllocationDetailsRequestHandler : IRequestHandler<GetLeaveAllocationDetailsRequest, LeaveRequestDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationReposatory;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDetailsRequestHandler(ILeaveAllocationRepository leaveAllocationReposatory , IMapper mapper)
        {
           _leaveAllocationReposatory = leaveAllocationReposatory;
           _mapper = mapper;
        }
        public async Task<LeaveRequestDto> Handle(GetLeaveAllocationDetailsRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationReposatory.Get(request.Id);
            return _mapper.Map<LeaveRequestDto>(leaveAllocation);
        }
    }
}
