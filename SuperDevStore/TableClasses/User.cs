using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SuperDevStore
{
    public class User
    {
        public static List<User> All()
        {
            List<User> users = new List<User>();

            DataTable usersDB = DB.Instance.ExecQuery("SELECT * FROM users");

            foreach (DataRow row in usersDB.Rows)
            {
                users.Add(new User(int.Parse(row["id"].ToString()), row["name"].ToString(), row["email"].ToString(), row["password"].ToString(), bool.Parse(row["active"].ToString())));
            }

            return users;
        }

        public static bool Create(string Name, string Email, string Password)
        {
            string sql;
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Check if email is available
            sql = "SELECT * FROM users WHERE email = @email";
            parameters = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value = Email}
            };

            bool emailAvailable = DB.Instance.ExecQuery(sql, parameters).Rows.Count == 0;

            if (!emailAvailable) return false;

            // Clear query variables
            sql = null;
            parameters.Clear();

            // Insert user in DB
            sql = "INSERT INTO users(name, email, password) VALUES(@name, @email, HASHBYTES('SHA2_512', @password))";
            parameters = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = Name},
                new SqlParameter() {ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value = Email},
                new SqlParameter() {ParameterName = "@password", SqlDbType = SqlDbType.VarChar, Value = Password},
            };

            DB.Instance.ExecSQL(sql, parameters);

            // Send email to user
            Mail.Instance.Send(Email, "Wellcome to super dev; store", "Wellcome!");

            // Login
            UserAuth.Instance.Attempt(Email, Password);

            return true;
        }

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

        public List<Order> PendingOrders()
        {
            List<Order> orders = new List<Order>();

            DataTable ordersDB = DB.Instance.ExecQuery($"SELECT * FROM orders WHERE user_id = {id} AND done = 0");

            foreach (DataRow row in ordersDB.Rows)
            {
                orders.Add(new Order(int.Parse(row["id"].ToString()), int.Parse(row["user_id"].ToString()), DateTime.Parse(row["date"].ToString()), row["shipping_address"].ToString(), bool.Parse(row["done"].ToString()), int.Parse(row["shipping_method_id"].ToString())));
            }

            return orders;
        }

        public DataTable PendingOrdersDB()
        {
            return DB.Instance.ExecQuery($"SELECT * FROM orders WHERE user_id = {id} AND done = 0");
        }

        public List<Order> FinishedOrders()
        {
            List<Order> orders = new List<Order>();

            DataTable ordersDB = DB.Instance.ExecQuery($"SELECT * FROM orders WHERE user_id = {id} AND done = 1");

            foreach (DataRow row in ordersDB.Rows)
            {
                orders.Add(new Order(int.Parse(row["id"].ToString()), int.Parse(row["user_id"].ToString()), DateTime.Parse(row["date"].ToString()), row["shipping_address"].ToString(), bool.Parse(row["done"].ToString()), int.Parse(row["shipping_method_id"].ToString())));
            }

            return orders;
        }

        public DataTable FinishedOrdersDB()
        {
            return DB.Instance.ExecQuery($"SELECT * FROM orders WHERE user_id = {id} AND done = 1");
        }
    }
}