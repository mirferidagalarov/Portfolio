using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPortfolioService
    {
        IResult Add(Portfoli portfolio,string imageFile);
        IResult Update(Portfoli portfolio, string imageFile);    
        IResult Delete(Portfoli portfolio);
        IDataResult<List<Portfoli>> GetAll();
        IDataResult<Portfoli> GetById(int id);
    }
}
