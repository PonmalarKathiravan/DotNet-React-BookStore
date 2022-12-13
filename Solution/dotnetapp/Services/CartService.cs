using dotnetapp.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace dotnetapp.Services
{
    public class CartService : ICartService
    {
        private readonly Repository _DbContext;

        public CartService(Repository dbContext)
        {
            _DbContext = dbContext;
        }
        public List<CartModel> GetCartListByID(string id)
        {
           return this._DbContext.CartModels.Where(m => m.userId==id).ToList();
        }
        
        public string AddCart(CartModel newCart)
        {
             //check the product is in stock or not   
            int cid=Convert.ToInt32(newCart.cartId);
            // Console.WriteLine(cid);
            ProductModel product =this._DbContext.ProductModels.Find(cid);
            int productQuantity =Convert.ToInt32(product.quantity);
            //Console.WriteLine(productQuantity);
            if(productQuantity > 0 ) 
            {
            product.quantity=(productQuantity-1).ToString();
            this._DbContext.SaveChanges();
            this._DbContext.CartModels.Add(newCart);
            this._DbContext.SaveChanges();
            return "success";    
            }
            else {
			return "insufficient stock";
		    }   
        }

        public void DeleteCart(int Id)
        {
            var user = this._DbContext.CartModels.Find(Id);
            int cid=Convert.ToInt32(user.cartId);
            ProductModel product =this._DbContext.ProductModels.Find(cid);
            int productQuantity =Convert.ToInt32(product.quantity);
            Console.WriteLine(productQuantity);
            product.quantity=(productQuantity+1).ToString();
            this._DbContext.CartModels.Remove(user);
            this._DbContext.SaveChanges();
        }

        public void DeleteAllCart()
        {
            foreach (CartModel item in this._DbContext.CartModels)
            {
            this._DbContext.CartModels.Remove(item);
            }            
            this._DbContext.SaveChanges();
        }
    }
}