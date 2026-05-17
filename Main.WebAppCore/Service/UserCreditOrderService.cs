using Data;
using Model;


namespace FineArtsWebApp
{
    public class UserCreditOrderService : IUserCreditOrderService
    {
        public readonly IUserCreditOrderRepository _UserCreditOrderRepository;

        public UserCreditOrderService(IUserCreditOrderRepository userCreditOrderRepository)
        {
            _UserCreditOrderRepository = userCreditOrderRepository;
        }

        public async Task<bool> AddUserCreditOrder(UserCreditOrder userCreditOrder)
        {
            if (userCreditOrder != null)
            {
                await _UserCreditOrderRepository.AddUserCreditOrder(userCreditOrder);
            }
            return true;
        }

        public async Task<UserCreditOrder> GetSingleUserCreditOrder(long userCreditOrderID)
        {
            return await _UserCreditOrderRepository.GetSingleUserCreditOrder(userCreditOrderID);
        }
    }
}
