using HRLeaveMangement.Application.Contracts.Persistence;

using HRLeaveMangement.Domine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Persistence.Reposatory
{
    public class LeaveTypeRepository : GenaricReposatory<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveMangeMentDbcontext _dbcontext;

        public LeaveTypeRepository(LeaveMangeMentDbcontext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
       
    }
}
