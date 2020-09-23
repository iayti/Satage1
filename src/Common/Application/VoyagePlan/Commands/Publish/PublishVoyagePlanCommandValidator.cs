namespace Application.VoyagePlan.Commands.Publish
{
    using FluentValidation;

    public class PublishVoyagePlanCommandValidator : AbstractValidator<PublishVoyagePlanCommand>
    {
        public PublishVoyagePlanCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(v => v.Publish)
                .NotNull();
        }
    }
}
