using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class UserModel
{
    [Key]
    public int sno { get; set; }
   public string email { get; set; }
    public string password { get; set; }

    public string username { get; set; }

    public string role { get; set; }

    public string mobileNumber { get; set; }

}
    
}
