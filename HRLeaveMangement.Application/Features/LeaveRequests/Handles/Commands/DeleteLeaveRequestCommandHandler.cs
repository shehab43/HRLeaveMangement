using AutoMapper;
using HRLeaveMangement.Application.Contracts.Persistence;
using HRLeaveMangement.Application.Exceptions;
using HRLeaveMangement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveMangement.Domine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveRequests.Handles.Commands
{
    public class DeleteLeaveRequestCommandHandler :IRequestHandler<DeleteLeaveRequestCommand,Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestReposatory;
        private readonly IMapper _mapper;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestReposatory,IMapper mapper)
        {
            _leaveRequestReposatory = leaveRequestReposatory;
           _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestReposatory.Get(request.Id);
            if (leaveRequest == null)
                throw new NotFoundExceptions(nameof(leaveRequest), request.Id);

            _mapper.Map(request.Id, leaveRequest);
            await _leaveRequestReposatory.Delete(leaveRequest);
            return Unit.Value;
        }
    }
}
