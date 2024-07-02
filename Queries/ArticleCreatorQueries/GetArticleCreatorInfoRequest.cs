using CQRS_MediatR.Controllers.ArticleCreator.Response;
using CQRS_MediatR.Models;
using MediatR;

namespace CQRS_MediatR.Queries.ArticleCreatorQueries
{
    public class GetArticleCreatorInfoRequest:IRequest<ArticleCreatorResponse>
    {
        public int Id { get; set; }
        public GetArticleCreatorInfoRequest(int Id)
        {
            this.Id = Id;   
        }
    }
}
