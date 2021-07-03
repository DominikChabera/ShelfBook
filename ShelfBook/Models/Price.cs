using System.ComponentModel.DataAnnotations;

namespace ShelfBook.Models
{
    public class Price
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal NormalPrice { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? PromotionalPrice { get; set; }
    }
}