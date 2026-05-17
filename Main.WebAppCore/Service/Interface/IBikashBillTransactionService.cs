using Common;
using Model;

namespace FineArtsWebApp
{
    public interface IBikashBillTransactionService
    {
        Task<bool> AddNewBill(BikashBillTransacton objBill);

        Task<List<BikashBillTransactonViewModel>> GetAllBikashBillList(EnumCurrency currency);

        BikashBillTransacton CreateNewBikashTranEntityObject(BikashBillTransactonViewModel objModelBikashBillTranVM, UserCreditOrder objUserCreditOrderEntity, EnumCountry enumCountry);

        DonateBikashBillTransacton CreateNewDonateBikashTranEntityObject(
            BikashBillTransactonViewModel objModelBikashBillTranVM,
            EnumCountry enumCountry);

        Task<bool> AddNewDonationBill(DonateBikashBillTransacton objBill);
    }
}
