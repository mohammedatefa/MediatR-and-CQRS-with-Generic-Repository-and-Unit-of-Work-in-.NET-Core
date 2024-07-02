using CQRS_MediatR.Controllers.ArticleCreator.Request;
using CQRS_MediatR.Controllers.ArticleCreator.Response;
using MediatR;

namespace CQRS_MediatR.Commands.ArticleCreatorCommands
{
    public class AddArticleCreatorRequest:IRequest<ArticleCreatorResponse>
    {
        public CreateOrUpdateCreatorRequest CreatorRequest { get; set; }
        public AddArticleCreatorRequest(CreateOrUpdateCreatorRequest creatorRequest)
        {
            CreatorRequest = creatorRequest;
        }

       
    }
}
