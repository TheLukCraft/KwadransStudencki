using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KwadransStudencki.Model
{
    class Specialization
    {
        [PrimaryKey, AutoIncrement]
        public int IdSpecialization { get; set; }
        public string NameOfSpecialization { get; set; }
    }
}
