using AutoMapper;
using CQRS_MediatR.Commands.ArticleCreatorCommands;
using CQRS_MediatR.Controllers.ArticleCreator.Response;
using CQRS_MediatR.Models;
using CQRS_MediatR.Utilities.UOW;
using CQRS_MediatR.Utilities.Validators;
using MediatR;
using FluentValidation;

namespace CQRS_MediatR.Handlers.ArticleCreatorHandler
{
    public class UpdateArticleCreatorHandler : BaseArticleCreatorHandler, IRequestHandler<UpdateArticleCreatorRequest, ArticleCreatorResponse>
    {
        public UpdateArticleCreatorHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper) { }
       

        public async Task<ArticleCreatorResponse> Handle(UpdateArticleCreatorRequest request, CancellationToken cancellationToken)
        {
            var validation = new ArticleCreatorValidator();
            var validationResualt = validation.Validate(request.updateArticleCreatorRequest);
            if (!validationResualt.IsValid) throw new ValidationException(validationResualt.Errors);

            var data = _mapper.Map<ArticleCreater>(request.updateArticleCreatorRequest);
            await _repository.UpdateAsync(request.Id, data);
            await _unitofwork.SaveChanges();

            return _mapper.Map<ArticleCreatorResponse>(data);
        }
    }
}
