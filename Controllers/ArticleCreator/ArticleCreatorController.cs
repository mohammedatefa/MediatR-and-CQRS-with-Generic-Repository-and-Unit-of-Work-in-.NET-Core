
using CQRS_MediatR.Commands.ArticleCreatorCommands;
using CQRS_MediatR.Controllers.ArticleCreator.Request;
using CQRS_MediatR.Queries.ArticleCreatorQueries;
using CQRS_MediatR.Utilities.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR.Controllers.ArticleCreator
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCreatorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ArticleCreatorController> _logger;

        public ArticleCreatorController(IMediator mediator,ILogger<ArticleCreatorController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region Queries 
        [HttpGet]
        [Route("GetArticleCreator")]
        public async Task<IActionResult> GetArticleCreator(int Id)
        {
            var query = new GetArticleCreatorInfoRequest(Id);
            var resualt = await _mediator.Send(query);
            return Ok(new
            {
                Message = "Get Article Creator Info Succeeded",
                Data = resualt
            });
        }

        [HttpGet]
        [Route("GetAllArticleCreators")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllArticleCreatorsRequest();
            var resualt = await _mediator.Send(query);
            return Ok(new
            {
                Message = "Get All Article Creator Info Succeeded",
                Data = resualt
            });
        }
        #endregion

        #region Commands
        [HttpPost]
        [Route("AddArticleCreator")]
        public async Task<IActionResult> Add([FromQuery] CreateOrUpdateCreatorRequest request)
        {
            var Validator = new ArticleCreatorValidator();
            var validationResualt = Validator.Validate(request);

            if (!validationResualt.IsValid)
            {
                return BadRequest(validationResualt.ToDictionary());
            }

            var command = new AddArticleCreatorRequest(request);
            var resualt = await _mediator.Send(command);
            return Ok(new
            {
                Message = "Add New Article_Creator Succeeded",
                Data = resualt
            });
        }
        [HttpPut]
        [Route("UpdateArticleCreator")]
        public async Task<IActionResult> Update(int Id, [FromQuery] CreateOrUpdateCreatorRequest request)
        {
            var Validator = new ArticleCreatorValidator();
            var validationResualt = Validator.Validate(request);

            if (!validationResualt.IsValid)
            {
                return BadRequest(validationResualt.ToDictionary());
            }

            var command = new UpdateArticleCreatorRequest(Id, request);
            var resualt = await _mediator.Send(command);
            return Ok(new
            {
                Message = "Update Article_Creator Succeeded",
                Data = resualt
            });
        }

        [HttpDelete]
        [Route("DeleteArticleCreator")]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteArticleCreatorRequest(Id);
            await _mediator.Send(command);
            return Ok(new
            {
                Message = "Delete Article_Creator Succeeded",
            });
        } 
        #endregion
    }
}
