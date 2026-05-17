
using Common;
using System.ComponentModel.DataAnnotations;

namespace FineArtsWebApp
{
    public class BaseViewModel
    {
        public BaseViewModel() {
            PageingModelAll = new PagingModel();
            CategorySearchInfoModel = new CategorySearchInfoModel();
            Currency = StaticAppSettings.Currency;
        }

        public string PageName { get; set; }

        [Display(Name = "Currency")]
        public EnumCurrency? Currency { get; set; }

        [Display(Name = "Company Name")]
        public EnumCompanyName HostCompanyName { get; set; }

        [Display(Name = "Country Name")]
        public EnumCountry HostCountry { get; set; }

        public CategorySearchInfoModel CategorySearchInfoModel { get; set; }

        public PagingModel PageingModelAll { get; set; }

        public ModelBase ModelBase { get; set; }

        public void SetModelBase(ModelBase modelBase)
        {
            ModelBase = new ModelBase();
            ModelBase = modelBase;
        }
    }
}