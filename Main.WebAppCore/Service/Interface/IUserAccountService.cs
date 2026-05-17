using Model;


namespace FineArtsWebApp
{
    public interface IUserAccountService
    {
        //Task<EnumAccountCredential> ValidateUserCredential(string email, string password);

        //Task<EnumAccountCredential> ValidateAdminUserCredential(string email, string password);

        //Task<EnumAccountCredential> ValidateAdminLoginGatewayCredential(string pin, string passcode);

        Task<User> GetAuthorizedUser(string email);

        //Task<bool> GetVerifyUser(string code);

        //Task<string> UpdateVerifyCode(int userId);

        Task<User> GetAuthorizedUser(int userid);

        //Task<bool> IsAccountRegistered(string email);

        Task<bool> UpdateAccount(AccountViewModel account);

      //  Task<bool> UpdateAccountPassword(AccountViewModel account);

        //Task<string> UpdateResetPassword(string email);

        //Task<bool> UpdateAdminUserLoginGatewayPin(long userId, string pin);

       // Task<bool> IsUserEmailAlreadyCreated(string email);

        Task<List<UserReportViewModel>> GetAllUsers(bool allUserTypes);
    }
}
