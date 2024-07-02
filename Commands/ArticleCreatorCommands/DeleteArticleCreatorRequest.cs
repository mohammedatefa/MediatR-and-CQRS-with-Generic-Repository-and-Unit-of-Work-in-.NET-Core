using MediatR;

namespace CQRS_MediatR.Commands.ArticleCreatorCommands
{
    public class DeleteArticleCreatorRequest:IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteArticleCreatorRequest(int id)
        {
            Id = id;
        }

    }
}
