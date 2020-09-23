namespace Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;

    public class VoyagePlan : BaseEntity
    {
        public int Id { get; set; }
        
        public int? CityFromId { get; set; }
        
        public int? CityToId { get; set; }
        
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int NumberOfSeats { get; set; }

        public bool Publish { get; set; }

        public string UserId { get; set; }

        [ForeignKey("CityFromId")]
        public virtual City CityFrom { get; set; }

        [ForeignKey("CityToId")]
        public virtual City CityTo { get; set; }

    }
}
