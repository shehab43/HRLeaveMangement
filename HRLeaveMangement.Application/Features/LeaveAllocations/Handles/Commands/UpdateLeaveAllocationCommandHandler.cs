using AutoMapper;
using HRLeaveMangement.Application.Dtos.LeaveAllocation.Validators;
using HRLeaveMangement.Application.Dtos.LeaveRequest.Validators;
using HRLeaveMangement.Application.Exceptions;
using HRLeaveMangement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveMangement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveAllocations.Handles.Commands
{
    public class UpdateLeaveAllocationCommandHandler:IRequestHandler<UpdateLeaveAllocationCommand,Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationReposatory;
        private readonly ILeaveTypeRepository _leaveTypeReposatory;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(
            ILeaveAllocationRepository leaveAllocationReposatory,
            ILeaveTypeRepository leaveTypeReposatory,
            IMapper mapper)
        {
            _leaveAllocationReposatory = leaveAllocationReposatory;
            _leaveTypeReposatory = leaveTypeReposatory;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeReposatory);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationExceptions(validationResult);
            }
            var LeaveAllocation =   await _leaveAllocationReposatory.Get(request.LeaveAllocationDto.Id);
                                    _mapper.Map(request.LeaveAllocationDto.Id, LeaveAllocation);
                                    await _leaveAllocationReposatory.Update(LeaveAllocation);
                                    return Unit.Value;

        }
    }
}
