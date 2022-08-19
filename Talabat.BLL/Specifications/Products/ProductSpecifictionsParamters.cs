using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.BLL.Specifications.Products
{
    public class ProductSpecifictionsParamters
    {
        private int pageSize = 5;

        public string Sort { get; set; }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public int PageSize { get => pageSize; set => pageSize = value > 50 ? 50:value; }
        public int PageNumber { get; set; } = 1;

        private string search;

        public string Search       
        {
            get { return search; }
            set { search = value.ToLower(); }
        }

    }
}
