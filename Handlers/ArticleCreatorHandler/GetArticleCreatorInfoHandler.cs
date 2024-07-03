using AutoMapper;
using CQRS_MediatR.Controllers.ArticleCreator.Response;
using CQRS_MediatR.Exceptions;
using CQRS_MediatR.Queries.ArticleCreatorQueries;
using CQRS_MediatR.Utilities.UOW;
using MediatR;

namespace CQRS_MediatR.Handlers.ArticleCreatorHandler
{
    public class GetArticleCreatorInfoHandler : BaseArticleCreatorHandler, IRequestHandler<GetArticleCreatorInfoRequest, ArticleCreatorResponse>
    {
        public GetArticleCreatorInfoHandler(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, mapper) { }
      
        public async Task<ArticleCreatorResponse> Handle(GetArticleCreatorInfoRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id,"News")??throw new NotFoundException($"There Is Not Article Creator Founded With This Id {request.Id}");
            return _mapper.Map<ArticleCreatorResponse>(data);
        }
    }
}
