using WebApi1.DTO;
using WebApi1.Mappings;
using WebApi1.Models;
using WebApi1.Repositories;

namespace WebApi1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper<Product, ProductDTO> _mapper;
        public ProductService(IProductRepository productRepository,
            IMapper<Product, ProductDTO> mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDTO> Create(ProductDTO productDTO)
        {
            var product=_mapper.Map(productDTO);
            await _productRepository.Add(product);
            return _mapper.Map(product);
        }

        public async Task<bool> Delete(long id)
        {
            var product=await _productRepository.GetById(id);
            if (product != null)
            {
                await _productRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var product=await _productRepository.GetAll();
            return _mapper.MapList(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetByCategoryId(long categoryId)
        {
            var products = await _productRepository.GetByCategoryId(categoryId);
            return _mapper.MapList(products);
        }

        public async Task<ProductDTO> GetById(long id)
        {
            var product = await _productRepository.GetById(id);
            return _mapper.Map(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetByName(string name)
        {
            var products = await _productRepository.GetByName(name);
            return _mapper.MapList(products);
        }

        public async Task<ProductDTO> Update(long id, ProductDTO productDTO)
        {
            var updateProduct = await _productRepository.GetById(id);
            if (updateProduct == null) throw new Exception("Product not found");
            updateProduct=_mapper.UpdateMap(updateProduct, productDTO);
            await _productRepository.Update(updateProduct);
            return _mapper.Map(updateProduct);
        }

        public async Task<IEnumerable<ProductDTO>> SortSearch(string sortOrder,
            string searchString)
        {
            var products=await _productRepository.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString)
                || p.Category.Name.Contains(searchString)
                || p.Price.ToString().Contains(searchString))
                    .ToList();
            }

            switch (sortOrder)
            {
                case "Name":
                    products=products.OrderBy(p=>p.Name)
                        .ToList(); break;
                case "Name_desc":
                    products=products.OrderByDescending(p=>p.Name)
                        .ToList(); break;
                case "CName":
                    products=products.OrderBy(p=>p.Category.Name)
                        .ToList(); break;
                case "CName_desc":
                    products=products.OrderByDescending(p=>p.Category.Name)
                        .ToList(); break;
                case "Price":
                    products=products.OrderBy(p=>p.Price)
                        .ToList(); break;
                case "Price_desc":
                    products=products.OrderByDescending(p=>p.Price)
                        .ToList(); break;
                default:
                    products=products.OrderByDescending(p=>p.Id)
                        .ToList(); break;
            }
            return _mapper.MapList(products);
        }
    }
}
