namespace Domain.Entities
{
    using System.Collections.Generic;

    using Common;

    public class City : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
