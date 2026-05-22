using Main.Common.Enums;

namespace Main.Services;

public interface IUserContext
{
    string UserId
    {
        get;
    }

    string IdentityId
    {
        get;
    }

    EnumCompanyName EnumCompanyName
    {
        get;
    }

    EnumCurrency EnumCurrency
    {
        get;
    }

    EnumCountry EnumCountry
    {
        get;
    }

    EnumCategoryFor EnumCategoryFor
    {
        get;
    }

    int SeedUserId
    {
        get;
    }


    DateTime GetLocalNow ( );
}
