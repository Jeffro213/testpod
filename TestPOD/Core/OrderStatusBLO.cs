using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestPOD.Entities;
using TestPOD.Repositories;

namespace TestPOD.Core
{
    public class OrderStatusBLO
    {
        IOrderStatusRepository _repository;

        public OrderStatusBLO(IOrderStatusRepository repository)
        {
            int x = 2;
            x = 4;
            _repository = repository;
            //test comment added....changedddd
            x = 35;



        }

        public ItemStatus GetInitialItemStatus()
        {
            return _repository.GetInitialItemStatus();
        }

        public List<ItemStatus> GetAvailableItemStatus(ItemStatus CurrentItemStatus, OrderStatus CurrentOrderStatus, Product Item)
        {
            return _repository.GetAvailableItemStatuses(CurrentItemStatus, CurrentOrderStatus, Item);
        }
    }
}