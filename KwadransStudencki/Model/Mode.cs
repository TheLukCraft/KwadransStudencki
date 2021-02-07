using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KwadransStudencki.Model
{
    class Mode
    {
        [PrimaryKey, AutoIncrement]
        public int IdMode { get; set; }
        public string ModeOfStudy { get; set; }
    }
}
