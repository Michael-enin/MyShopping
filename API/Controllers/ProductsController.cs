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
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _prodBrandsRepo;
        private readonly IGenericRepository<ProductType> _prodTypesRepo;

        public ProductsController(IProductRepository pRepository,
         IGenericRepository<Product> prod,
         IGenericRepository<ProductBrand> prodBrand,
         IGenericRepository<ProductType> prodType)
        {
            _pRepository = pRepository;
            this._productsRepo = prod;
            this._prodBrandsRepo = prodBrand;
            this._prodTypesRepo = prodType;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productsRepo.GetAllAsync();
            // var prod = await _pRepository.GetProductsListAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var products = await _productsRepo.GetByIdAsync(id);
            return Ok(products);
            //return Ok(await _pRepository.GetProductByIdAsync(id));
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {

            //return Ok(await _pRepository.GetProductBrandsAsync());
            var brands = await _prodBrandsRepo.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            // return Ok(await _pRepository.GetProductTypesAsync());
            var types = await _prodTypesRepo.GetAllAsync();
            return Ok(types);
        }
    }


}