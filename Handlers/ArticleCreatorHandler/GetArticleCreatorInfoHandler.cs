using AutoMapper;
using CQRS_MediatR.Controllers.ArticleCreator.Response;
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
            var data = await _repository.GetByIdAsync(request.Id,"News");
            return _mapper.Map<ArticleCreatorResponse>(data);
        }
    }
}
