using Business.Abstract;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PortfolioManager : IPortfolioService
    {
        private readonly IPortfolioDAL _portfolioDAL;
        public PortfolioManager(IPortfolioDAL portfolioDAL)
        {
                _portfolioDAL = portfolioDAL;
        }
        public IResult Add(Portfoli portfolio, string imageFile)
        {
            portfolio.WorkImagePath = imageFile;
            _portfolioDAL.Add(portfolio);
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Portfoli portfolio)
        {
           _portfolioDAL.Delete(portfolio);
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly); 
        }

        public IDataResult<List<Portfoli>> GetAll()
        {
            return new SuccessDataResult<List<Portfoli>>(_portfolioDAL.GetAllWithWorkCategory().Where(x=>x.Deleted==Constant.NotDeleted).ToList());    
        }

        public IDataResult<Portfoli> GetById(int id)
        {
            return new SuccessDataResult<Portfoli>(_portfolioDAL.Get(x=>x.ID==id));
        }

        public IResult Update(Portfoli portfolio, string imageFile)
        {
            portfolio.WorkImagePath = imageFile;              
           _portfolioDAL.Update(portfolio);
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
