using AutoMapper;
using CQRS_MediatR.Controllers.ArticleCreator.Request;
using CQRS_MediatR.Controllers.ArticleCreator.Response;
using CQRS_MediatR.Controllers.New.Request;
using CQRS_MediatR.Controllers.New.Response;
using CQRS_MediatR.Models;

namespace CQRS_MediatR.Utilities.Mapper
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            //Mapping News Entity
            CreateMap<News, CreateOrUpdateNewRequest>().ReverseMap();
            CreateMap<News, NewsInfoResponse>()
                .ForMember(dest => dest.ArticleCreatorName, otp => otp.MapFrom(src => src.ArticleCreater.Name));

            //Mapping ArticleCreator Entity
            CreateMap<ArticleCreater, CreateOrUpdateCreatorRequest>().ReverseMap();
            CreateMap<ArticleCreater, ArticleCreatorResponse>();
            CreateMap<News, ArticleCreatorNewsResponse>();

        }
    }
}
