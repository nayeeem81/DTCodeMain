using Main.Model;
namespace IRepository;

public interface IAdminPostRepository
{
    Task<bool> SaveChanges();

    Task<List<AdminPost>> GetAllAdminContentPosts();

    Task<bool> DeleteAdminPost(int postId);

    Task<bool> DeleteAdminPostImage(int id, int postId);

    Task<AdminPost> GetAdminPostByPostID(int postId);

    Task<bool> SaveNewAdminPost(AdminPost postObject, List<AdminImageFile> objListFiles);
}

