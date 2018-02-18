using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SuperDevStore
{
    public class UserAuth
    {
        #region Singloton
        private static UserAuth instance;

        public static UserAuth Instance
        {
            get
            {
                if (instance == null) instance = new UserAuth();

                return instance;
            }
        }
        #endregion

        #region Methods
        // Attempt to login with a given email and password. Return true if credentials are valid and false if not
        public bool Attempt(string email, string password)
        {
            string sql = "SELECT * FROM users WHERE email = @email AND password = HASHBYTES('SHA2_512', @password)";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value = email},
                new SqlParameter() {ParameterName = "@password", SqlDbType = SqlDbType.VarChar, Value = password},
            };

            DataTable userDB = DB.Instance.ExecQuery(sql, parameters);

            if (userDB != null && userDB.Rows.Count != 0)
            {
                HttpContext.Current.Session["user_id"] = userDB.Rows[0]["id"].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }

        // Return true if a User is logged and false if not
        public bool Check()
        {
            return HttpContext.Current.Session["user_id"] != null;
        }

        // Logout
        public void Destroy()
        {
            HttpContext.Current.Session["user_id"] = null;
        }

        // Return logged User
        public User User()
        {
            DataTable userDB = DB.Instance.ExecQuery($"SELECT * FROM users WHERE id = {HttpContext.Current.Session["user_id"]}");

            User user = new User(int.Parse(userDB.Rows[0]["id"].ToString()), userDB.Rows[0]["name"].ToString(), userDB.Rows[0]["email"].ToString(), userDB.Rows[0]["password"].ToString(), bool.Parse(userDB.Rows[0]["active"].ToString()));

            return user;
        }
        #endregion
    }
}