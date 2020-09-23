namespace Application.Dto
{
    using Domain.Entities;
    using Mapster;

    public class EnrolleeDto :IRegister
    {
        public EnrolleeDto()
        {
            VoyagePlan = new VoyagePlanDto();
        }

        public int Id { get; set; }

        public int VoyagePlanId { get; set; }

        public string UserId { get; set; }

        public VoyagePlanDto VoyagePlan { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Enrollee, EnrolleeDto>();
        }
    }
}
