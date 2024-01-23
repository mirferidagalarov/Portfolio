using Business.Abstract;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonDAL _personDAL;
        private readonly IValidator<Person> _validationRules;
        public PersonManager(IPersonDAL personDAL,PortfolioDbContext portfolioDb, IValidator<Person> validationRules)
        {
            _personDAL = personDAL;
            _validationRules = validationRules;
        }
        public IDataResult<List<string>> Add(Person person,string imageFile, string download)
        {
            
            person.ProfilPath = imageFile;
            person.CvPath= download;
            var result = _validationRules.Validate(person);
            if (!result.IsValid)
            {
                return new ErrorDataResult<List<string>>(result.Errors.Select(x=>x.PropertyName).ToList(),result.Errors.Select(x=>x.ErrorMessage).ToList()); 
            }
            _personDAL.Add(person);
            return new SuccessDataResult<List<string>>(null,CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Person person)
        {
            _personDAL.Delete(person);  
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Person>> GetAll()
        {
            return new SuccessDataResult<List<Person>>(_personDAL.GetAllWithPosition().ToList());
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
