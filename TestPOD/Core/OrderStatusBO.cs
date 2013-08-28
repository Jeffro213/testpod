using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestPOD.Entities;
using TestPOD.Repositories;

namespace TestPOD.Core
{
    public class OrderStatusBO
    {
        IOrderStatusRepository _repository;

        public OrderStatusBO(IOrderStatusRepository repository)
        {
            _repository = repository;
            //test
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