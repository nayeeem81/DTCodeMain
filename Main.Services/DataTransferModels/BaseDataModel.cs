using Main.Common.Enums;

namespace DataTransferModel;

public class BaseDataModel
{
        public BaseDataModel()
        {
        }

        public string PageName { get; set; } 

        public EnumCurrency Currency { get; set; }
       
        public EnumCompanyName HostCompanyName { get; set; }
       
        public EnumCountry HostCountry { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }
}
