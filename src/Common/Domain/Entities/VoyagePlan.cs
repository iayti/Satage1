namespace Domain.Entities
{
    using System;
    using Common;

    public class VoyagePlan : BaseEntity
    {
        public int Id { get; set; }

        public int CityFromId { get; set; }
        public City CityFrom { get; set; }

        public int CityToId { get; set; }
        public City CityTo { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int NumberOfSeats { get; set; }

        public int CurrentCapacity { get; set; }

        public bool Publish { get; set; }

    }
}
