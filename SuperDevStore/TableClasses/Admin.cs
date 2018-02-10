using System;
using System.Collections.Generic;
using System.Data;

namespace SuperDevStore
{
    public class Admin
    {
        public static List<Admin> All()
        {
            List<Admin> admins = new List<Admin>();

            DataTable adminsDB = DB.Instance.ExecQuery("SELECT * FROM admins");

            foreach (DataRow row in adminsDB.Rows)
            {
                admins.Add(
                    new Admin(
                        int.Parse(row["id"].ToString()),
                        row["name"].ToString(),
                        row["email"].ToString()
                    )
                );
            }

            return admins;
        }

        public int id { get; }
        public string name { get; }
        public string email { get; }

        public Admin(int Id, string Name, string Email)
        {
            id    = Id;
            name  = Name;
            email = Email;
        }
    }
}