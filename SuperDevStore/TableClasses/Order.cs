using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

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

        public static void Create(string ShippingAddress, int ShippingMethodId, List<Product> Products)
        {
            string sql = "INSERT INTO orders(user_id, date, shipping_address, shipping_method_id) VALUES(@user_id, @date, @shipping_address, @shipping_method_id); SELECT CAST(SCOPE_IDENTITY() AS INT)";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@user_id", SqlDbType = SqlDbType.Int, Value = UserAuth.Instance.User().id},
                new SqlParameter() {ParameterName = "@date", SqlDbType = SqlDbType.Date, Value = DateTime.Now},
                new SqlParameter() {ParameterName = "@shipping_address", SqlDbType = SqlDbType.VarChar, Value = ShippingAddress},
                new SqlParameter() {ParameterName = "@shipping_method_id", SqlDbType = SqlDbType.Int, Value = ShippingMethodId},
            };

            int orderId = int.Parse(DB.Instance.ExecQuery(sql, parameters).Rows[0][0].ToString());

            foreach (Product product in Products)
            {
                OrderDetail.Create(orderId, product.id, 1, (double)product.price);
            }
        }

        public static void FinishOrder(int Id)
        {
            DB.Instance.ExecSQL($"UPDATE orders SET done = 1 WHERE id = {Id}");
        }

        public static void UnfinishOrder(int Id)
        {
            DB.Instance.ExecSQL($"UPDATE orders SET done = 0 WHERE id = {Id}");
        }

        public static Order Find(int Id)
        {
            Order order = null;

            DataTable orderDB = DB.Instance.ExecQuery($"SELECT * FROM orders WHERE id = {Id}");

            if (orderDB != null && orderDB.Rows.Count != 0)
            {
                order = new Order(int.Parse(orderDB.Rows[0]["id"].ToString()), int.Parse(orderDB.Rows[0]["user_id"].ToString()), DateTime.Parse(orderDB.Rows[0]["date"].ToString()), orderDB.Rows[0]["shipping_address"].ToString(), bool.Parse(orderDB.Rows[0]["done"].ToString()), int.Parse(orderDB.Rows[0]["shipping_method_id"].ToString()));
            }

            return order;
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

        public DataTable DetailsDataTable()
        {
            return DB.Instance.ExecQuery($"SELECT order_details.id, order_id, product_id, products.name AS product_name, quantity, unit_price FROM order_details, products WHERE order_id = {id} AND products.id = product_id");
        }

        public ShippingMethod ShippingMethod()
        {
            DataTable methodDB = DB.Instance.ExecQuery($"SELECT * FROM shipping_methods WHERE id = {shipping_method_id}");

            ShippingMethod method = new ShippingMethod(int.Parse(methodDB.Rows[0]["id"].ToString()), methodDB.Rows[0]["name"].ToString(), bool.Parse(methodDB.Rows[0]["active"].ToString()));

            return method;
        }
    }
}