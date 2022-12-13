using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

public partial class Repository : DbContext
{
    public Repository()
    {

    }
    public Repository(DbContextOptions options):base(options)
    {

    }

    public virtual DbSet<CartModel> CartModels {get; set;}
    public virtual DbSet<OrderModel> OrderModels {get; set;}
    public virtual DbSet<ProductModel> ProductModels {get; set;}
    public virtual DbSet<UserModel> UserModels {get; set;}
}