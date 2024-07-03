using System.Net;

namespace CQRS_MediatR.Exceptions
{
    public class NotFoundException:BaseException
    {
        public NotFoundException(string message):base(message,HttpStatusCode.NotFound)
        {
            
        }
    }
}
