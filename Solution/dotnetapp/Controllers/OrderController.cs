using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;
using Microsoft.AspNetCore.Cors;
using dotnetapp.Services;
namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

    public OrderController(IOrderService _orderService)
    {
      this.orderService = _orderService;
    }

    [HttpGet("/user/{id}/orders")]
    public List<OrderModel> GetAllOrderItemsByUser(string id)
    {
        var productList = orderService.GetOrderListByID(id);
        return productList;
    }

    [HttpPost("/user/addorder")]
    public bool AddOrder(List<OrderModel> newOrder)
    {   
        return orderService.AddOrderList(newOrder);         
    }  

    [HttpDelete("/user/deleteorder/{id}")]
    public void DeleteOrderItem(int id)
    {       
           orderService.DeleteOrder(id);   
    }

    [HttpDelete("/user/deleteall")]
    public void DeleteALLOrders()
    {        
         orderService.DeleteEveryOrders();  
    }
   
    }
}