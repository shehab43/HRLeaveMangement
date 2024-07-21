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
    public class LeaveAllocationRepository:GenaricReposatory<LeaveAllocation>,ILeaveAllocationRepository
    {
        private readonly LeaveMangeMentDbcontext _dbcontext;

        public LeaveAllocationRepository(LeaveMangeMentDbcontext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
         var LeaveAllocation =  await _dbcontext.LeaveAllocations
                                        .Include(p => p.LeaveType)
                                        .FirstOrDefaultAsync(p => p.Id == id);
            return LeaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var LeaveAllocations = await _dbcontext.LeaveAllocations.
                                            Include(p => p.LeaveType).
                                            ToListAsync();
            return LeaveAllocations;
        }
    }
}
