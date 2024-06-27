using System.ComponentModel.DataAnnotations;

namespace CQRS_MediatR.Controllers.New.Request
{
    public class CreateOrUpdateNewRequest
    {
        [Required(ErrorMessage = "this title is required !!")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "this content is required !!")]
        public string? Content { get; set; }

        [Required(ErrorMessage = "this Category is required !!")]
        public string? Category { get; set; }
    }
}
