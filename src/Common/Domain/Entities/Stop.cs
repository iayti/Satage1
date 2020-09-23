namespace Domain.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;

    public class Stop : BaseEntity
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public int VoyagePlanId { get; set; }


        [ForeignKey("VoyagePlanId")]
        public virtual VoyagePlan VoyagePlan { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}
