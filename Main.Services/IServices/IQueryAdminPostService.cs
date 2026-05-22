using BusinessModel;

namespace IServices;

public interface IQueryAdminPostService
{
    Task<List<AdminPostDataModel>> GetAllAdminPosts ( );

    Task<AdminPostDataModel>
                 GetAdminPostForEditPostID ( int postID );
}

