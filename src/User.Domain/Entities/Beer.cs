using System.Collections.Generic;
using User.Domain.Common;

namespace User.Domain.Entities
{
    public class Beer : BaseEntity
    {
        public string Name { get; set; }
        public string ExternalId { get; set; }
        public virtual ICollection<Rate> UserRates { get; set; } = new List<Rate>();
    }
}