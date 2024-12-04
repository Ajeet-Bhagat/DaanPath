using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DaanPath.Entity
{
    public class Vendor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment ID
        public int VendorID { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [Phone]
        public required string PhoneNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public required string Address { get; set; }

        [Required]
        public bool ApprovedStatus { get; set; } // True if vendor is approved, otherwise False

        // Navigation Property: A vendor can supply multiple products
        public ICollection<Product> Products { get; set; }
    }
}
