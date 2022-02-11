using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2.Entities
{
    public class User
    {
        private readonly string _email;
        private readonly string _password;

        public string[] DataUser { get; private set; }

        public User(string email, string password)
        {
            this._email = email;
            this._password = password;
            DataUser = new[] { this._email, this._password };
        }
    }
}
