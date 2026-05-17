
using Main.Common.Enums;
using Main.Common.Model;
using Main.Common.Settings;

namespace FineArtsWebApp
{
    public class BaseModel
    {
            public BaseModel()
            {
                Currency =  ( EnumCurrency? ) AppSettings.Current.EnumCurrency;
            }

            public string? PageName { get; set; } = string.Empty;
  
            public EnumCurrency? Currency { get; set; }
           
            public EnumCompanyName? HostCompanyName { get; set; }
           
            public EnumCountry? HostCountry { get; set; }

            public ModelBase ModelBase { get; set; }

            public void SetModelBase(ModelBase modelBase)
            {
                ModelBase = new ModelBase();
                ModelBase = modelBase;
            }    
    }
}
