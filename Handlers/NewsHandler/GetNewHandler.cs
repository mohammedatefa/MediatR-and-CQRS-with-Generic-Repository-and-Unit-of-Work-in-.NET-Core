using AutoMapper;
using CQRS_MediatR.Models;
using CQRS_MediatR.Queries.NewsQueries;
using CQRS_MediatR.Utilities.UOW;
using MediatR;

namespace CQRS_MediatR.Handlers.NewsHandler
{
    public class GetNewHandler : BaseNewsHandler,IRequestHandler<GetNewQuery, News>
    {
        public GetNewHandler(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<News> Handle(GetNewQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.NewId);
            return data;
        }
    }
}
