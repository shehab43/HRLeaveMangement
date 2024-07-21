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
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveRequestDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationReposatory;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationReposatory , IMapper mapper)
        {
           _leaveAllocationReposatory = leaveAllocationReposatory;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await _leaveAllocationReposatory.GetAll();
            return _mapper.Map<List<LeaveRequestDto>>(leaveAllocations);

        }
    }
}
