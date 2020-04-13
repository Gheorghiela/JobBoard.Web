using JobBoard.BusinessLogic.Core;
using JobBoard.BusinessLogic.Interfaces;
using JobBoard.Domain.Entities.User;
using System;

namespace JobBoard.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
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

        private ULoginResp UserLoginAction(ULoginData data)
        {
            throw new NotImplementedException();
        }
    }
}
