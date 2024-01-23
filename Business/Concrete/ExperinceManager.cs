using Business.Abstract;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExperinceManager : IExperinceService
    {
        private readonly IExperinceDAL _experinceDAL;
        public ExperinceManager(IExperinceDAL experinceDAL)
        {
                _experinceDAL = experinceDAL;
        }
        public IResult Add(Experience experience)
        {
           _experinceDAL.Add(experience);
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Experience experience)
        {
            _experinceDAL.Delete(experience);
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Experience>> GetAll()
        {
           return new SuccessDataResult<List<Experience>>(_experinceDAL.GetAllWithPosition(x => x.Deleted == Constant.NotDeleted));
        }

        public IDataResult<Experience> GetById(int id)
        {
            return new SuccessDataResult<Experience>(_experinceDAL.Get(x => x.Deleted == Constant.NotDeleted && x.ID==id));
        }

        public IResult Update(Experience experience)
        {
           _experinceDAL.Update(experience);
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
