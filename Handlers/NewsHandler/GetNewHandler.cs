using AutoMapper;
using CQRS_MediatR.Controllers.New.Response;
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
            var data = await _repository.GetByIdAsync(request.NewId, "ArticleCreater");

            return _mapper.Map<NewsInfoResponse>(data);
        }
    }
}
