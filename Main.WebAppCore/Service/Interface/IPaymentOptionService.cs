using Common;

namespace FineArtsWebApp
{
    public interface IPaymentOptionService
    {
        Task<List<PackageDetailViewModel>> GetUserActivePackages(int userID);

        Task<int> GetUserCurrentMonthFreePublishedPostCount(int userID);

        Task<double> GetUserAccountBalance(int userID, EnumCountry country);

        Task<bool> IncreaseUserFreePostCount(long userPackageID);

        Task<bool> IncreaseUserPremiumPostCount(long userPackageID);
    }
}
