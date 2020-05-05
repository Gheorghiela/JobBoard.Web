using JobBoard.Domain.Entities.User;

namespace JobBoard.BusinessLogic.Interfaces
{
    public interface IRegister
    {
        URegisterResp UserRegister(URegisterData data);
    }
}