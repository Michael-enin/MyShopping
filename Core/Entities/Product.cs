
namespace Core.Entities
{
    public class Product : BaseEntity
    {

        public string? Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string pictureUrl { get; set; } = string.Empty;
        public ProductType ProductType { get; set; }
        public int productTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int productBrandId { get; set; }
    }
}