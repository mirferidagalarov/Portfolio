﻿using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IExperinceDAL:IRepository<Experience>
    {
        List<Experience> GetAllWithPosition(Expression<Func<Experience, bool>> predicate = null);
    }
}
