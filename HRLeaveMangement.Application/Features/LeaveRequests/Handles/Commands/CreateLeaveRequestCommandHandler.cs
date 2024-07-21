using AutoMapper;
using HRLeaveMangement.Application.Contracts.infrastructre;
using HRLeaveMangement.Application.Contracts.Persistence;
using HRLeaveMangement.Application.Dtos.LeaveRequest.Validators;
using HRLeaveMangement.Application.Dtos.LeaveType.Validators;
using HRLeaveMangement.Application.Exceptions;
using HRLeaveMangement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveMangement.Application.Models;
using HRLeaveMangement.Application.Responses;
using HRLeaveMangement.Domine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Features.LeaveRequests.Handles.Commands
{
    public class CreateLeaveRequestCommandHandler :IRequestHandler<CreateLeaveRequestCommand,BaseResponseCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestReposatory;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestReposatory,
            ILeaveTypeRepository leaveTypeRepository,
            IEmailSender emailSender,
            IMapper mapper
            )
        {
            _leaveRequestReposatory = leaveRequestReposatory;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        public async Task<BaseResponseCommand> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseCommand();

            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationExceptions(validationResult);
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(p => p.ErrorMessage).ToList();

            }

            var LeaveRequest = _mapper.Map<HRLeaveMangement.Domine.LeaveRequest>(request.LeaveRequestDto);
            LeaveRequest = await _leaveRequestReposatory.Add(LeaveRequest);


            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = LeaveRequest.Id;


            var Email = new Email
            {
                To = "employee@org.com",
                body = $"Your Leave Request From {request.LeaveRequestDto.StartDate:d} To {request.LeaveRequestDto.EndDate:d} " +
                $"has been Submitted Successfuly",
                Subject = "leave Request Submitted"
               
            };
            try
            {
                await _emailSender.SendEmail(Email);
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
    }
}
