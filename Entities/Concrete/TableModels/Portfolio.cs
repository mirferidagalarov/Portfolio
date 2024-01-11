﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Portfolio:BaseEntity
    {
        public string Title { get; set; }
        public string WorkImagePath { get; set; }
        public int WorkCategoryId { get; set; }
        public WorkCategory WorkCategory { get; set; }
        public int Deleted { get; set; }

    }
}
