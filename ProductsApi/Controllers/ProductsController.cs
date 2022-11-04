using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProductsApi.Dtos;
using ProductsApi.Models;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(_productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetAuthor")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var productEntities = await _productRepository.GetProductsAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>> (productEntities));
        }
        
        [HttpPost]
        public async Task<ActionResult<Product>> CreateAuthor(ProductDtoForCreation author)
        {
            var authorEntity = _mapper.Map<Models.Product>(author);
            await _productRepository.AddProductAsync(authorEntity);
            _productRepository.Save();

            //var authorToReturn = _mapper.Map<Product>(authorEntity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            if(!await _productRepository.ProductExists(id))
            {
                return BadRequest();
            }

            var product = await _productRepository.GetProductById(id);
            
            if (product == null)
            {
                return NotFound();
            }

            _productRepository.DeleteProduct(product);
            _productRepository.Save();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (!await _productRepository.ProductExists(id))
            {
                return NotFound();
            }

            var product = await _productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDto>(product));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int productId, ProductForUpdateDto product)
        {
            if (!await _productRepository.ProductExists(productId))
            {
                return NotFound();
            }

            var productEntity = await _productRepository.GetProductById(productId);
            _mapper.Map(product, productEntity);

            _productRepository.Save();
            
            return NoContent();
        }

        //[HttpPatch("{id}")]
        //public async Task<ActionResult> PartiallyUpdateProduct(
        //    int productId, 
        //    JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        //{
        //    if (!await _productRepository.ProductExists(productId))
        //    {
        //        return NotFound();
        //    }

        //    var pointOfInterestEntity = await _cityInfoRepository
        //        .GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
        //    if (pointOfInterestEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    var pointOfInterestToPatch = _mapper.Map<PointOfInterestForUpdateDto>(
        //        pointOfInterestEntity);

        //    patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (!TryValidateModel(pointOfInterestToPatch))
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);
        //    await _cityInfoRepository.SaveChangesAsync();

        //    return NoContent();
        //}

    }
}
