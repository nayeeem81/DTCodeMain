
using Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FineArtsWebApp
{
    public class BikashBillTransactonViewModel : BaseViewModel
    {
        public BikashBillTransactonViewModel()
        {
            UserOrderModel = new UserOrderViewModel();
            ContentInfoViewModel = new ContentInfoViewModel();
        }


        public long UserOrderID { get; set; }

        public long UserCreditOrderID { get; set; }

        public long BikashBillId { get; set; }

        [Display(Name = "PayableAmount")]
        public string PayableAmount { get; set; }

        [Display(Name = "MonthlyFee")]
        public double? MonthlyFee { get; set; }

        [Display(Name = "YearlyFee")]
        public double? YearlyFee { get; set; }

        [Display(Name = "DisplayCurrency")]
        public string DisplayCurrency { get; set; }

        [Display(Name = "DisplaySubCategory")]
        public string DisplaySubCategory { get; set; }

        [Required]
        [Display(Name = "TransactionNumber")]
        public string TransactionNumber { get; set; }

        [Display(Name = "AgentNumber")]
        public string AgentNumber { get; set; }

        public IEnumerable<SelectListItem> AV_PaymentTime { get; set; }

        public string Paymentway { get; set; }

        [Required]
        [Display(Name = "PaidAmount")]
        public double? PaidAmount { get; set; }

        public string FormattedPaidAmountValue { get; set; }

        [Display(Name = "Entry Date:")]
        public DateTime EntryDateTime { get; set; }

        public EnumTransactionStatus AdminApprovalStatus { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public int UserId { get; set; }

        public int? PostId { get; set; }

        public int? SubCatId { get; set; }

        public UserOrderViewModel UserOrderModel { get; set; }

        public bool ShowRechargeUserMessage { get; set; }

        public double? PostPrice { get; set; }

        public double? PremiumPostPrice { get; set; }

        public ContentInfoViewModel ContentInfoViewModel { get; set; }

        public decimal ProductCartFinalTotalBillAmount { get; set; }
    }
}
