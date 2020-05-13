using JobBoard.BusinessLogic.Core;
using JobBoard.Domain.Entities.User;
using JobBoard.BusinessLogic.Interfaces;

namespace JobBoard.BusinessLogic.LogicBL
{
    public class RegisterBL : UserApi, IRegister
    {
        public URegisterResp UserRegister(URegisterData data)
        {
            return UserRegisterAction(data);
        }
    }
}
