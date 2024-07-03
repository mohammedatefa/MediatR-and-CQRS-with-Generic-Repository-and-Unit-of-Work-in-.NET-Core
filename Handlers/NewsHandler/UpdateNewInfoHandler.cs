using AutoMapper;
using CQRS_MediatR.Commands.NewCommands;
using CQRS_MediatR.Controllers.New.Response;
using CQRS_MediatR.Models;
using CQRS_MediatR.Utilities.UOW;
using CQRS_MediatR.Utilities.Validators;
using MediatR;
using FluentValidation;

namespace CQRS_MediatR.Handlers.NewsHandler
{
    public class UpdateNewInfoHandler : BaseNewsHandler, IRequestHandler<UpdateNewsInfoRequest, NewsInfoResponse>
    {
        public UpdateNewInfoHandler(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, mapper) { }
       
        public async Task<NewsInfoResponse> Handle(UpdateNewsInfoRequest request, CancellationToken cancellationToken)
        {
            var validation = new NewsInfoValidator();
            var validationResualt = validation.Validate(request.UpdateNewRequest);
            if (!validationResualt.IsValid) throw new ValidationException(validationResualt.Errors);
            var newToUpdate = _mapper.Map<News>(request.UpdateNewRequest);
            await _repository.UpdateAsync(request.NewId, newToUpdate);
            await _unitofwork.SaveChanges();

            return _mapper.Map<NewsInfoResponse>(newToUpdate);
        }
    }
}
