using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CQRS_MediatR.Models
{
    public class ArticleCreater
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        [PasswordPropertyText]
        [Required]
        public string?  Password { get; set; }

        public List<News>? News { get; set; } = new List<News>();
    }
}
