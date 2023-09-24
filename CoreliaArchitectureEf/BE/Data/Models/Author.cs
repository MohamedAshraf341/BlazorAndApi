using System.ComponentModel.DataAnnotations;

namespace BE.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
    }
}
