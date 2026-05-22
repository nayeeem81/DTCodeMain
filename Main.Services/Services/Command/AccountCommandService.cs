using Domain.Model;
using IRepository;
using Main.Common.HelperRelated;

namespace Main.Services;

public class AccountCommandService : IAccountCommandService
{
    private readonly IUserContext _userContext;
    private readonly IUserRepository _userRepository;

    public AccountCommandService ( IUserContext userContext, IUserRepository userRepository )
    {
        _userContext = userContext;
        _userRepository = userRepository;
    }

    public async Task<bool> CreateUserAccount (
        string idetytyId, UserAccountDataModel userAccountDM )
    {
        User objUser = new User();

        objUser.IdentityUserID = idetytyId;
        objUser.Email = userAccountDM.Email;
        objUser.ClientName = StringRelated.GetUserNameFromEmail ( userAccountDM.Email );

        objUser.CreatedDate = _userContext.GetLocalNow ( );
        objUser.ModifiedDate = _userContext.GetLocalNow ( );
        objUser.CreatedBy = (int) _userContext.SeedUserId;
        objUser.ModifiedBy = ( int ) _userContext.SeedUserId;

        objUser.HostCompanyName = _userContext.EnumCompanyName;
        objUser.HostCountry = _userContext.EnumCountry;

        return await _userRepository.AddUser ( objUser );
    }
}
