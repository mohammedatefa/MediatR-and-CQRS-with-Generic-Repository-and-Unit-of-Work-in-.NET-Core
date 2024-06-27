using AutoMapper;
using CQRS_MediatR.Commands.NewCommands;
using CQRS_MediatR.Utilities.UOW;
using MediatR;

namespace CQRS_MediatR.Handlers.NewsHandler
{
    public class DeleteNewInfoHandler : BaseNewsHandler, IRequestHandler<DeleteNewsInfoRequest, bool>
    {
        public DeleteNewInfoHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper) { }

        public async Task<bool> Handle(DeleteNewsInfoRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.NewId);
            await _unitofwork.SaveChanges();
            return true;
        }
    }
}
