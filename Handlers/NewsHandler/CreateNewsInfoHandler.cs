using AutoMapper;
using CQRS_MediatR.Commands.NewComands;
using CQRS_MediatR.Models;
using CQRS_MediatR.Utilities.UOW;
using MediatR;

namespace CQRS_MediatR.Handlers.NewsHandler
{
    public class CreateNewsInfoHandler : BaseNewsHandler,IRequestHandler<CreateNewsInfoRequest, News>
    {
        public CreateNewsInfoHandler(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, mapper) { }
       
        public async Task<News> Handle(CreateNewsInfoRequest request, CancellationToken cancellationToken)
        {
            var newToInserted = _mapper.Map<News>(request.CreatNewRequest);
            await _repository.AddAsync(newToInserted);
            await _unitofwork.SaveChanges();

            return newToInserted;

        }
    }
}
