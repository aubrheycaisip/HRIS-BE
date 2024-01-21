using HRIS_BE.Helpers.Models;

namespace HRIS_BE.Models
{
    public class DemoTable : BaseEntity
    {
        public string FullName { get; set; }
        public Guid UserId { get; set; }
    }
}
