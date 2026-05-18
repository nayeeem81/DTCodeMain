using IService;
using IRepository;
using BusinessModel;
using Main.Common.Enums;

namespace Main.Service;

public class AdminPostDataService: IAdminPostDataService
{
    private readonly IAdminPostRepository _AdminPostRepository;

    public AdminPostDataService ( IAdminPostRepository adminPostRepository )
    {
        _AdminPostRepository = adminPostRepository;
    }

    public async Task<List<AdminPostDataModel>> GetAllAdminPosts ( )
    {
        var listPosts = await _AdminPostRepository.GetAllAdminContentPosts();

        return listPosts;
    }

    public async Task<bool> SaveNewAdminPost ( AdminPostDataModel objAdminPostDm )
    {
        var result = await _AdminPostRepository.SaveNewAdminPost(objAdminPostDm, objAdminPostDm.ListAdminPostFileImages);

        return result;
    }

    public async Task<AdminPostDataModel> GetAdminPostForEditPostID ( int postID )
    {
        var postDataModel = await _AdminPostRepository.GetAdminPostByPostID(postID);
        
        return postDataModel;
    }

    public async Task<bool> UpdateAdminPost ( AdminPostDataModel objPostDm )
    {
        var postDataModel = await _AdminPostRepository.GetAdminPostByPostID(objPostDm.AdminPostID);

        if ( postDataModel != null )
        {
            postDataModel.SetModelBase ( objPostDm.ModelBase );
            postDataModel.UserID = objPostDm.UserID;
        }

        List<AdminImageFileDataModel> images = new List<AdminImageFileDataModel>();

        images.AddRange ( postDataModel.ListAdminPostFileImages );

        objPostDm.ListAdminPostFileImages.ForEach ( fileVM =>
        {
            var objFile = new AdminImageFileDataModel(fileVM.ImageFileContent);
            objFile.AdminPostID = postDataModel.AdminPostID;
            images.Add ( objFile );
        } );


        List<AdminPostCommentDataModel> comments = new List<AdminPostCommentDataModel>();

        comments.AddRange ( postDataModel.ListAdminPostComments );

        objPostDm.ListAdminPostComments.ForEach ( commentVM =>
        {
            var objComment = new AdminPostCommentDataModel();
            objComment.AdminPostID = postDataModel.AdminPostID;
            objComment.Comment = commentVM.Comment;
            comments.Add ( objComment );
        } );

        postDataModel.PosterName = objPostDm.PosterName;
        postDataModel.Title = objPostDm.PostTitle;
        postDataModel.PosterContactNumber = objPostDm.PosterContactNumber;
        postDataModel.WebsiteUrl = objPostDm.WebsiteUrl;
        postDataModel.ShortNote = objPostDm.ShortNote;
        postDataModel.SearchTag = objPostDm.SearchTag;
        postDataModel.PostType = ( EnumPostType ) objPostDm.PostTypeID;
        postDataModel.ListAdminPostComments = comments;
        postDataModel.ListAdminImageFiles = images;
        postDataModel.AdminPostID = objPostDm.AdminPostID;


        var result = await _AdminPostRepository.SaveChanges();

        return true;
    }

    public async Task<bool> DeleteAdminPostImage ( int id,int postId )
    {
        return await _AdminPostRepository.DeleteAdminPostImage ( id,postId );
    }

    public async Task<bool> DeleteAdminPost ( int postId )
    {
        var resultDelete = await _AdminPostRepository.DeleteAdminPost(postId);
        return resultDelete;
    }
}