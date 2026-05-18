using Entity.Model;
using BusinessModel;

namespace IRepository;

public interface IAdminPostRepository
{
    Task<AdminPostDataModel> GetAdminPostByPostID ( int postId );

    Task<List<AdminPostDataModel>> GetAllAdminContentPosts();

    Task<bool> SaveNewAdminPost ( AdminPostDataModel postObject,List<AdminImageFileDataModel> objListFiles );

    Task<bool> DeleteAdminPost ( int postId );

    Task<bool> DeleteAdminPostImage ( int id,int postId );

    Task<bool> SaveChanges ( );

    Task<bool> UpdateAdminPost (
        AdminPostDataModel objPostDm );
}

