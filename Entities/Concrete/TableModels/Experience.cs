﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Experience:BaseEntity
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }=DateTime.Now;
        public DateTime? EndDate { get; set; }
        public bool IsContinue { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int Deleted { get; set; }

    }
}
