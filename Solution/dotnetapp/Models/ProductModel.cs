using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class ProductModel
{
    [Key]
    public int productId { get; set; }
    public string productName { get; set; }
    public string description { get; set; }
    public string price { get; set; }
    public string imageUrl { get; set; }
    public string quantity { get; set; }

}
    
}
