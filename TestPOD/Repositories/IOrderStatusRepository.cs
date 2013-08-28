using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPOD.Entities;

namespace TestPOD.Repositories
{
    public interface IOrderStatusRepository
    {
        ItemStatus GetInitialItemStatus();

        List<ItemStatus> GetAvailableItemStatuses(ItemStatus CurrentItemStatus, OrderStatus CurrentOrderStatus, Product Item);
    }
}
