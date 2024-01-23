using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class AboutSkillEFDal : RepositoryBase<AboutSkill, PortfolioDbContext>, IAboutSkillDAL
    {
        private readonly PortfolioDbContext _portfolioDbContext;
        public AboutSkillEFDal(PortfolioDbContext portfolioDbContext)
        {
                _portfolioDbContext = portfolioDbContext;
        }
        public List<AboutSkill> GetAllWithSkill(Expression<Func<AboutSkill, bool>> predicate = null)
        {
            return predicate is null
                  ?
                   _portfolioDbContext.Set<AboutSkill>().Include(x => x.Skill).ToList()
                  :
                  _portfolioDbContext.Set<AboutSkill>().Include(x => x.Skill).Where(predicate).ToList();
        }
    }
}
