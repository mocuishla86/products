using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApplication.Outbound
{
    public class ProductNotFoundException(Guid productId) : Exception
    {
        public override string Message => $"Product {productId} not found";
    }
}
