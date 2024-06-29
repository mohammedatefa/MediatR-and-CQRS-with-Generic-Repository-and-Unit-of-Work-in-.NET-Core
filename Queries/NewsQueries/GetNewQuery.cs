using CQRS_MediatR.Controllers.New.Response;
using MediatR;

namespace CQRS_MediatR.Queries.NewsQueries
{
    public class GetNewQuery:IRequest<NewsInfoResponse>
    {
        public int NewId { get; set; }
        public GetNewQuery(int newId)
        {
            NewId = newId;
        }
    }
}
