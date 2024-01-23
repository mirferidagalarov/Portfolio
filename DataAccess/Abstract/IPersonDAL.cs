using Core.DataAccess.Abstract;
using Core.Helpers;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Abstract
{
    public interface IPersonDAL:IRepository<Person>
    {
        List<Person> GetAllWithPosition();
      
    }  
}
