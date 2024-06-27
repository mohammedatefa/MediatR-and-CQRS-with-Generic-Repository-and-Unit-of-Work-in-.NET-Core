using AutoMapper;
using CQRS_MediatR.Controllers.New.Request;
using CQRS_MediatR.Models;

namespace CQRS_MediatR.Utilities.Mapper
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {

            CreateMap<News, CreateOrUpdateNewRequest>().ReverseMap();

        }
    }
}
