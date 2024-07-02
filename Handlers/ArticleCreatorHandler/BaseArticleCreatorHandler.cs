using AutoMapper;
using CQRS_MediatR.Models;
using CQRS_MediatR.Repository;
using CQRS_MediatR.Utilities.UOW;

namespace CQRS_MediatR.Handlers
{
    public class BaseArticleCreatorHandler
    {
        protected readonly IUnitOfWork _unitofwork;
        protected readonly IMapper _mapper;
        protected readonly IGenericRepository<ArticleCreater> _repository;

        public BaseArticleCreatorHandler(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
            _repository = unitofwork.Repository<ArticleCreater>();
        }
    }
}
