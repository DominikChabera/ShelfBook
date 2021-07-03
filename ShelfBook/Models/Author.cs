using System.ComponentModel.DataAnnotations;

namespace ShelfBook.Models
{
    public class Author
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