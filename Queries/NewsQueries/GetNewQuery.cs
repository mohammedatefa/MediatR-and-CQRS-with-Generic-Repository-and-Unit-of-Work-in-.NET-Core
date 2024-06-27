using CQRS_MediatR.Models;
using MediatR;

namespace CQRS_MediatR.Queries.NewsQueries
{
    public class GetNewQuery:IRequest<News>
    {
        public int NewId { get; set; }
        public GetNewQuery(int newId)
        {
            NewId = newId;
        }
    }
}
