
using CloudAPI.ViewModels.Validations;
//using FluentValidation.Attributes;

namespace CloudAPI.ViewModels
{
    //[Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
