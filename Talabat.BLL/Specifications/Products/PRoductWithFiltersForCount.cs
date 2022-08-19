using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Specifications.Products
{
    public class PRoductWithFiltersForCount : BaseSpecifictions<Product>
    {
        public PRoductWithFiltersForCount(ProductSpecifictionsParamters productParamters)
           : base(b =>
           (string.IsNullOrEmpty(productParamters.Search) || b.Name.ToLower().Contains(productParamters.Search)) &&
           (!productParamters.TypeId.HasValue || b.ProductTypeId == productParamters.TypeId.Value) &&
           (!productParamters.BrandId.HasValue || b.ProductBrandId == productParamters.BrandId.Value)
           )
        { }

    }
}
