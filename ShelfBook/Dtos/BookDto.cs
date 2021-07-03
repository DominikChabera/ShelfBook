using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShelfBook.Dtos
{
    public class BookDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public PriceDto Price { get; set; }
        [Required]
        public int PriceId { get; set; }
        public ImageDto Image { get; set; }
        [Required]
        public int ImageId { get; set; }
        public AuthorDto Author { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public string ISBN { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "Birthdate")]
        public DateTime? ReleaseDate { get; set; }
        public PublishingHouseDto PublishingHouse { get; set; }
        [Required]
        public int PublishingHouseId { get; set; }
        public GenreDto Genre { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}