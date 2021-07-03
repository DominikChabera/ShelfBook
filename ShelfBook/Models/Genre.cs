using System.ComponentModel.DataAnnotations;

namespace ShelfBook.Models
{
    public class Genre
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}