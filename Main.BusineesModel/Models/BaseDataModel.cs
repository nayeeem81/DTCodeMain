using Main.Common.Enum;
using Main.Common.Settings;

namespace BusinessModel;

public class BaseDataModel
{
        public BaseDataModel()
        {
            Currency = ( EnumCurrency? )  AppSettings.Current
                         .EnumCurrency;
        }

        public string? PageName { get; set; } = string.Empty;

        public EnumCurrency? Currency { get; set; }
       
        public EnumCompanyName? HostCompanyName { get; set; }
       
        public EnumCountry? HostCountry { get; set; }

}
