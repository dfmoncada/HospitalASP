using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doctosCrud.Models
{
    public class User
    {
        private int id;
        private string username;
        private string password;
        private string type;

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Type { get => type; set => type = value; }

        public User(int i, string u, string p, string t)
        {
            id = i;
            username = u;
            password = p;
            type = t;
        }

        public User()
        { }
    }
}