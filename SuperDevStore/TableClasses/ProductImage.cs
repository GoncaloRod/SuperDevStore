using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SuperDevStore
{
    public class ProductImage
    {
        public static List<ProductImage> All()
        {
            List<ProductImage> images = new List<ProductImage>();

            DataTable imagesDB = DB.Instance.ExecQuery("SELECT * FROM product_images");

            foreach (DataRow row in imagesDB.Rows)
            {
                images.Add(new ProductImage(int.Parse(row["id"].ToString()), row["image"].ToString(), bool.Parse(row["active"].ToString()), int.Parse(row["product_id"].ToString())));
            }
        }

        int id { get; }
        string image { get; }
        bool active { get; }
        int product_id { get; }

        public ProductImage(int Id, string Image, bool Active, int ProductId)
        {
            id         = Id;
            image      = Image;
            active     = Active;
            product_id = ProductId;
        }
    }
}