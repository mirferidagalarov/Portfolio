﻿using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class SkillEFDal:RepositoryBase<Skill,PortfolioDbContext>,ISkillDAL
    {
    }
}
