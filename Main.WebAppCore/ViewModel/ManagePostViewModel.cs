


using Common;

namespace FineArtsWebApp
{
    public class ManagePostViewModel : BaseViewModel
    {
        public ManagePostViewModel()
        {
            ListPostViewModel = new List<PostViewModel>();
            ListProductViewModel = new List<PostViewModel>();
        }

        public List<PostViewModel> ListPostViewModel { get; set; }

        public List<PostViewModel> ListProductViewModel { get; set; }
    }
}
