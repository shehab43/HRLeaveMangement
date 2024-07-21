using AutoMapper;
using HRLeaveMangement.Application.Dtos.LeaveAllocation.Validators;
using HRLeaveMangement.Application.Dtos.LeaveRequest.Validators;
using HRLeaveMangement.Application.Exceptions;
using HRLeaveMangement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveMangement.Application.Contracts.Persistence;
using HRLeaveMangement.Application.Responses;
using HRLeaveMangement.Domine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveAllocations.Handles.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseResponseCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationReposatory;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(
            ILeaveAllocationRepository leaveAllocationReposatory,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
           _leaveAllocationReposatory = leaveAllocationReposatory;
           _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponseCommand> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseCommand();
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationExceptions(validationResult);
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(p =>p.ErrorMessage).ToList();
            }


            var LeaveAllocation = _mapper.Map<HRLeaveMangement.Domine.LeaveAllocation>(request.CreateLeaveAllocationDto);
            LeaveAllocation = await _leaveAllocationReposatory.Add(LeaveAllocation);

            response.Success = true;
            response.Message = "Creation Success";
            response.Id = LeaveAllocation.Id;
            return response;

        }
    }
}
