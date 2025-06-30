using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public sealed class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    }
}
