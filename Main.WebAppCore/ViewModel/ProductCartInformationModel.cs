
using Common;

namespace FineArtsWebApp
{
    public class ProductCartInformationViewModel
    {
        public ProductCartInformationViewModel()
        {
            ShoppingCart = new List<CartSingleItemViewModel>();
            Currency = (EnumCurrency)StaticAppSettings.Currency;
        }

        public List<CartSingleItemViewModel> ShoppingCart { get; set; }

        public decimal TotalBill { get; set; }

        public decimal TransportBill { get; set; }

        public decimal FinalBill
        {
            get
            {
                return TotalBill + TransportBill;
            }
        }

        public EnumCurrency Currency { get; set; }
    }
}
