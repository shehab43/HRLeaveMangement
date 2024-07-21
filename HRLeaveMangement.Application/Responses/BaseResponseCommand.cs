﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Application.Responses
{
    public class BaseResponseCommand
    {
        public int Id { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }

        public List<string> Errors { get; set; }
    }
}
