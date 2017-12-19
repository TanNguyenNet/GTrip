using NBT.Core.Domain.Orders;
using NBT.Core.Services.ApplicationServices.Orders;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.Orders
{
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        IOrderRepository _orderRepo;
        public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepo) : base(unitOfWork, orderRepo)
        {
            _orderRepo = orderRepo;
        }
    }
}
