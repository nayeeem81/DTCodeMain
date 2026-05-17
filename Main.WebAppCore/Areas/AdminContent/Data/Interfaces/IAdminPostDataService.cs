using Common;

namespace FineArtsWebApp
{
    public interface IAdminPostDataService
    {
        Task<List<AdminPostViewModel>> GetAllAdminPosts();

        Task<bool> SaveNewAdminPost(AdminPostViewModel objPostVm);

        Task<AdminPostViewModel> GetAdminPostForEditPostID(int postID);

        Task<bool> UpdateAdminPost(AdminPostViewModel objPostVm);

        Task<bool> DeleteAdminPostImage(int id, int postId);

        Task<bool> DeleteAdminPost(int postId); 
    }
}
