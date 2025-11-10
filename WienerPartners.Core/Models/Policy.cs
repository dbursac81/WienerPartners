using System;
using System.ComponentModel.DataAnnotations;

namespace WienerPartners.Core.Models;

public class Policy
{
    public int Id { get; set; }

    [Required, MinLength(10), MaxLength(15)]
    public string Number { get; set; } = string.Empty;

    [Required]
    public decimal Value { get; set; }

    public int PartnerId { get; set; }

    public DateTime CreatedAtUtc { get; set; }
}
