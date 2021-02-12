using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KwadransStudencki.Model
{
    class News
    {
        [PrimaryKey, AutoIncrement]
        public int IDNews { get; set; }
        public string DateOfNews { get; set; }
        public string Specialization { get; set; }
        public string Semestr { get; set; }
        public string Degree { get; set; }
        public string Mode { get; set; }
        public string Group { get; set; }
        public string Content { get; set; }
        public string ID_Lecturer { get; set; }
        public string DateWhen { get; set; }
        public string Delay { get; set; }
        public string TypeOfNews { get; set; }
    }
}
