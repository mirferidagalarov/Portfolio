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
    public class PersonManager : IPersonService
    {
        private readonly IPersonDAL _personDAL;
        public PersonManager(IPersonDAL personDAL)
        {
            _personDAL = personDAL;
        }
        public IResult Add(Person person)
        {
            _personDAL.Add(person);
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Person person)
        {
            _personDAL.Delete(person);  
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Person>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Person> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
