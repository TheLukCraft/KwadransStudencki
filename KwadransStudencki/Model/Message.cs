using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KwadransStudencki.Model
{
    class Message
    {
        [PrimaryKey, AutoIncrement]
        public int IdMessages { get; set; }
        public string Time { get; set; }
        public string ID_Sender { get; set; }
        public string ID_Reciever { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
