using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SuperDevStore
{
    public class Order
    {
        public static List<Order> All()
        {
            List<Order> orders = new List<Order>();

            DataTable ordersDB = DB.Instance.ExecQuery("SELECT * FROM orders");

            foreach (DataRow row in ordersDB.Rows)
            {
                orders.Add(new Order(int.Parse(row["id"].ToString()), int.Parse(row["user_id"].ToString()), DateTime.Parse(row["date"].ToString()), row["shipping_address"].ToString(), bool.Parse(row["done"].ToString()), int.Parse(row["shipping_method_id"].ToString())));
            }

            return orders;
        }

        public static DataTable AllDataTable()
        {
            return DB.Instance.ExecQuery("SELECT * FROM orders");
        }

        public static DataTable AllPendingDataTable()
        {
            return DB.Instance.ExecQuery("SELECT * FROM orders WHERE done = 0");
        }

        public static DataTable AllDoneDataTable()
        {
            return DB.Instance.ExecQuery("SELECT * FROM orders WHERE done = 1");
        }

        public static List<Order> PendingOrders()
        {
            List<Order> orders = new List<Order>();

            DataTable ordersDB = DB.Instance.ExecQuery("SELECT * FROM orders WHERE done = 0");

            foreach (DataRow row in ordersDB.Rows)
            {
                orders.Add(new Order(int.Parse(row["id"].ToString()), int.Parse(row["user_id"].ToString()), DateTime.Parse(row["date"].ToString()), row["shipping_address"].ToString(), bool.Parse(row["done"].ToString()), int.Parse(row["shipping_method_id"].ToString())));
            }

            return orders;
        }

        public static void FinishOrder(int Id)
        {
            // No need to use paramets because we know that Id is a number
            DB.Instance.ExecSQL($"UPDATE orders SET done = 1 WHERE id = {Id}");
        }

        public static void UnfinishOrder(int Id)
        {
            // No need to use paramets because we know that Id is a number
            DB.Instance.ExecSQL($"UPDATE orders SET done = 0 WHERE id = {Id}");
        }

        public int id { get; }
        public int user_id { get; }
        public DateTime date { get; }
        public string shipping_address { get; }
        public bool done { get; }
        public int shipping_method_id { get; }

        public Order(int Id, int UserId, DateTime Date, string ShippingAddress, bool Done, int ShippingMethodId)
        {
            id = Id;
            user_id = UserId;
            date = Date;
            shipping_address = ShippingAddress;
            done = Done;
            shipping_method_id = ShippingMethodId;
        }

        public User User()
        {
            DataTable userDB = DB.Instance.ExecQuery($"SELECT * FROM users WHERE id = {user_id}");

            User user = new User(int.Parse(userDB.Rows[0]["id"].ToString()), userDB.Rows[0]["name"].ToString(), userDB.Rows[0]["email"].ToString(), userDB.Rows[0]["password"].ToString(), bool.Parse(userDB.Rows[0]["active"].ToString()));

            return user;
        }

        public List<OrderDetail> Details()
        {
            List<OrderDetail> details = new List<OrderDetail>();

            DataTable detailsDB = DB.Instance.ExecQuery($"SELECT * FROM order_details WHERE order_id = {id}");

            foreach (DataRow row in detailsDB.Rows)
            {
                details.Add(new OrderDetail(int.Parse(row["id"].ToString()), int.Parse(row["order_id"].ToString()), int.Parse(row["product_id"].ToString()), int.Parse(row["quantity"].ToString()), decimal.Parse(row["unit_price"].ToString())));
            }

            return details;
        }

        public ShippingMethod ShippingMethod()
        {
            DataTable methodDB = DB.Instance.ExecQuery($"SELECT * FROM shipping_methods WHERE id = {shipping_method_id}");

            ShippingMethod method = new ShippingMethod(int.Parse(methodDB.Rows[0]["id"].ToString()), methodDB.Rows[0]["name"].ToString(), bool.Parse(methodDB.Rows[0]["active"].ToString()));

            return method;
        }
    }
}