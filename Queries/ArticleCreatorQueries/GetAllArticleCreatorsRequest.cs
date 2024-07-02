using CQRS_MediatR.Controllers.ArticleCreator.Response;
using MediatR;

namespace CQRS_MediatR.Queries.ArticleCreatorQueries
{
    public class GetAllArticleCreatorsRequest:IRequest<IEnumerable<ArticleCreatorResponse>>
    {
    }
}
