using AutoMapper;
using CQRS_MediatR.Models;
using CQRS_MediatR.Queries.NewsQueries;
using CQRS_MediatR.Utilities.UOW;
using MediatR;

namespace CQRS_MediatR.Handlers.NewsHandler
{
    public class GetAllNewsHandler : BaseNewsHandler,IRequestHandler<GetAllNewsQuery, IEnumerable<News>>
    {
        public GetAllNewsHandler(IUnitOfWork unitofwork,IMapper mapper):base(unitofwork,mapper)
        {
        }
        public async Task<IEnumerable<News>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            var News = await _repository.GetAllAsync();
           
            return News;
        }
    }
}
