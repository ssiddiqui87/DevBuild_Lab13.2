using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class ProductController : Controller
    {

        IConfiguration ConfigRoot;
        SqlConnection connection;

        public ProductController(IConfiguration config)
        {
            ConfigRoot = config;
            connection = new SqlConnection(ConfigRoot.GetConnectionString("CoffeeShopDB"));
        }
        public IActionResult Index()
        {
            string queryString = "SELECT * FROM Products";
            var Product = connection.Query<Products>(queryString);

            ViewData["Products"] = Product;
            return View("ProductsIndex");
        }
    }
}