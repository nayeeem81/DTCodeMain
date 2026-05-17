using Model;

namespace FineArtsWebApp
{
    public interface IUserOrderService
    {
        Task<bool> AddUserOrder(UserOrder userOrder);

        Task<bool> UpdateUserOrder(UserOrder userOrder);

        Task<UserOrder> GetSingleUserOrder(long userOrderID);

        Task<bool> DeleteUserOrder(long userOrderID);
    }
}
