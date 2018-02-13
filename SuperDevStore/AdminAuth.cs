using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SuperDevStore
{
    public class AdminAuth
    {
        #region Singloton
        private static AdminAuth instance;

        public static AdminAuth Instance
        {
            get
            {
                if (instance == null) instance = new AdminAuth();

                return instance;
            }
        }
        #endregion

        #region Methods
        // Attempt to login with a given email and password. Return true if credentials are valid and false if not
        public bool Attempt(string email, string password)
        {
            DataTable adminDB = DB.Instance.ExecQuery($"SELECT * FROM admins WHERE email = {email} AND password = {password}");

            if (adminDB != null && adminDB.Rows.Count != 0)
            {
                HttpContext.Current.Session["admin_id"] = adminDB.Rows[0]["id"].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }

        // Return true if a Admin is logged and false if not 
        public bool Check()
        {
            return HttpContext.Current.Session["admin_id"] != null;
        }

        // Logout
        public void Destroy()
        {
            HttpContext.Current.Session["admin_id"] = null;
        }

        // Return logged User
        public Admin Admin()
        {
            DataTable adminDB = DB.Instance.ExecQuery($"SELECT * FROM admins WHERE id = {HttpContext.Current.Session["admin_id"]}");

            Admin admin = new Admin(int.Parse(adminDB.Rows[0]["id"].ToString()), adminDB.Rows[0]["name"].ToString(), adminDB.Rows[0]["email"].ToString(), adminDB.Rows[0]["password"].ToString(), bool.Parse(adminDB.Rows[0]["active"].ToString()));

            return admin;
        }
        #endregion
    }
}