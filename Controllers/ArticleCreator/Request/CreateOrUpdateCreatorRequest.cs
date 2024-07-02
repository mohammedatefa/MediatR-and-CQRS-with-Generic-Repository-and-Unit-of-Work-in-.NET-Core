
namespace CQRS_MediatR.Controllers.ArticleCreator.Request
{
    public class CreateOrUpdateCreatorRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
