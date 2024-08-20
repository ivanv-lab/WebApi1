using WebApi1.DTO;
using WebApi1.Models;

namespace WebApi1.Mappings
{
    public class ProductCategoryMap : IMapper<ProductCategory, ProductCategoryDTO>
    {
        public ProductCategory Map(ProductCategoryDTO dto)
        {
            return new ProductCategory
            {
                Name = dto.Name
            };
        }

        public ProductCategoryDTO Map(ProductCategory model)
        {
            return new ProductCategoryDTO
            {
                Name = model.Name
            };
        }

        public IEnumerable<ProductCategoryDTO> MapList(IEnumerable<ProductCategory> models)
        {
            List<ProductCategoryDTO> result= new List<ProductCategoryDTO>();
            foreach (var model in models)
            {
                result.Add(new ProductCategoryDTO
                {
                    Name = model.Name
                });
            }
            return result;
        }

        public ProductCategory UpdateMap(ProductCategory model, ProductCategoryDTO dto)
        {
            model.Name = dto.Name;
            return model;
        }
    }
}
