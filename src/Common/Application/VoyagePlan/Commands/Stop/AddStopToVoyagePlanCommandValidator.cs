namespace Application.VoyagePlan.Commands.Stop
{
    using Dto;
    using FluentValidation;

    public class AddStopToVoyagePlanCommandValidator :AbstractValidator<StopDto>
    {
        public AddStopToVoyagePlanCommandValidator()
        {
            RuleFor(v => v.CityId)
                .NotEmpty().WithMessage("CityId is required.");

            RuleFor(v => v.VoyagePlanId)
                .NotEmpty().WithMessage("VoyagePlanId is required.");
        }
    }
}
