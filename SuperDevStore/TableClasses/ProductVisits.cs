using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SuperDevStore
{
    public class ProductVisits
    {
        public static List<ProductVisits> All()
        {
            List<ProductVisits> visits = new List<ProductVisits>();

            DataTable visitsDB = DB.Instance.ExecQuery($"SELECT * FROM products_visits");

            foreach (DataRow row in visitsDB.Rows)
            {
                visits.Add(new ProductVisits(int.Parse(row["id"].ToString()), int.Parse(row["product_id"].ToString()), int.Parse(row["user_id"].ToString())));
            }

            return visits;
        }

        int id { get; }
        int product_id { get; }
        int user_id { get; }

        public ProductVisits(int Id, int ProductId, int UserId)
        {
            id = Id;
            product_id = ProductId;
            user_id = UserId;
        }

        public User User()
        {
            DataTable userDB = DB.Instance.ExecQuery($"SELECT * FROM users WHERE id = {user_id}");

            User user = new User(int.Parse(userDB.Rows[0]["id"].ToString()), userDB.Rows[0]["name"].ToString(), userDB.Rows[0]["email"].ToString(), userDB.Rows[0]["password"].ToString(), bool.Parse(userDB.Rows[0]["active"].ToString()));

            return user;
        }

        public Product Product()
        {
            DataTable productDB = DB.Instance.ExecQuery($"SELECT * FROM products WHERE id = {product_id}");

            Product product = new Product(int.Parse(productDB.Rows[0]["id"].ToString()), productDB.Rows[0]["name"].ToString(), decimal.Parse(productDB.Rows[0]["price"].ToString()), productDB.Rows[0]["description"].ToString(), int.Parse(productDB.Rows[0]["stock"].ToString()), bool.Parse(productDB.Rows[0]["active"].ToString())));

            return product;
        }
    }
}