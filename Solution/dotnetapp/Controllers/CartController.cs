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
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

    public CartController(ICartService _cartService)
    {
       this.cartService = _cartService;
    }

    [HttpGet("user/{id}/cartitems")]
    public List<CartModel> GetAllCartItemsByUser(string id)
    {
        var productList = cartService.GetCartListByID(id);
        return productList;
    }

    [HttpPost("user/addcart")]
    public string AddtoCart(CartModel newCart)
    {       
        return cartService.AddCart(newCart);                                 
    }   

     [HttpDelete("user/deleteCart/{id}")]
    public void DeleteCartItem(int id)
    {       
          cartService.DeleteCart(id);   
    }

    [HttpDelete("user/deleteallcartitems")]
    public void DeleteALL()
    {
         cartService.DeleteAllCart();            
    }
        
    }
}