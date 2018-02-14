using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SuperDevStore
{
    public class OrderDetail
    {
        public static List<OrderDetail> All()
        {
            List<OrderDetail> details = new List<OrderDetail>();

            DataTable detailsDB = DB.Instance.ExecQuery("SELECT * FROM order_details");

            foreach (DataRow row in detailsDB.Rows)
            {
                details.Add(new OrderDetail(int.Parse(row["id"].ToString()), int.Parse(row["order_id"].ToString()), int.Parse(row["product_id"].ToString()), int.Parse(row["quantity"].ToString()), decimal.Parse(row["unit_price"].ToString())));
            }

            return details;
        }

        public int id { get; }
        public int order_id { get; }
        public int product_id { get; }
        public int quantity { get; }
        public decimal unit_price { get; }

        public OrderDetail(int Id, int OrderId, int ProductId, int Quantity, decimal UnitPrice)
        {
            id = Id;
            order_id = OrderId;
            product_id = ProductId;
            quantity = Quantity;
            unit_price = UnitPrice;
        }

        public Order Order()
        {
            DataTable orderDB = DB.Instance.ExecQuery($"SELECT * FROM orders WHERE id = {order_id}");

            Order order = new Order(int.Parse(orderDB.Rows[0]["id"].ToString()), int.Parse(orderDB.Rows[0]["user_id"].ToString()), DateTime.Parse(orderDB.Rows[0]["date"].ToString()), orderDB.Rows[0]["shipping_address"].ToString(), bool.Parse(orderDB.Rows[0]["done"].ToString()), int.Parse(orderDB.Rows[0]["shipping_method_id"].ToString()));

            return order;
        }

        public Product Product()
        {
            DataTable productDB = DB.Instance.ExecQuery($"SELECT * FROM products WHERE id = {product_id}");

            Product product = new Product(int.Parse(productDB.Rows[0]["id"].ToString()), productDB.Rows[0]["name"].ToString(), decimal.Parse(productDB.Rows[0]["price"].ToString()), productDB.Rows[0]["description"].ToString(), int.Parse(productDB.Rows[0]["stock"].ToString()), bool.Parse(productDB.Rows[0]["active"].ToString()));

            return product;
        }
    }
}