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

        public static DataTable AllDataTable()
        {
            return DB.Instance.ExecQuery("SELECT * FROM products");
        }

        public static List<Product> LowStock()
        {
            List<Product> products = new List<Product>();

            DataTable productsDB = DB.Instance.ExecQuery("SELECT * FROM products WHERE stock < 5");

            foreach (DataRow row in productsDB.Rows)
            {
                products.Add(new Product(int.Parse(row["id"].ToString()), row["name"].ToString(), decimal.Parse(row["price"].ToString()), row["description"].ToString(), int.Parse(row["stock"].ToString()), bool.Parse(row["active"].ToString())));
            }

            return products;
        }

        public static DataTable LowStockDataTable()
        {
            return DB.Instance.ExecQuery("SELECT * FROM products WHERE stock < 5");
        }

        public static Product Find(int Id)
        {
            Product product = null;

            DataTable productDB = DB.Instance.ExecQuery($"SELECT * FROM products WHERE id = {Id}");

            if (productDB != null && productDB.Rows.Count != 0)
            {
                product = new Product(int.Parse(productDB.Rows[0]["id"].ToString()), productDB.Rows[0]["name"].ToString(), decimal.Parse(productDB.Rows[0]["price"].ToString()), productDB.Rows[0]["description"].ToString(), int.Parse(productDB.Rows[0]["stock"].ToString()), bool.Parse(productDB.Rows[0]["active"].ToString()));
            }

            return product;
        }

        public static void Crate(string Name, double Price, string Description, int Stock)
        {
            DB.Instance.ExecSQL($"INSERT INTO products(name, price, description, stock) VALUES('{Name}', {Price}, '{Description}', {Stock})");
        }

        public int id { get; }
        public string name { get; }
        public decimal price { get; }
        public string description { get; }
        public int stock { get; }
        public bool active { get; }

        public Product(int Id, string Name, decimal Price, string Description, int Stock, bool Active)
        {
            id = Id;
            name = Name;
            price = Price;
            description = Description;
            stock = Stock;
            active = Active;
        }

        public void Update(string Name, double Price, string Description, int Stock)
        {
            DB.Instance.ExecSQL($"UPDATE products SET name = '{Name}', price = {Price}, description = '{Description}', stock = {Stock} WHERE id = {id}");
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