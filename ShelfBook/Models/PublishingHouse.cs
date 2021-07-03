using System.ComponentModel.DataAnnotations;

namespace ShelfBook.Models
{
    public class PublishingHouse
    {
        [Required]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }
}