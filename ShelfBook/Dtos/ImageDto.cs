using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShelfBook.Dtos
{
    public class ImageDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public string ImagePath { get; set; }
    }
}