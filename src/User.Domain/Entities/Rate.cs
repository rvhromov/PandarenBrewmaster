using User.Domain.Common;

namespace User.Domain.Entities
{
    public class Rate : BaseEntity
    {
        public double Score { get; set; }
        public int BeerId { get; set; }
        public virtual Beer Beer { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}