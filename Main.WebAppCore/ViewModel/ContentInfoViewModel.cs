
using FineArtsWebApp;

namespace FineArtsWebApp
{
    public class ContentInfoViewModel
    {
        public ContentInfoViewModel()
        {
            ListGroupPanelConfiguration = new List<PostTemplateViewModel>();
        }

        public List<PostTemplateViewModel> ListGroupPanelConfiguration { get; set; }

        public long? CategoryID { get; set; }
    }
}
