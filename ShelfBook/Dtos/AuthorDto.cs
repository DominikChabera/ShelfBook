using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShelfBook.Dtos
{
    public class AuthorDto
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        [Required]
        public string ViewFullName { get; set; }
    }
}