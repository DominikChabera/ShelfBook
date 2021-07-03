using System.ComponentModel.DataAnnotations;

namespace ShelfBook.Models
{
    public class Image
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public string ImagePath { get; set; }
    }
}