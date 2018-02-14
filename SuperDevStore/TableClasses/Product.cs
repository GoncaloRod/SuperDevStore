using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SuperDevStore
{
    public class Product
    {
        public static List<Product> All()
        {
            List<Product> products = new List<Product>();

            DataTable productsDB = DB.Instance.ExecQuery("SELECT * FROM products");

            foreach (DataRow row in productsDB.Rows)
            {
                products.Add(new Product(int.Parse(row["id"].ToString()), row["name"].ToString(), decimal.Parse(row["price"].ToString()), row["description"].ToString(), int.Parse(row["stock"].ToString()), bool.Parse(row["active"].ToString())));
            }

            return products;
        }

        int id { get; }
        string name { get; }
        decimal price { get; }
        string description { get; }
        int stock { get; }
        bool active { get; }

        public Product(int Id, string Name, decimal Price, string Description, int Stock, bool Active)
        {
            id = Id;
            name = Name;
            price = Price;
            description = Description;
            stock = Stock;
            active = Active;
        }

        public List<ProductImage> Images()
        {
            List<ProductImage> images = new List<ProductImage>();

            DataTable imagesDB = DB.Instance.ExecQuery($"SELECT * FROM product_images WHERE product_id = {id}");

            foreach (DataRow row in imagesDB.Rows)
            {
                images.Add(new ProductImage(int.Parse(row["id"].ToString()), row["image"].ToString(), bool.Parse(row["active"].ToString()), int.Parse(row["product_id"].ToString())));
            }

            return images;
        }
    }
}