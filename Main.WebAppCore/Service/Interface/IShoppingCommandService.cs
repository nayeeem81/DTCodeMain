using Common;

namespace FineArtsWebApp
{
    public interface IShoppingCommandService
    {
        Task<bool> ExecuteShopCompletedCommand(List<CartSingleItemViewModel> ListCartItems,
            ShippingAddressViewModel shippingAddressViewModel,
            string bKashTransactionNumber,
            bool billPaid,
            EnumCountry country);
    }
}
