using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Exceptions
{
    public class NotFoundExceptions :ApplicationException
    {
        public NotFoundExceptions(string name , object key):base($"{name} ({key}) was not found")
        {
            
        }
    }
}
