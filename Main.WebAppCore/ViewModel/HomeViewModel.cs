
namespace FineArtsWebApp
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            ContentInfoViewModel = new ContentInfoViewModel();
            FabiaInformationViewModel = new FabiaInformationViewModel();
            MenuObjectModel = new MenuObjectModel(Common.EnumCategoryFor.FineArts);
            CategorySearchInfoModel = new CategorySearchInfoModel();
        }

        public string PageName { get; set; }

        public ContentInfoViewModel ContentInfoViewModel { get; set; }

        public FabiaInformationViewModel FabiaInformationViewModel { get; set; }

        public MenuObjectModel MenuObjectModel { get; set; }

        public CategorySearchInfoModel CategorySearchInfoModel { get; set; }
    }
}
