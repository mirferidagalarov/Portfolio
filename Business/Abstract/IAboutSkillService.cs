using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutSkillService
    {
        IResult Add(AboutSkill aboutSkill);
        IResult Update(AboutSkill aboutSkill);
        IResult Delete(AboutSkill aboutSkill);
        IDataResult<AboutSkill> GetById(int id);
        IDataResult<List<AboutSkill>> GetAll();
    }
}
