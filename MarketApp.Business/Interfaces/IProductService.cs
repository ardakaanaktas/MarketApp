using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Business.Interfaces
{
    public interface IProductService
    {
        List<Dtos.ProductDto> GetAll();
        List<Dtos.ProductDto> GetProductsByCategory(int categoryId);
    }
}
