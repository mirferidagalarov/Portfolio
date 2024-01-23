using Business.Abstract;
using Core.DataAccess.Concrete;
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
    public class AboutSkillManager : IAboutSkillService
    {
        private readonly IAboutSkillDAL _aboutSkillDAL;
        public AboutSkillManager(IAboutSkillDAL  aboutSkillDAL)
        {
            _aboutSkillDAL = aboutSkillDAL;
        }

        public IResult Add(AboutSkill aboutSkill)
        {
            _aboutSkillDAL.Add(aboutSkill);
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(AboutSkill aboutSkill)
        {
            _aboutSkillDAL.Delete(aboutSkill);   
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<AboutSkill>> GetAll()
        {
           return new SuccessDataResult<List<AboutSkill>>(_aboutSkillDAL.GetAllWithSkill(x=>x.Deleted==Constant.NotDeleted).ToList());
        }

        public IDataResult<AboutSkill> GetById(int id)
        {
            return new SuccessDataResult<AboutSkill>(_aboutSkillDAL.Get(x => x.Deleted == Constant.NotDeleted && x.ID == id));
        }

        public IResult Update(AboutSkill aboutSkill)
        {
            _aboutSkillDAL.Update(aboutSkill);
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
