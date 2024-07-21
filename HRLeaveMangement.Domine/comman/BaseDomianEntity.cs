﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Domine.comman
{
    public abstract class BaseDomianEntity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }


        public DateTime LastModifiedDate { get; set; }

        public string LastModifiedBy { get; set; }
    }
}
