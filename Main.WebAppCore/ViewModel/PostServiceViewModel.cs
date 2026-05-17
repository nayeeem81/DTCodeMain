using Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FineArtsWebApp
{
    public class PostServiceViewModel : BaseViewModel
    {
        public PostServiceViewModel()
        {
        }


        public long PostServiceID { get; set; }

        public string Title { get; set; }

        public string ServicePolicy { get; set; }

        public string TransportPolicy { get; set; }

        public string Description { get; set; }

        public byte[] ServiceImage { get; set; }

        public long PostID { get; set; }

        public decimal ServicePrice { get; set; }

        public double Discount { get; set; }

        public EnumPaidBy PaidBy { get; set; }

        public IEnumerable<SelectListItem> AV_PaidBy { get; set; }

        public string ReasonPayment { get; set; }
    }
}
