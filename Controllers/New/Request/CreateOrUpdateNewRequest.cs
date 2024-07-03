namespace CQRS_MediatR.Controllers.New.Request
{
    public class CreateOrUpdateNewRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }       
        public string Category { get; set; }
        public int ArticleCreaterId { get; set; }
    }
}
