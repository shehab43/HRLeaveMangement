
using HRLeaveMangement.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;
using HRLeaveMangement.Application.Responses;
using HRLeaveMangement.Application.Contracts.Persistence;
using AutoMapper;
using HRLeaveMangement.Application.Dtos.LeaveType.Validators;
using HRLeaveMangement.Domine;

namespace HRLeaveMangement.Application.Features.LeaveTypes.Handles.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseResponseCommand>
    {

        private readonly ILeaveTypeRepository _leaveTypeReposatory;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeReposatory, IMapper mapper)
        {
            _leaveTypeReposatory = leaveTypeReposatory;
            _mapper = mapper;
        }
        public async Task<BaseResponseCommand> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseCommand();

            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateleaveTypeDto);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationExceptions(validationResult);
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(p => p.ErrorMessage).ToList();

            }

            var leaveType = _mapper.Map<LeaveType>(request.CreateleaveTypeDto);
            leaveType = await _leaveTypeReposatory.Add(leaveType);

            response.Success = true;
            response.Message = "Creation Success";
            response.Id = leaveType.Id;
            return response;

        }
    }
}
