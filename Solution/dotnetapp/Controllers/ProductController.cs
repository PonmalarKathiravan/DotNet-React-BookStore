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
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

    public ProductController(IProductService _productService)
    {
       this.productService = _productService;
    }

    [HttpGet("products")]
    public IQueryable<ProductModel> GetAll()
    {
        var productList = productService.GetProductList();
        return productList;
    }

    [HttpPost("admin/addProduct")]
    public bool AddProduct(ProductModel newProduct)
    {         
        return productService.AddProduct(newProduct);               
    }   

     [HttpDelete("admin/deleteProduct/{id}")]
    public bool DeleteProduct (int id)
    {
    return productService.DeleteProduct(id);    
    }
   
    [HttpPut("admin/editProduct/{id}")]      
    public bool PutProductDetails(int id, ProductModel myProduct)  
        {  
           return productService.EditProductById(id,myProduct);
        }     
    }
}