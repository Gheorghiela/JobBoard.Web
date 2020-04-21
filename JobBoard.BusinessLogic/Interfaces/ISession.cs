using JobBoard.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.BusinessLogic.Interfaces
{
    public interface ISession
    {
        object ULoginData(ULoginData data);
        object UserLogin(ULoginData data);
        object GetUserByCookie(string value);
    }
}
