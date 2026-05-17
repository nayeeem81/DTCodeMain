using Common;

namespace FineArtsWebApp
{
    public class PortfolioInfoViewModel : BaseViewModel
    {
        public PortfolioInfoViewModel()
        {
            PageingModelAll = new PagingModel();
            ListUserAll = new List<UserViewModel>();
        }
      

        public List<UserViewModel> ListUserAll { get; set; }

        public PostViewModel PostViewModel { get; set; }
    }
}
