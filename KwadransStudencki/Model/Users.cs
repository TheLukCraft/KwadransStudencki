using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KwadransStudencki.Model
{
    class Users
    {
        [PrimaryKey, AutoIncrement]
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string TypeAccount { get; set; }
        public override string ToString()
        {
            return Login;
        }
    }
}
