using CarSales.Application.DataTrasferObjects.Auth;
using FluentValidation;

namespace CarSales.Application.FluentValidators.Auth
{
    public class LoginDtoValidator: AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(p => p.PhoneNumber)
                .NotEmpty()
                .Length(10)
                .WithMessage("Введіть свій номер телефону.");
            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("Введіть свій пароль.");
        }
    }
}