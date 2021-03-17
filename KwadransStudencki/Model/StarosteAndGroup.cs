using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KwadransStudencki.Model
{
    class StarosteAndGroup
    {
        [PrimaryKey, AutoIncrement]
        public int IdStarosteAndGroup { get; set; }
        public string Staroste { get; set; }
        public string Group { get; set; }
        public override string ToString()
        {
            return Staroste + ", " + Group;
        }
    }
}

