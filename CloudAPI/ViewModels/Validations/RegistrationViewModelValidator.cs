
using FluentValidation;
 

namespace CloudAPI.ViewModels.Validations
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(vm => vm.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(vm => vm.FullName).NotEmpty().WithMessage("FullName cannot be empty");
            //RuleFor(vm => vm.LastName).NotEmpty().WithMessage("LastName cannot be empty");
            //RuleFor(vm => vm.Location).NotEmpty().WithMessage("Location cannot be empty");
        }
    }
}
