using AutoMapper;
using HRLeaveMangement.Application.Dtos.LeaveRequest;
using HRLeaveMangement.Application.Features.LeaveRequest.Requests.Queries;
using HRLeaveMangement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveRequest.Handles.Queries
{
    public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestReposatory;
        private readonly IMapper _mapper;

        public GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveRequestReposatory ,IMapper Mapper)
        {
           _leaveRequestReposatory = leaveRequestReposatory;
            _mapper = Mapper;
        }
        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
        {
            var LeaveRequests = await _leaveRequestReposatory.GetAll();
            return _mapper.Map<List<LeaveRequestListDto>>(LeaveRequests);

        }

     
    }
}
