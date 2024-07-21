using AutoMapper;
using HRLeaveMangement.Application.Dtos.LeaveRequest;
using HRLeaveMangement.Application.Features.LeaveRequest.Requests.Queries;
using HRLeaveMangement.Application.Contracts.Persistence;
using HRLeaveMangement.Domine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveRequest.Handles.Queries
{
    public class GetLeaveRequesDetailRequestHandler : IRequestHandler<GetLeaveRequesDetailRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestReposatory;
        private readonly IMapper _mapper;

        public GetLeaveRequesDetailRequestHandler(ILeaveRequestRepository leaveRequestReposatory , IMapper mapper)
        {
          _leaveRequestReposatory = leaveRequestReposatory;
            _mapper = mapper;
        }
        public async Task<LeaveRequestDto> Handle(GetLeaveRequesDetailRequest request, CancellationToken cancellationToken)
        {
            var LeaveRequest = await _leaveRequestReposatory.Get(request.Id);
            return _mapper.Map<LeaveRequestDto>(LeaveRequest);
        }
    }
}
