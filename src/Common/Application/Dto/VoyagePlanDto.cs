namespace Application.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Domain.Entities;
    using Mapster;

    public class VoyagePlanDto : IRegister
    {
        public VoyagePlanDto()
        {
            CityFrom = new CityDto();
            CityTo = new CityDto();
        }

        public int Id { get; set; }

        public int? CityFromId { get; set; }

        public int? CityToId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int NumberOfSeats { get; set; }

        public int CurrentCapacity { get; set; }

        public bool Publish { get; set; }

        public string UserId { get; set; }


        public CityDto CityFrom { get; set; }
        public CityDto CityTo { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<VoyagePlan, VoyagePlanDto>();
        }
    }
}
