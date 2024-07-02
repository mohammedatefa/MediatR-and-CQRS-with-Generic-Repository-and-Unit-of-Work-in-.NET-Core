
namespace CQRS_MediatR.Controllers.ArticleCreator.Response
{
    public class ArticleCreatorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<ArticleCreatorNewsResponse> News { get; set; }=new List<ArticleCreatorNewsResponse>();

    }
}
