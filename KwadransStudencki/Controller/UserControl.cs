using System;
using System.Collections.Generic;
using System.Text;

namespace KwadransStudencki.Controller
{
    class UserControl
    {
        private bool IsUser { get; set; }
        private bool IsLecturer { get; set; }
        private bool IsAdmin { get; set; }
        public void SetIsUser(bool isUser)
        {
            IsUser = true;
        }
        public bool GetIsUser()
        {
            return IsUser;
        }
    }
}
