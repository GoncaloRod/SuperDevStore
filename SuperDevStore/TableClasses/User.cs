using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperDevStore
{
    public class User
    {
        public int id { get; }
        public string name { get; }
        public string email { get; }
        public string password  { get; }
        public bool active { get; }

        public User(int Id, string Name, string Email, string Password, bool Active)
        {
            id       = Id;
            name     = Name;
            email    = Email;
            password = Password;
            active   = Active;
        }
    }
}