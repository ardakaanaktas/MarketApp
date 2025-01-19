using MarketApp.Business.Dtos;
using MarketApp.Business.Interfaces;
using MarketApp.DAL.Entities;
using MarketApp.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> ProductRepository)
        {
            _productRepository = ProductRepository;
        }
        public List<ProductDto> GetAll()
        {
            return _productRepository.GetAll().Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                CategoryId = x.CategoryId
            }).ToList();
        }

        public List<ProductDto> GetProductsByCategory(int categoryId)
        {
            return _productRepository.GetAll(x => x.CategoryId == categoryId).Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                CategoryId = x.CategoryId
            }).ToList();
        }
    }
}
