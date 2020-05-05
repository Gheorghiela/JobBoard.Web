using JobBoard.BusinessLogic.Interfaces;
using JobBoard.BusinessLogic.LogicBL;

namespace JobBoard.BusinessLogic
{
    public class BussinesLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }

        public IRegister GetRegisterBL()
        {
            return new RegisterBL();
        }
    }
}
