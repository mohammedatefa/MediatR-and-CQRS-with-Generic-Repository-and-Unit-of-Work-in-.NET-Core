using CQRS_MediatR.Models;
using MediatR;

namespace CQRS_MediatR.Queries.NewsQueries
{
    public class GetAllNewsQuery:IRequest<IEnumerable<News>>
    {
    }
}
