using CQRS_MediatR.Controllers.New.Request;
using CQRS_MediatR.Models;
using MediatR;

namespace CQRS_MediatR.Commands.NewComands
{
    public class CreateNewsInfoRequest : IRequest<News>
    {
        public CreateOrUpdateNewRequest CreatNewRequest { get; set; }
        public CreateNewsInfoRequest(CreateOrUpdateNewRequest creatNewRequest)
        {
            CreatNewRequest = creatNewRequest;
        }
    }
}
