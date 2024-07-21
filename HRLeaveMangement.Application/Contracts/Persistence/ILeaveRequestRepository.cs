using HRLeaveMangement.Domine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenaricReposatory<LeaveRequest>
    {
        Task<LeaveRequest> Add(LeaveRequest request);
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails();
        Task ChangeApprovalStatus(LeaveRequest LeaveRequest, bool? ApprovalStatus);

    }
}
