using dotnetapp.Models;
using System.Linq;
using System.Collections.Generic;
namespace dotnetapp.Services
{
    public interface IProductService
    {
        public IQueryable<ProductModel> GetProductList();
        public bool EditProductById(int id,ProductModel product);
        public bool AddProduct(ProductModel product);
        public ProductModel UpdateProduct(ProductModel product);
        public bool DeleteProduct(int Id);
    }

    public interface ICartService
    {
        public List<CartModel> GetCartListByID(string id);
        public string AddCart(CartModel product);
        public void DeleteCart(int Id);
        public void DeleteAllCart();
    }

    public interface IOrderService
    {
        public List<OrderModel> GetOrderListByID(string id);
        public bool AddOrderList(List<OrderModel> product);
        public void DeleteOrder(int Id);
        public void DeleteEveryOrders();
    }
}