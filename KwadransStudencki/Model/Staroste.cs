using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KwadransStudencki.Model
{
    class Staroste
    {
        [PrimaryKey, AutoIncrement]
        public int IdStaroste { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Specialization { get; set; }
        public int Semestr { get; set; }
        public string Mode { get; set; }
        public string Degree { get; set; }
        public int Group { get; set; }
        public string Login { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
