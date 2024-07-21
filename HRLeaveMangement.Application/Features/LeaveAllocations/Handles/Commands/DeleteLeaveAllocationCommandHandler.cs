using AutoMapper;
using HRLeaveMangement.Application.Exceptions;
using HRLeaveMangement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveMangement.Application.Contracts.Persistence;
using HRLeaveMangement.Domine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveAllocations.Handles.Commands
{
    public class DeleteLeaveAllocationCommandHandler:IRequestHandler<DeleteLeaveAllocationCommand,Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationReposatory;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationReposatory,IMapper mapper)
        {
            _leaveAllocationReposatory = leaveAllocationReposatory;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var LeaveAllocation = await _leaveAllocationReposatory.Get(request.Id);
            if (LeaveAllocation == null)
                throw new NotFoundExceptions(nameof(LeaveAllocation), request.Id);

            _mapper.Map(request.Id, LeaveAllocation);
            await _leaveAllocationReposatory.Delete(LeaveAllocation);
            return Unit.Value;
        }
    }
}
