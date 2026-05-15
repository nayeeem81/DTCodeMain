using Main.Common;
using Main.Model;
namespace IRepository;

public interface IAdminPostImageRepository
{
    Task<List<AdminPost>> GetSelectAdminPosts(EnumCompanyName company);
}