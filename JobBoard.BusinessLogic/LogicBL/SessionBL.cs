using eUseControl.BusinessLogic.Core;
using JobBoard.BusinessLogic.Core;
using JobBoard.BusinessLogic.Interfaces;
using JobBoard.Domain.Entities.User;
using System;
using System.Web;

namespace JobBoard.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
        public object GetUserByCookie(string value)
        {
            throw new NotImplementedException();
        }

        public object ULoginData(ULoginData data)
        {
            throw new NotImplementedException();
        }

        public ULoginResp UserLogin(ULoginData data)
        {
            return UserLoginAction(data);
        }

        object ISession.UserLogin(ULoginData data)
        {
            throw new NotImplementedException();
        }

        private new ULoginResp UserLoginAction(ULoginData data)
        {
            throw new NotImplementedException();
        }

        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public ULogoutResp UserLogout(string user)
        {
            return UserLogoutAction(user);
        }
    }
}
