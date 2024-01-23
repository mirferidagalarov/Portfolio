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
    public class WorkCategoryManager : IWorkCategoryService
    {
        private readonly IWorkCategoryDAL _workCategoryDAL;
        public WorkCategoryManager(IWorkCategoryDAL workCategoryDAL)
        {
                _workCategoryDAL = workCategoryDAL; 
        }
        public IResult Add(WorkCategory workCategory)
        {
            _workCategoryDAL.Add(workCategory);
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(WorkCategory workCategory)
        {
            _workCategoryDAL.Delete(workCategory);  
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<WorkCategory>> GetAll()
        {
            return new SuccessDataResult<List<WorkCategory>>(_workCategoryDAL.GetAll().Where(x=>x.Deleted==Constant.NotDeleted).ToList());
        }

        public IDataResult<WorkCategory> GetById(int id)
        {
            return new SuccessDataResult<WorkCategory>(_workCategoryDAL.Get(x => x.Deleted == Constant.NotDeleted));
        }

        public IResult Update(WorkCategory workCategory)
        {
           _workCategoryDAL.Update(workCategory);   
           return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);  
        }


       
    }
}
