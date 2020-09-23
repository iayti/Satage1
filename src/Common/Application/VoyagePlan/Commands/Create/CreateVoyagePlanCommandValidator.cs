namespace Application.VoyagePlan.Commands.Create
{
    using FluentValidation;

    public class CreateVoyagePlanCommandValidator : AbstractValidator<CreateVoyagePlanCommand>
    {
        public CreateVoyagePlanCommandValidator()
        {
            RuleFor(v => v.CityToId)
                .NotEmpty().WithMessage("CityTo is required.");

            RuleFor(v => v.CityFromId)
                .NotEmpty().WithMessage("CityFrom is required.");

            RuleFor(v => v.Date)
                .NotEmpty().WithMessage("Date is required.");

            RuleFor(v => v.NumberOfSeats)
                .NotEmpty().WithMessage("NumberOfSeats is required.");
        }
    }
}
