using dotnetapp.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace dotnetapp.Services
{
    public class OrderService : IOrderService
    {
        private readonly Repository _DbContext;

        public OrderService(Repository dbContext)
        {
            _DbContext = dbContext;
        }
        public List<OrderModel> GetOrderListByID(string id)
        {
           return this._DbContext.OrderModels.Where(m => m.userId==id).ToList();
        }
        
        public bool AddOrderList(List<OrderModel> newOrder)
        {
             OrderModel item= new OrderModel();   
                for(int i=0;i<newOrder.Count;i++)
                {
            item.orderId=newOrder[i].orderId;
            item.productName=newOrder[i].productName;
            item.userId=newOrder[i].userId;
            item.price=newOrder[i].price;
            item.quantity=newOrder[i].quantity;
            this._DbContext.OrderModels.Add(item);
                } 
            this._DbContext.SaveChanges();
            return true;         
        }

        public void DeleteOrder(int Id)
        {
            var user = this._DbContext.OrderModels.Find(Id);
            //int cid=Convert.ToInt32(user.orderId);
            this._DbContext.OrderModels.Remove(user);
            this._DbContext.SaveChanges();
        }

        public void DeleteEveryOrders()
        {
            foreach (OrderModel item in this._DbContext.OrderModels)
            {
            this._DbContext.OrderModels.Remove(item);
            }            
            this._DbContext.SaveChanges();
        }
    }
}