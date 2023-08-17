using System.Collections.Generic;
using Infrastructure.DataStore;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _shopContext;
        private readonly IProductRepository _pRepository;
        public ProductsController(IProductRepository pRepository)
        {
            _pRepository = pRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var prod = await _pRepository.GetProductsListAsync();
            return Ok(prod);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return Ok(await _pRepository.GetProductByIdAsync(id));
        }
        [HttpPut("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _pRepository.GetProductBrandsAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _pRepository.GetProductTypesAsync());
        }
    }


}