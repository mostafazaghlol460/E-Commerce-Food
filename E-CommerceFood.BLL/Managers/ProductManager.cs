using E_CommerceFood.DAL.Repositories;
using E_CommerceFood.DAL.Model;
using E_CommerceFood.DAL;
using E_CommerceFood.BLL.Dtos.ProductDtos;

namespace E_CommerceFood.BLL.Managers
{
    public class ProductManager
    {
        IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<ProductGetAll> GetAll() 
        {
            List<Product> products = _productRepository.GetAll();
            List<ProductGetAll> productGetAlls = new List<ProductGetAll>();

            foreach(Product product in products)
            {
                var productlist = new ProductGetAll
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Descrption,
                    Image = product.Image,
                    CategoryId = product.CategoryId
                };
                productGetAlls.Add(productlist);

            }
          return productGetAlls;
        }
        public ProductDetailsDto GetById(int id)
         {
            Product product = _productRepository.GetById(id);
            var productdto = new ProductDetailsDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Descrption,
                Image = product.Image,
                CategoryId = product.CategoryId
               
            };
                 
            return productdto;
         }
        public ProductAddDto create(ProductCreateDto productCreateDto)
        {
            if (productCreateDto == null)
                throw new ArgumentNullException(nameof(ProductCreateDto));

            var productdb = new Product()
            {
                Name = productCreateDto.Name,
                Descrption = productCreateDto.Description,
                Image = productCreateDto.Image,
                Price = productCreateDto.Price,
                CategoryId = productCreateDto.CategoryId

            };
            _productRepository.Add(productdb);
            _productRepository.Save();

            var result = new ProductAddDto()
            {
                Name = productdb.Name,
                Description = productdb.Descrption, Price = productdb.Price,
                Image = productdb.Image,
            };
            return result; 
            
        }
        public Product Delete(int id)
        {
            var data= _productRepository.GetById(id);

            if (data != null)
            {
                
                _productRepository.Delete(id);
                return data;
            }
             
            
            return null;
        }
        public ProductUpdateDto Update( ProductUpdateDto productUpdateDto , int id)
        {
            //if (productUpdateDto == null)
            //    return null;
            var productdb = _productRepository.GetById(id);
            
            productdb.Name=productUpdateDto.Name;
            productdb.Descrption=productUpdateDto.Description;
            productdb.Price=productUpdateDto.Price;
            productdb.Image=productUpdateDto.Image;
            productdb.CategoryId=productUpdateDto.CategoryId;

            _productRepository.Update(productdb, id);
            

            return productUpdateDto;


        }

    }
}
