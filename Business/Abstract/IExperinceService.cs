﻿using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExperinceService
    {
        IResult Add(Experience experience);
        IResult Update(Experience experience);
        IResult Delete(Experience experience);
        IDataResult<Experience> GetById(int id);
        IDataResult<List<Experience>> GetAll();
    }
}
