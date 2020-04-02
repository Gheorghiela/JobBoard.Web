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
    }
}
