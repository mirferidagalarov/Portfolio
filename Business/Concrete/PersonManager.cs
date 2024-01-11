using Business.Abstract;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
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
        public PersonManager(IPersonDAL personDAL,PortfolioDbContext portfolioDb)
        {
            _personDAL = personDAL;
        }
        public IResult Add(Person person,string imageFile, string download)
        {
            person.ProfilPath = imageFile;
            person.CvPath= download;
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
            return new SuccessDataResult<List<Person>>(_personDAL.GetAll().ToList());
        }

        public IDataResult<Person> GetById(int id)
        {
            return new SuccessDataResult<Person>(_personDAL.Get(x => x.ID == id));
        }

        public IResult Update(Person person, string imageFile, string download)
        {
            person.ProfilPath = imageFile;
            person.CvPath= download;
           _personDAL.Update(person);
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
