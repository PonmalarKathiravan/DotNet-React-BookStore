using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;
using Microsoft.AspNetCore.Cors;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly Repository _DbContext;

    public UserController(Repository dbContext)
    {
       this._DbContext = dbContext;
    }
    [HttpPost("/login")]
    public UserModel CheckLogin(LoginModel loguser)
    {
         //string message = ""; 
            var loginStstus=_DbContext.UserModels.Where(m =>m.email==loguser.email && m.password ==loguser.password).FirstOrDefault();
            if(loginStstus!=null)
            {
               // message="Success";
               return loginStstus;
            }
            else
            {
               // message="Invalid Credential";
            }
         return null;
    }

    [HttpPost("/signup")]
    public UserModel CreateUser(UserModel newuser)
    {
     UserModel lmuser=new UserModel();      
                try
                {
                    this._DbContext.UserModels.Add(newuser);
                    int result = this._DbContext.SaveChanges();
                    if (result > 0)
                    {
                        lmuser.email=newuser.email;
                        lmuser.password=newuser.password;
                        lmuser.role=newuser.role;
                        lmuser.username=newuser.username;
                        return lmuser;
                    }        
                }
                catch (Exception)
                {
                    throw;
                }
            return lmuser;
        }    
    }
}