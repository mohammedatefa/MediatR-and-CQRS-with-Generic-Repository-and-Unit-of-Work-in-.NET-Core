using AutoMapper;
using CQRS_MediatR.Commands.NewComands;
using CQRS_MediatR.Controllers.New.Response;
using CQRS_MediatR.Models;
using CQRS_MediatR.Utilities.UOW;
using CQRS_MediatR.Utilities.Validators;
using MediatR;
using FluentValidation;

namespace CQRS_MediatR.Handlers.NewsHandler
{
    public class CreateNewsInfoHandler : BaseNewsHandler,IRequestHandler<CreateNewsInfoRequest, NewsInfoResponse>
    {
        public CreateNewsInfoHandler(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, mapper) { }
       
        public async Task<NewsInfoResponse> Handle(CreateNewsInfoRequest request, CancellationToken cancellationToken)
        {
            var validation = new NewsInfoValidator();
            var validationResualt = validation.Validate(request.CreatNewRequest);
            if (!validationResualt.IsValid) throw new ValidationException(validationResualt.Errors);

            var newToInserted = _mapper.Map<News>(request.CreatNewRequest);
            await _repository.AddAsync(newToInserted);
            await _unitofwork.SaveChanges();

            return _mapper.Map<NewsInfoResponse>(newToInserted);

        }
    }
}
