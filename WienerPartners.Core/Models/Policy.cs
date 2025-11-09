using System;
using System.ComponentModel.DataAnnotations;

namespace WienerPartners.Core.Models
{
    public class Policy
    {
        public int Id { get; set; }

        [Required, MinLength(10), MaxLength(15)]
        public string PolicyNumber { get; set; } = string.Empty;

        [Required]
        public decimal PolicyAmount { get; set; }

        public int PartnerId { get; set; }

        public DateTime CreatedAtUtc { get; set; }
    }
}
