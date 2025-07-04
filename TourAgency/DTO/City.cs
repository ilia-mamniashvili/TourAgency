﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO;

public sealed class City
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [Column(TypeName = "char(3)")]
    public string IsoCode { get; set; } = null!;

    public EntityStatus Status { get; set; } = null!;

    [Required]
    public Country Country { get; set; } = null!;

    public ICollection<Hotel>? Hotels { get; set; }
}