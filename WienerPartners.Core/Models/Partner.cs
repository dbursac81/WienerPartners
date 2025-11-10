using System;
using System.ComponentModel.DataAnnotations;

namespace WienerPartners.Core.Models;

public class Partner
{
    public int Id { get; set; }

    [Required, MinLength(2), MaxLength(255)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MinLength(2), MaxLength(255)]
    public string LastName { get; set; } = string.Empty;

    public string? Address { get; set; }

    [Required]
    [RegularExpression(@"^\d{20}$", ErrorMessage = "PartnerNumber mora imati točno 20 znamenki.")]
    public string PartnerNumber { get; set; } = string.Empty;

    public string? CroatianPIN { get; set; }

    [Required]
    [Range(1,2)]
    public int PartnerTypeId { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    [Required, EmailAddress, MaxLength(255)]
    public string CreateByUser { get; set; } = string.Empty;

    public bool IsForeign { get; set; }

    [MinLength(10), MaxLength(20)]
    public string? ExternalCode { get; set; }

    [Required]
    [RegularExpression("^[MFN]$", ErrorMessage = "Gender mora biti M, F ili N.")]
    public string Gender { get; set; } = "N";

    public string FullName => FirstName + " " + LastName;

    public int PoliciesCount { get; set; }

    public decimal PoliciesSum { get; set; }
}
