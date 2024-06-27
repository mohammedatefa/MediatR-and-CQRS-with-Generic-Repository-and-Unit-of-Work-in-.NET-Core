using AutoMapper;
using CQRS_MediatR.Commands.NewCommands;
using CQRS_MediatR.Models;
using CQRS_MediatR.Utilities.UOW;
using MediatR;

namespace CQRS_MediatR.Handlers.NewsHandler
{
    public class UpdateNewInfoHandler : BaseNewsHandler, IRequestHandler<UpdateNewsInfoRequest, News>
    {
        public UpdateNewInfoHandler(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, mapper) { }
       
        public async Task<News> Handle(UpdateNewsInfoRequest request, CancellationToken cancellationToken)
        {
            var newToUpdate = _mapper.Map<News>(request.UpdateNewRequest);
            await _repository.UpdateAsync(request.NewId, newToUpdate);
            await _unitofwork.SaveChanges();

            return newToUpdate;
        }
    }
}
