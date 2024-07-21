using HRLeaveMangement.Application.Contracts.Persistence;
using HRLeaveMangement.Domine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Persistence.Reposatory
{
    public class LeaveRequestRepository : GenaricReposatory<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveMangeMentDbcontext _dbContext;

        public LeaveRequestRepository(LeaveMangeMentDbcontext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task ChangeApprovalStatus(LeaveRequest LeaveRequest, bool? ApprovalStatus)
        {
            LeaveRequest.Approved = ApprovalStatus; 
            _dbContext.Entry(LeaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests
                                  .Include(p => p.LeaveType)
                                  .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
         var leaveRequest = await _dbContext.LeaveRequests
                       .Include(p => p.LeaveTypeId)
                       .FirstOrDefaultAsync(p =>p.Id == id);
            return leaveRequest;
        } 
     
    }
}
