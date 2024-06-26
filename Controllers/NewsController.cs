using CQRS_MediatR.Models;
using CQRS_MediatR.Repository;
using CQRS_MediatR.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<News> repository;

        public NewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            repository=unitOfWork.Repository<News>();
        }

        [HttpGet]
        [Route("GetNew")]
        public async Task<IActionResult> GetAll()
        {
            var data = await repository.GetAllAsync()?? throw new Exception("There Not News ??");
            return Ok(new
            {
                Message = "Return All News",
                Data = data
            });
        }
    }
}
