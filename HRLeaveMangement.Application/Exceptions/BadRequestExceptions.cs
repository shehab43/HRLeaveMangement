using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Exceptions
{
    public class BadRequestExceptions :ApplicationException
    {
        public BadRequestExceptions(string message):base(message)
        {
            
        }
    }
}
