using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Orders
{
    public class OrderItem: BaseEntity<long>
    {
        public long OrderId { set; get; }
        public long CodeId { set; get; }
        [MaxLength(128)]
        public string Name { set; get; }
        public decimal Quantity { set; get; }
        public decimal Price { set; get; }
        [MaxLength(512)]
        public string Image { set; get; }
        public DateTimeOffset FromDate { set; get; }
        public DateTimeOffset ToDate { set; get; }
    }
}
