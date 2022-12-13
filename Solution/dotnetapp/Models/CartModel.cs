using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class CartModel
{
    [Key]
    public int sno { get; set; }
    public string cartId { get; set; }
    public string productName { get; set; }

    public string userId { get; set; }

    public string price { get; set; }

    public string quantity { get; set; }

}
    
}
