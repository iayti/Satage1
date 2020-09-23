namespace Application.VoyagePlan.Commands.Update
{
    using FluentValidation;

    public class UpdateVoyagePlanCommandValidator : AbstractValidator<UpdateVoyagePlanCommand>
    {
        public UpdateVoyagePlanCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id is required.");

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
