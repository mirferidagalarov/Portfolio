using Core.DataAccess.Abstract;
using Core.Helpers;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Abstract
{
    public interface IPersonDAL:IRepository<Person>
    {
        List<Person> GetAll();
        IDataResult<Person> GetById(int id);
        //void Getiddownload(int id); 
    }  
}
