using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BobMarbles.Models
{
    public class Marble
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(30)")]
        public string Color { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(40)")]
        public string Name { get; set; }

        [Column(TypeName ="decimal")]
        public double? Weight  { get; set; }
    }
}
