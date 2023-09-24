using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Title { get; set; }
        public Author Author { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
    }
}
