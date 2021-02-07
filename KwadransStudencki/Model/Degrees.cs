using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KwadransStudencki.Model
{
    class Degrees
    {
        [PrimaryKey, AutoIncrement]
        public int IdDegrees { get; set; }
        public string Degree { get; set; }
    }
}
