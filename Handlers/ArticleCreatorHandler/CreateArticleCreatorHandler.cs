using AutoMapper;
using CQRS_MediatR.Commands.ArticleCreatorCommands;
using CQRS_MediatR.Controllers.ArticleCreator.Response;
using CQRS_MediatR.Models;
using CQRS_MediatR.Utilities.UOW;
using CQRS_MediatR.Utilities.Validators;
using FluentValidation;
using MediatR;
namespace CQRS_MediatR.Handlers.ArticleCreatorHandler
{
    public class CreateArticleCreatorHandler : BaseArticleCreatorHandler, IRequestHandler<AddArticleCreatorRequest, ArticleCreatorResponse>
    {
        public CreateArticleCreatorHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }

        public async Task<ArticleCreatorResponse> Handle(AddArticleCreatorRequest request, CancellationToken cancellationToken)
        {
            var Validator = new ArticleCreatorValidator();
            var validationResualt = Validator.Validate(request.CreatorRequest);

            if (!validationResualt.IsValid)
            {
                throw new ValidationException(validationResualt.Errors);
            }
            var data = _mapper.Map<ArticleCreater>(request.CreatorRequest);
            await _repository.AddAsync(data);
            await _unitofwork.SaveChanges();
            return _mapper.Map<ArticleCreatorResponse>(data);
        }
    }
}
