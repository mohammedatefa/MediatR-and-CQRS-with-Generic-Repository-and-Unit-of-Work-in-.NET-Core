using AutoMapper;
using Azure.Core;
using CQRS_MediatR.Commands.NewComands;
using CQRS_MediatR.Commands.NewCommands;
using CQRS_MediatR.Controllers.New.Request;
using CQRS_MediatR.Models;
using CQRS_MediatR.Queries.NewsQueries;
using CQRS_MediatR.Repository;
using CQRS_MediatR.Utilities.UOW;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CQRS_MediatR.Controllers.New
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private readonly ILogger<NewsController> _logger;
        private readonly IMediator _mediator;


        public NewsController(ILogger<NewsController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }



        #region Queries Using CQRS
        [HttpGet]
        [Route("GetAllNews")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllNewsQuery();
            var resualt = await _mediator.Send(query)?? throw new Exception("There Are Data Foud !!");
            return Ok(new
            {
                Message = "Return All News",
                Data = resualt
            });
        }
        [HttpGet]
        [Route("GetNew")]
        public async Task<IActionResult> GetById(int id)
        {
            var query =  new GetNewQuery(id);
            var data = await _mediator.Send(query) ?? throw new Exception("There Are No New With This Id !!"); ;
            return Ok(new
            {
                Message = "Return Certain New",
                Data = data
            });
        }
        #endregion

        #region Commands Using CQRS
        [HttpPost]
        [Route("CreateNew")]
        public async Task<IActionResult> Create([FromQuery]CreateOrUpdateNewRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new CreateNewsInfoRequest(request);
            var resualt = await _mediator.Send(command) ?? throw new Exception("there are problem when insert news");

            return Ok(new
            {
                Message = $"{resualt.Title} Created Successfully",
            
            });
        }

        [HttpPut]
        [Route("UpdateNew")]
        public async Task<IActionResult> Update(int id, CreateOrUpdateNewRequest request)
        {
            var command = new UpdateNewsInfoRequest(id, request);
            var resualt = await _mediator.Send(command);
            return Ok(new
            {
                Message = $" New of {resualt.Title} Update Successfully"
            });
        }

        [HttpDelete]
        [Route("DeleteNew")]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteNewsInfoRequest(Id);
            var resualt = await _mediator.Send(command);
            return Ok(new
            {
                Message = "Delete New Successfully",
                Succeded = resualt
            }) ;
        } 
        #endregion 
    }
}
