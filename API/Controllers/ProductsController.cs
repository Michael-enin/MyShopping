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
        [HttpPut("{id}")]
        public string UpdateProduct(int id)
        {
            return "product";
        }
    }


}