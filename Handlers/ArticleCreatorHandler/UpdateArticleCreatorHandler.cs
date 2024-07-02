using AutoMapper;
using CQRS_MediatR.Commands.ArticleCreatorCommands;
using CQRS_MediatR.Controllers.ArticleCreator.Response;
using CQRS_MediatR.Models;
using CQRS_MediatR.Utilities.UOW;
using MediatR;

namespace CQRS_MediatR.Handlers.ArticleCreatorHandler
{
    public class UpdateArticleCreatorHandler : BaseArticleCreatorHandler, IRequestHandler<UpdateArticleCreatorRequest, ArticleCreatorResponse>
    {
        public UpdateArticleCreatorHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper) { }
       

        public async Task<ArticleCreatorResponse> Handle(UpdateArticleCreatorRequest request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<ArticleCreater>(request.updateArticleCreatorRequest);
            await _repository.UpdateAsync(request.Id, data);
            await _unitofwork.SaveChanges();
            return _mapper.Map<ArticleCreatorResponse>(data);
        }
    }
}
