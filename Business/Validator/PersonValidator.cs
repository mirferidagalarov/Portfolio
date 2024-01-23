using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator
{
    public class PersonValidator:AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x=>x.FirstName)
                .NotEmpty().WithMessage("first name required")
                .MinimumLength(3).WithMessage("min 3 simvol");
            RuleFor(x=>x.LastName).NotNull().NotEmpty().MinimumLength(5).WithMessage("min 5 simvol");
            RuleFor(x=>x.Address).NotNull().NotEmpty().MinimumLength(5).MaximumLength(100).WithMessage("Min 5 simvol-MAX 100 simvol");
            RuleFor(x => x.Address).NotNull().NotEmpty();
            RuleFor(x => x.ProfilPath).NotEmpty();
            RuleFor(x => x.CvPath).NotEmpty();
        }
    }
}
