using AutoMapper;
using CQRS_MediatR.Models;
using CQRS_MediatR.Repository;
using CQRS_MediatR.Utilities.UOW;

namespace CQRS_MediatR.Handlers.NewsHandler
{
    public class BaseNewsHandler
    {
        protected readonly IUnitOfWork _unitofwork;
        protected readonly IMapper _mapper;
        protected readonly IGenericRepository<News> _repository;

        public BaseNewsHandler(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
            _repository = unitofwork.Repository<News>();
        }
    }
}
