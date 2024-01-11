using Core.DataAccess.Concrete;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class PersonEFDal : RepositoryBase<Person, PortfolioDbContext>, IPersonDAL
    {
        private readonly PortfolioDbContext _portfolioDbContext;
        public PersonEFDal(PortfolioDbContext portfolioDbContext)
        {
            _portfolioDbContext = portfolioDbContext;
        }

    

        public List<Person> GetAll()
        {
            return _portfolioDbContext.People.Include(x => x.Position).ToList();
        }

        public IDataResult<Person> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
