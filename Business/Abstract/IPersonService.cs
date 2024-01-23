using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonService
    {
        IDataResult<List<string>> Add(Person person,string imageFile,string download);
        IResult Update(Person person, string imageFile, string download);  
        IResult Delete(Person person);
        IDataResult<Person> GetById(int id);
        IDataResult<List<Person>> GetAll();
      
    }
}
