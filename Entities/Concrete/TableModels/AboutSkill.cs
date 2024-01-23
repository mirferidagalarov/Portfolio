﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class AboutSkill:BaseEntity
    {
        public int SkillId { get; set; }
        public int Point { get; set; }
        public Skill Skill { get; set; }
        
        public int Deleted { get; set; }

    }
}
