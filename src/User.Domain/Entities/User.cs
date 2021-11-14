using System.Collections.Generic;
using User.Domain.Common;

namespace User.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<Rate> BeerRates { get; set; } = new List<Rate>();
    }
}