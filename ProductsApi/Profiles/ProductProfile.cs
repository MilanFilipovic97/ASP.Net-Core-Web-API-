using AutoMapper;

namespace ProductsApi.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Product, Dtos.ProductDto>();
            CreateMap<Models.Product, Dtos.ProductDtoForCreation>();
            CreateMap<Dtos.ProductDtoForCreation,Models.Product>();
            CreateMap<Dtos.ProductForUpdateDto, Models.Product>();
        }
    }
}
