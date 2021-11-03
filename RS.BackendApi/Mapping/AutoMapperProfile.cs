using AutoMapper;
using RS.BackendApi.Helpers;
using RS.Data.Entities;
using RS.ViewModels.Dto.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS.BackendApi.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Brand, BrandDto>()
                .ForMember(src => src.ImagePath,
                           opts => opts
                                    .MapFrom(src => ImageHelper
                                                        .GetFileUrl(src.ImageName)
                                            ));
        }
    }
}
