using CQRS_MediatR.Controllers.New.Request;
using CQRS_MediatR.Controllers.New.Response;
using MediatR;

namespace CQRS_MediatR.Commands.NewCommands
{
    public class UpdateNewsInfoRequest:IRequest<NewsInfoResponse>
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
