using AutoMapper;
using CQRS_MediatR.Commands.ArticleCreatorCommands;
using CQRS_MediatR.Utilities.UOW;
using MediatR;

namespace CQRS_MediatR.Handlers.ArticleCreatorHandler
{
    public class DeleteArticleCreatorHandler : BaseArticleCreatorHandler, IRequestHandler<DeleteArticleCreatorRequest, bool>
    {
        public DeleteArticleCreatorHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper) { }
        

        public async Task<bool> Handle(DeleteArticleCreatorRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            await _unitofwork.SaveChanges();
            return true;
        }
    }
}
