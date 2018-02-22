using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

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

            return images;
        }

        public static void Create(string Image, int ProductId)
        {
            string sql = "INSERT INTO product_images(image, product_id) VALUES(@image, @product_id)";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@image", SqlDbType = SqlDbType.VarChar, Value = Image},
                new SqlParameter() {ParameterName = "@product_id", SqlDbType = SqlDbType.Int, Value = ProductId}
            };

            DB.Instance.ExecSQL(sql, parameters);
        }

        public int id { get; }
        public string image { get; }
        public bool active { get; }
        public int product_id { get; }

        public ProductImage(int Id, string Image, bool Active, int ProductId)
        {
            id = Id;
            image = Image;
            active = Active;
            product_id = ProductId;
        }
    }
}