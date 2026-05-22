using Main.Common.Enums;
using Main.Services;
using System.Security.Claims;

namespace WebApp.Infrastructure;

public class UserContext: IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext ( IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

    
    //Current User
    public string UserId => User?.FindFirst ( ClaimTypes.NameIdentifier )?.Value ?? string.Empty;

    public string IdentityId => User?.FindFirst ( "IdentityId" )?.Value ?? string.Empty;



    //Configuration file
    public EnumCategoryFor EnumCategoryFor => ( EnumCategoryFor ) AppSettings.Current.EnumCategoryFor;

    public EnumCompanyName EnumCompanyName => ( EnumCompanyName ) AppSettings.Current.EnumCompanyName;

    public EnumCurrency EnumCurrency => ( EnumCurrency ) AppSettings.Current.EnumCurrency;

    public EnumCountry EnumCountry => ( EnumCountry ) AppSettings.Current.EnumCountry;

    public int SeedUserId => ( int ) AppSettings.Current.SeedUserId;

    public DateTime GetLocalNow ( )
    {
        string timeZoneId = "Bangladesh Standard Time";

        TimeZoneInfo userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

        return TimeZoneInfo.ConvertTimeFromUtc ( DateTime.UtcNow,userTimeZone );
    }
}
