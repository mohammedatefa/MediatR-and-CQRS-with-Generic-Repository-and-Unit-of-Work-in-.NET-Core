using AutoMapper;
using CQRS_MediatR.Controllers.New.Response;
using CQRS_MediatR.Exceptions;
using CQRS_MediatR.Queries.NewsQueries;
using CQRS_MediatR.Utilities.UOW;
using MediatR;

namespace CQRS_MediatR.Handlers.NewsHandler
{
    public class GetNewHandler : BaseNewsHandler,IRequestHandler<GetNewQuery, NewsInfoResponse>
    {
        public GetNewHandler(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<NewsInfoResponse> Handle(GetNewQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.NewId, "ArticleCreater")?? throw new NotFoundException($"There Is Not News Founded With This Id {request.NewId}");

            return _mapper.Map<NewsInfoResponse>(data);
        }
    }
}
