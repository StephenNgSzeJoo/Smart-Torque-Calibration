using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm
{
    public static class UserDetails
    {
        // Setting a default value for Username
        private static string _username = "DefaultUser";

        public static string Username
        {
            get { return _username; }
            set { _username = value; }
        }
    }
}

