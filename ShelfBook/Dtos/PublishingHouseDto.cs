using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShelfBook.Dtos
{
    public class PublishingHouseDto
    {
        [Required]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }
}