using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SuperDevStore
{
    public class User
    {
        public int id { get; }
        public string name { get; }
        public string email { get; }
        public string password { get; }
        public bool active { get; }

        public User(int Id, string Name, string Email, string Password, bool Active)
        {
            id = Id;
            name = Name;
            email = Email;
            password = Password;
            active = Active;
        }
        
        public List<Product> VisitedProducts()
        {
            List<Product> products = new List<Product>();

            DataTable productsDB = DB.Instance.ExecQuery("SELECT DISTINCT * FROM products");    // TODO: Query

            foreach (DataRow row in productsDB.Rows)
            {
                products.Add(new Product(int.Parse(row["id"].ToString()), row["name"].ToString(), decimal.Parse(row["price"].ToString()), row["description"].ToString(), int.Parse(row["stock"].ToString()), bool.Parse(row["active"].ToString())));
            }

            return products;
        }

        public List<Order> Orders()
        {
            List<Order> orders = new List<Order>();

            DataTable ordersDB = DB.Instance.ExecQuery($"SELECT * FROM orders WHERE user_id = {id}");

            foreach (DataRow row in ordersDB.Rows)
            {
                orders.Add(new Order(int.Parse(row["id"].ToString()), int.Parse(row["user_id"].ToString()), DateTime.Parse(row["date"].ToString()), row["shipping_address"].ToString(), bool.Parse(row["done"].ToString()), int.Parse(row["shipping_method_id"].ToString())));
            }

            return orders;
        }
    }
}