


using Common;

namespace FineArtsWebApp
{
    public class CategoryButtonformationViewModel : BaseViewModel
    {
        public CategoryButtonformationViewModel()
        {
            ListTopCategories = new List<CategoryButtonViewModel>();
        }
   
        public List<CategoryButtonViewModel> ListTopCategories { get; set; }
    }
}
