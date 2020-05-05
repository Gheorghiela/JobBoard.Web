using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic.Core;
using JobBoard.Domain.Entities.User;

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
