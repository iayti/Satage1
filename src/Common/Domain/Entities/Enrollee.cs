namespace Domain.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;

    public class Enrollee : BaseEntity
    {
        public int Id { get; set; }

        public int VoyagePlanId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("VoyagePlanId")]
        public virtual VoyagePlan VoyagePlan { get; set; }
    }
}
