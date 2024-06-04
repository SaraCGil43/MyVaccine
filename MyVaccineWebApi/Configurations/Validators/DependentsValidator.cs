using FluentValidation;
using MyVaccineWebApi.Dtos.Dependent;

namespace MyVaccineWebApi.Configurations.Validators
{
    public class DependentsDtoValidator : AbstractValidator<DependentRequestDto>
    {
        public DependentsDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().MaximumLength(255);
            RuleFor(dto => dto.DateOfBirth).NotEmpty().GreaterThan(DateTime.Now);
            RuleFor(dto => dto.UserId).NotEmpty().GreaterThan(0);
        }
    }
}
