using CQRS_MediatR.Models;
using MediatR;

namespace CQRS_MediatR.Commands.NewCommands
{
    public class DeleteNewsInfoRequest:IRequest<bool>
    {
        public int NewId { get; set; }
        public DeleteNewsInfoRequest(int id)
        {
            NewId = id;
        }
    }
}
