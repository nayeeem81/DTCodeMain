using Main.Common.Enum;
using Entity.Model;

namespace IRepository;

public interface IAdminPostImageRepository
{
    Task<List<AdminPost>> GetSelectAdminPosts(EnumCompanyName company);
}