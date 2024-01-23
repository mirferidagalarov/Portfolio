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
    public class ExperinceEFDal : RepositoryBase<Experience, PortfolioDbContext>, IExperinceDAL
    {
        private readonly PortfolioDbContext _portfolioDbContext;
        public ExperinceEFDal(PortfolioDbContext portfolioDbContext)
        {
            _portfolioDbContext = portfolioDbContext;
        }

        public List<Experience> GetAllWithPosition(Expression<Func<Experience, bool>> predicate = null)
        {
           
            return predicate is null
                  ?
                   _portfolioDbContext.Set<Experience>().Include(x => x.Position).ToList()
                  :
                  _portfolioDbContext.Set<Experience>().Include(x => x.Position).Where(predicate).ToList();
        }
    }
}
