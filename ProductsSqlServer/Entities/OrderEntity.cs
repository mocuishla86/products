using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProductsSqlServer.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ClientId { get; set; } 
        public ClientEntity Client { get; set; } = null!; 
    }
}
