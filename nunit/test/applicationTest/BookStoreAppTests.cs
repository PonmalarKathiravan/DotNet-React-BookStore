using NUnit.Framework;
using Moq;
using dotnetapp.Models;
using dotnetapp.Services;
using dotnetapp.Controllers;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WebAPITest
{
    public class BookStoreAppTests
    {
        private readonly Mock<IProductService> productService;
        private readonly Mock<IOrderService> orderService;
        private readonly Mock<ICartService> cartService;
        ProductController productController;
        OrderController orderController;
        CartController cartController;

        public BookStoreAppTests()
        {
            productService = new Mock<IProductService>();
            orderService=new Mock<IOrderService>();
            cartService=new Mock<ICartService>();
            productController =new ProductController(productService.Object);
            orderController= new OrderController(orderService.Object);
            cartController= new CartController(cartService.Object);
        }
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestCase1_Cart()
        {
            //Arrange
            var productsList =GetCartsData();
            cartService.Setup(x => x.GetCartListByID(productsList[1].userId)).Returns(productsList);
            //Act
            var productResult=cartController.GetAllCartItemsByUser(productsList[1].userId);
            //Assert
            Assert.NotNull(productResult);
            Assert.AreEqual(GetCartsData().Count(),productResult.Count());
            Assert.AreEqual(GetCartsData().ToString(), productResult.ToString());
            Assert.IsTrue(productsList.Equals(productResult));

        }
        [Test]
        public void TestCase2_Cart()
        {
           //Arrange
            var productsList =GetCartsData();
            int id =Convert.ToInt32(productsList[1].cartId);
            cartService.Setup(x => x.DeleteCart(id));
            //Act

            try
            {
            cartController.DeleteCartItem(id);
            Assert.IsTrue(true);
            }
            catch(Exception ex)
            {
            Assert.IsTrue(false);
            }             
        }
        [Test]
        public void TestCase3_Cart()
        {
            //Arrange
            var productsList =GetCartsData();
            string msg="success";
            cartService.Setup(x => x.AddCart(productsList[1])).Returns(msg);
            //Act
            var productResult=cartController.AddtoCart(productsList[1]);
            //Assert
            Assert.NotNull(productResult);
            Assert.AreEqual(msg,productResult);
        }
        private List<CartModel> GetCartsData()
        {
           List<CartModel> productsData = new List<CartModel>
           {
               new CartModel
               {
                   cartId="1",
                   productName="Book1",
                   userId="test@mail.com",
                   price="300",
                   quantity="20"
               },
               new CartModel
               {
                   cartId="2",
                   productName="Book2",
                   userId="test2@mail.com",
                   price="200",
                   quantity="10"
               },
               new CartModel
               {
                   cartId="3",
                   productName="Book3",
                   userId="test3@mail.com",
                   price="400",
                   quantity="30"
               }
           };
           return productsData;
        }
        [Test]
        public void TestCase4_Order()
        {
            //Arrange
            var productsList =GetOrdersData();
            int id =Convert.ToInt32(productsList[1].orderId);
            orderService.Setup(x => x.DeleteOrder(id));
            //Act
            try
            {
            orderController.DeleteOrderItem(id); 
            Assert.IsTrue(true);
            }
            catch(Exception ex)
            {
            Assert.IsTrue(false);
            }       
            //Assert
            orderService.Verify();
        }
        [Test]
        public void TestCase5_Order()
        {
            //Arrange
            var productsList =GetOrdersData();
            orderService.Setup(x => x.AddOrderList(productsList)).Returns(true);
            //Act
            var productResult=orderController.AddOrder(productsList);
            //Assert
            Assert.NotNull(productResult);
            Assert.IsTrue(productResult);
        }
        [Test]
        public void TestCase6_Order()
        {
            //Arrange
            var productsList =GetOrdersData();
            orderService.Setup(x => x.GetOrderListByID(productsList[1].userId)).Returns(productsList);
            //Act
            var productResult=orderController.GetAllOrderItemsByUser(productsList[1].userId);
            //Assert
            Assert.NotNull(productResult);
            Assert.AreEqual(GetOrdersData().Count(),productResult.Count());
            Assert.AreEqual(GetOrdersData().ToString(), productResult.ToString());
            Assert.IsTrue(productsList.Equals(productResult));
        }

        private List<OrderModel> GetOrdersData()
        {
           List<OrderModel> productsData = new List<OrderModel>
           {
               new OrderModel
               {
                   orderId="1",
                   productName="Book1",
                   userId="test@mail.com",
                   price="300",
                   quantity="20"
               },
               new OrderModel
               {
                   orderId="2",
                   productName="Book2",
                   userId="test2@mail.com",
                   price="200",
                   quantity="10"
               },
               new OrderModel
               {
                   orderId="3",
                   productName="Book3",
                   userId="test3@mail.com",
                   price="400",
                   quantity="30"
               }
           };
           return productsData;
        }
        [Test]
        public void TestCase7_Product()
        {
            //Arrange
            var list =GetProductsData();
            var productsList =list.AsQueryable();
            productService.Setup(x => x.GetProductList()).Returns(productsList);
            var productController =new ProductController(productService.Object);
            //Act
            var productResult=productController.GetAll();
            //Assert
            Assert.NotNull(productResult);
            Assert.AreEqual(GetProductsData().Count(),productResult.Count());
            Assert.AreEqual(GetProductsData().ToString(), productResult.ToString());
            Assert.IsTrue(productsList.Equals(productResult));
        }

        [Test]
        public void TestCase8_Product()
        {
            //Arrange
            var productsList =GetProductsData();
            productService.Setup(x => x.AddProduct(productsList[1])).Returns(true);
            //Act
            var result=productController.AddProduct(productsList[1]);
            //Assert
            Assert.NotNull(result);
            Assert.IsTrue(result);
        }
        [Test]
        public void TestCase9_Product()
        {
            //Arrange
            var productsList =GetProductsData();
            productService.Setup(x => x.DeleteProduct(productsList[1].productId)).Returns(true);
            //Act
            var result = productController.DeleteProduct(productsList[1].productId);
            //Assert
            Assert.NotNull(result);
            Assert.IsTrue(result);
        }
        [Test]
        public void TestCase10_Product()
        {
            //Arrange
            var productsList =GetProductsData();
            productService.Setup(x => x.EditProductById(productsList[1].productId,productsList[1])).Returns(true);
            //Act
            var result = productController.PutProductDetails(productsList[1].productId,productsList[1]);
            //Assert
            Assert.NotNull(result);
            Assert.IsTrue(result);
        }
        private List<ProductModel> GetProductsData()
        {
           List<ProductModel> productsData = new List<ProductModel>
           {
               new ProductModel
               {
                   productId =1,
                   productName="Book1",
                   description="Book1 written by Author",
                   price="200",
                   imageUrl="randomimageurladdress",
                   quantity="10"
               },
               new ProductModel
               {
                   productId =2,
                   productName="Book2",
                   description="Book2 written by Author",
                   price="300",
                   imageUrl="randomimageurladdress",
                   quantity="20"
               },
               new ProductModel
               {
                   productId =3,
                   productName="Book3",
                   description="Book3 written by Author",
                   price="400",
                   imageUrl="randomimageurladdress",
                   quantity="30"
               }
           };
           return productsData;
        }
    }
}