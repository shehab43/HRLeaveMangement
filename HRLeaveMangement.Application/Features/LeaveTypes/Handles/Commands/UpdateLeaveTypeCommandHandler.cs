using AutoMapper;
using HRLeaveMangement.Application.Contracts.Persistence;
using HRLeaveMangement.Application.Dtos.LeaveType.Validators;
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
    public class UpdateLeaveTypeCommandHandler :IRequestHandler<UpdateLeaveTypeCommand,Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeReposatory;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeReposatory, IMapper mapper)
        {
          _leaveTypeReposatory = leaveTypeReposatory;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationExceptions(validationResult);

            }


            var leaveType =await _leaveTypeReposatory.Get(request.LeaveTypeDto.Id);
             _mapper.Map(request.LeaveTypeDto.Id,leaveType);
           await _leaveTypeReposatory.Update(leaveType);
            return Unit.Value;

        }
    }
}
