using System;
using System.Collections.Generic;
using System.Text;

namespace LaundryApps.Controller
{
    class AuthUserController
    {
        Model.AuthUser auth;

        public AuthUserController()
        {
            auth = new Model.AuthUser();
        }

        public void setLogedUser(string username)
        {
            auth.username = username;
            auth.saveLoged();
        }
        public string getLoginUser()
        {
            return auth.getLoged();
        }
    }
}
