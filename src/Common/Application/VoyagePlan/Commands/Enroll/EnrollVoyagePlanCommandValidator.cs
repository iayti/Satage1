namespace Application.VoyagePlan.Commands.Enroll
{
    using FluentValidation;

    public class EnrollVoyagePlanCommandValidator : AbstractValidator<EnrollVoyagePlanCommand>
    {
        public EnrollVoyagePlanCommandValidator()
        {
            RuleFor(v => v.VoyagePlanId)
                .NotEmpty().WithMessage("VoyagePlanId is required.");
        }
    }
}
