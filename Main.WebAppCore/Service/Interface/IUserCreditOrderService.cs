using Model;

namespace FineArtsWebApp
{
    public interface IUserCreditOrderService
    {
        Task<bool> AddUserCreditOrder(UserCreditOrder userCreditOrder);

        Task<UserCreditOrder> GetSingleUserCreditOrder(long userCreditOrderID);
    }
}
