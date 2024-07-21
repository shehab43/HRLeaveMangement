using AutoMapper;
using HRLeaveMangement.Application.Contracts.Persistence;
using HRLeaveMangement.Application.Exceptions;
using HRLeaveMangement.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveTypes.Handles.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeReposatory;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeReposatory,IMapper mapper)
        {
           _leaveTypeReposatory = leaveTypeReposatory;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeReposatory.Get(request.Id);

            if (leaveType == null)
                throw new NotFoundExceptions(nameof(leaveType), request.Id);

            await _leaveTypeReposatory.Delete(leaveType);
            return Unit.Value;
        }
    }
}
