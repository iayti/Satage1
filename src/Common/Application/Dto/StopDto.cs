namespace Application.Dto
{
    using Domain.Entities;
    using Mapster;

    public class StopDto :IRegister
    {
        public StopDto()
        {
            VoyagePlan = new VoyagePlanDto();
        }

        public int Id { get; set; }

        public int CityId { get; set; }

        public int VoyagePlanId { get; set; }

        public VoyagePlanDto VoyagePlan { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Stop, StopDto>();
        }
    }
}
