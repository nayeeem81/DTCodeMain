

using Common;

namespace FineArtsWebApp
{
    public class MarketInfoViewModel : BaseViewModel
    {
        public MarketInfoViewModel()
        {
            PageingModelAll = new PagingModel();
            ListPostsAll = new List<PostViewModel>();
            ContentInfoViewModel = new ContentInfoViewModel();
            EnumCategoryFor = StaticAppSettings.CategoryFor;
        }
        
        public EnumCategoryFor EnumCategoryFor { get; set; }

        public List<PostViewModel> ListPostsAll { get; set; }

        public List<PostViewModel> UrgentPanelPostList { get; set; }

        public long? SubCategoryID { get; set; }

        public long? CategoryID { get; set; }

        public PostViewModel PostViewModel { get; set; }

        public string DisplaySubCategory { get; set; }

        public ContentInfoViewModel ContentInfoViewModel { get; set; }
    }
}
