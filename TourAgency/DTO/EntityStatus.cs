using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [ComplexType]
    public sealed class EntityStatus
    {
        public bool IsActive { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }
    }

}
