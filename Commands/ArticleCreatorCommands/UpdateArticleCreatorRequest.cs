using CQRS_MediatR.Controllers.ArticleCreator.Request;
using CQRS_MediatR.Controllers.ArticleCreator.Response;
using MediatR;

namespace CQRS_MediatR.Commands.ArticleCreatorCommands
{
    public class UpdateArticleCreatorRequest:IRequest<ArticleCreatorResponse>
    {
        public int Id { get; set; }
        public CreateOrUpdateCreatorRequest updateArticleCreatorRequest { get; set; }

        public UpdateArticleCreatorRequest(int id, CreateOrUpdateCreatorRequest updateArticleCreatorRequest)
        {
            Id = id;
            this.updateArticleCreatorRequest = updateArticleCreatorRequest;
        }


    }
}
