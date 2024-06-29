using CQRS_MediatR.Controllers.New.Response;

using MediatR;

namespace CQRS_MediatR.Queries.NewsQueries
{
    public class GetAllNewsQuery:IRequest<IEnumerable<NewsInfoResponse>>
    {
    }
}
