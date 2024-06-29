

namespace CQRS_MediatR.Controllers.New.Response
{
    public class NewsInfoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public string ArticleCreatorName { get; set; }
    }
}
