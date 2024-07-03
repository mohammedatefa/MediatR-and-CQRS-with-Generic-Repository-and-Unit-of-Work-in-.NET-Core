using AutoMapper;
using CQRS_MediatR.Controllers.ArticleCreator.Response;
using CQRS_MediatR.Exceptions;
using CQRS_MediatR.Queries.ArticleCreatorQueries;
using CQRS_MediatR.Utilities.UOW;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CQRS_MediatR.Handlers.ArticleCreatorHandler
{
    public class GetAllArticleCreatorHandler : BaseArticleCreatorHandler, IRequestHandler<GetAllArticleCreatorsRequest, IEnumerable<ArticleCreatorResponse>>
    {
        public GetAllArticleCreatorHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper) { }
        

        public async Task<IEnumerable<ArticleCreatorResponse>> Handle(GetAllArticleCreatorsRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync("News")??throw new NotFoundException($"There Is Not Article Creators  Founded");
            return _mapper.Map<IEnumerable<ArticleCreatorResponse>>(data);
        }
    }
}
