using HRLeaveMangement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Contracts.infrastructre
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
