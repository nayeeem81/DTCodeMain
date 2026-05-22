namespace Main.Services;

public interface IAccountCommandService
{
    Task<bool> CreateUserAccount ( 
        string idetytyId, UserAccountDataModel userAccountDM );
    Task<int> GetSingleUser ( string id );
}
