using WebApi1.DTO;
using WebApi1.Models;

namespace WebApi1.Mappings
{
    public class ProductMap:IMapper<Product, ProductDTO>
    {
        public Product Map(ProductDTO productDTO)
        {
            return new Product
            {
                CategoryId = productDTO.CategoryId,
                Name = productDTO.Name,
                Count = productDTO.Count,
                Description = productDTO.Description,
                Price = productDTO.Price,
            };
        }
        public ProductDTO Map(Product product)
        {
            return new ProductDTO
            {
                CategoryId = product.CategoryId,
                Name = product.Name,
                Count = product.Count,
                Description = product.Description,
                Price = product.Price,
            };
        }
        public Product UpdateMap(Product product, ProductDTO productDTO)
        {
            product.CategoryId = productDTO.CategoryId;
            product.Name = productDTO.Name;
            product.Count = productDTO.Count;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            return product;
        }
        public IEnumerable<ProductDTO> MapList(IEnumerable<Product> products)
        {
            List<ProductDTO> result= new List<ProductDTO>();
            foreach (Product product in products)
            {
                result.Add(new ProductDTO
                {
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    Count = product.Count,
                    Description = product.Description
                });
            }
            return result;
        }
    }
}
