using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SuperDevStore
{
    public class ShippingMethod
    {
        public static List<ShippingMethod> All()
        {
            List<ShippingMethod> methods = new List<ShippingMethod>();

            DataTable methodsDB = DB.Instance.ExecQuery("SELECT * FROM shipping_methods");

            foreach (DataRow row in methodsDB.Rows)
            {
                methods.Add(new ShippingMethod(int.Parse(row["id"].ToString()), row["name"].ToString(), bool.Parse(row["active"].ToString())));
            }

            return methods;
        }

        int id { get; }
        string name { get; }
        bool active { get; }

        public ShippingMethod(int Id, string Name, bool Active)
        {
            id = Id;
            name = Name;
            active = Active;
        }

        public List<Order> Orders()
        {
            List<Order> orders = new List<Order>();

            DataTable ordersDB = DB.Instance.ExecQuery($"SELECT * FROM orders WHERE shipping_method = {id}");

            foreach (DataRow row in ordersDB.Rows)
            {
                orders.Add(new Order(int.Parse(row["id"].ToString()), int.Parse(row["user_id"].ToString()), DateTime.Parse(row["date"].ToString()), row["shipping_address"].ToString(), bool.Parse(row["done"].ToString()), int.Parse(row["shipping_method_id"].ToString())));
            }

            return orders;
        }
    }
}