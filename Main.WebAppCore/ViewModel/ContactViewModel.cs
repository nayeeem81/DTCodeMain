

using Microsoft.AspNetCore.Mvc.Rendering;


namespace FineArtsWebApp
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            AV_MessageTypeList = DropDownSelectListItem.GetAllContactMessageType();
        }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string MessageCategory { get; set; }

        public List<SelectListItem> AV_MessageTypeList { get; set; }

        public string PageName { get; set; }
    }
}
