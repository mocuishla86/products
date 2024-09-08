using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsSqlServer.Entities
{
    public class ClientEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<OrderEntity> Orders { get; } = new List<OrderEntity>();
    }
}
