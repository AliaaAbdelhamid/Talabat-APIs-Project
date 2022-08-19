using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Specifications.Products
{
    public class ProductWithTypeAndBrandSpecifictions : BaseSpecifictions<Product>
    {
        public ProductWithTypeAndBrandSpecifictions(ProductSpecifictionsParamters productParamters)
            : base(b =>
            (string.IsNullOrEmpty(productParamters.Search)|| b.Name.ToLower().Contains(productParamters.Search) ) &&
            (!productParamters.TypeId.HasValue || b.ProductTypeId == productParamters.TypeId.Value) &&
            (!productParamters.BrandId.HasValue || b.ProductBrandId == productParamters.BrandId.Value)
            )

        {
            AddInclude(p => p.productType);
            AddInclude(p => p.productBrand);
            AddOrderBy(p => p.Name);
            ApplyPagination(productParamters.PageSize * (productParamters.PageNumber - 1), productParamters.PageSize);

            if (!string.IsNullOrEmpty(productParamters.Sort))
            {
                switch (productParamters.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDec":
                        AddOrderByDec(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }

            }
        }

        public ProductWithTypeAndBrandSpecifictions(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.productType);
            AddInclude(p => p.productBrand);
        }
    }
}
