using CQRS_MediatR.Controllers.New.Request;
using CQRS_MediatR.Models;
using MediatR;

namespace CQRS_MediatR.Commands.NewCommands
{
    public class UpdateNewsInfoRequest:IRequest<News>
    {
        public int NewId { get; set; }
        public CreateOrUpdateNewRequest UpdateNewRequest { get; set; }
        public UpdateNewsInfoRequest(int id,CreateOrUpdateNewRequest updateNewRequest)
        {
            NewId = id;
            UpdateNewRequest=updateNewRequest;
        }
    }
}
