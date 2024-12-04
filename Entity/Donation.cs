using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DaanPath.Enum;

namespace DaanPath.Entity
{
    public class Donation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DonationID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        [ForeignKey("NGO")]
        public int NGOID { get; set; }

        [Required]
        public ItemType ItemType { get; set; } // Enum for Item Types

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DonationType DonationType { get; set; } // Enum for Donation Types

        [Required]
        [MaxLength(20)]
        public required Status Status { get; set; } // Pending, Completed

        [Required]
        public DateTime Date { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public NGO NGO { get; set; }
    }
}
