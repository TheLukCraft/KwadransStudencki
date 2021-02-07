using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KwadransStudencki.Model
{
    class Lecturers
    {
        [PrimaryKey, AutoIncrement]
        public int IdLecturers { get; set; }
        public int IdUser { get; set; }
        public string AcademicTitle { get; set; }
        public string Name { get; set; }
    }
}
