using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace DaanPath.Entity
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment ID
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Category { get; set; } // E.g., Blanket, Hygiene Kit

        [Required]
        [Column(TypeName = "decimal(10,2)")] // For storing monetary values
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("Vendor")]
        public int VendorID { get; set; } // Foreign key to Vendor

        [Required]
        public int Stock { get; set; } // Available stock for purchase

        // Navigation Properties
        public Vendor Vendor { get; set; }
    }
}
