using Common;

namespace FineArtsWebApp
{
    public interface IManageAccountSettingService
    {
        Task<bool> SetAccountViewModel(int userId, AccountViewModel objAccountViewModel,
            DateTime bdDate, EnumCountry? enumCountry, EnumCurrency currency);
    }
}
