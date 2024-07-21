using AutoMapper;
using HRLeaveMangement.Application.Dtos.LeaveRequest.Validators;
using HRLeaveMangement.Application.Dtos.LeaveType.Validators;
using HRLeaveMangement.Application.Exceptions;
using HRLeaveMangement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveMangement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveRequests.Handles.Commands
{
    public class UpdateLeaveRequestCommandHnadler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestReposatory;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHnadler(
            ILeaveRequestRepository leaveRequestReposatory,
            ILeaveTypeRepository leaveTypeRepository 
            ,IMapper mapper
            )
        {
            _leaveRequestReposatory = leaveRequestReposatory;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationExceptions(validationResult);

            }
            var leaveRequest = await _leaveRequestReposatory.Get(request.Id);

            if (request.LeaveRequestDto != null)
            {
                _mapper.Map(request.LeaveRequestDto, leaveRequest);
                await _leaveRequestReposatory.Update(leaveRequest);
            }
            else if(request.ChangeLeaveRequestApproval != null)
            {
                await _leaveRequestReposatory.ChangeApprovalStatus(leaveRequest,request.ChangeLeaveRequestApproval.Approved);
            }


            return Unit.Value;
        }
    }
}
