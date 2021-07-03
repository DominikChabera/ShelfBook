using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShelfBook.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public Price Price { get; set; }
        [Required]
        public int PriceId { get; set; }
        public Image Image { get; set; }
        [Required]
        public int ImageId { get; set; }
        public Author Author { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public string ISBN { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "Birthdate")]
        public DateTime? ReleaseDate { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        [Required]
        public int PublishingHouseId { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}