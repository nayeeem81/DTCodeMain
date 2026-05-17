using BusinessModel;
using Data;
using Entity.Model;
using IRepository;
using Main.Common.Enums;
using Microsoft.EntityFrameworkCore;               

namespace Repository;

public class AdminPostRepository : IAdminPostRepository
{
    private readonly BussinessAppDbContext _Context;

    public AdminPostRepository( BussinessAppDbContext context )
    {
        _Context = context;
    }

    public async Task<bool> SaveChanges()
    {
        var result = await _Context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<List<AdminPostDataModel>> GetAllAdminContentPosts()
    {
        List<AdminPostDataModel> listPostDataModel  = new List<BusinessModel.AdminPostDataModel>();

        var listPostEntity = await _Context.AdminPosts.ToListAsync();

        AdminPostDataModel objDataModel;

        listPostEntity.ForEach ( postEntity =>
        {
            objDataModel = new BusinessModel.AdminPostDataModel();

            objDataModel.AdminPostID = postEntity.AdminPostID;
            objDataModel.PosterName = postEntity.PosterName;
            objDataModel.HostCompanyName = postEntity.HostCompanyName;

            objDataModel.PostTitle = postEntity.Title;
            objDataModel.PostTypeID =  (int) postEntity.PostType;

            listPostDataModel.Add( objDataModel );

        } );

        return listPostDataModel;
    }

    public async Task<bool> DeleteAdminPost(int postId)
    {
        var post = _Context.AdminPosts.ToList().Single(a => a.AdminPostID == postId);

        if (post != null)
        {
            _Context.AdminPosts.Remove(post);
        }
                
        var result = await _Context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAdminPostImage(int id, int postId)
    {
        var image = await _Context.AdminImageFiles.Where(a => a.AdminImageFileID == id && a.AdminPostID == postId).FirstOrDefaultAsync();

        if (image != null)
        {
            _Context.AdminImageFiles.Remove(image);
        }

        var result = await _Context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Entity.Model.AdminPost> GetAdminPostByPostID(int postId)
    {
        var post = await _Context.AdminPosts.SingleAsync(a => a.AdminPostID == postId);
        return post;
    }

    public async Task<bool> SaveNewAdminPost(AdminPostDataModel postObject, List<AdminImageFileDataModel> objListFiles)
    {
        AdminPost adminPostEntity = MapEntityModelFull(postObject, objListFiles);

        _Context.AdminPosts.Add(adminPostEntity);

        int result = await _Context.SaveChangesAsync();

        return result > 0;
    }    


    public AdminPost MapEntityModelFull
    ( 
        AdminPostDataModel from,
        List<AdminImageFileDataModel> fromListImages                 
    )
    {
        AdminPost objAdminPostEntity = MapAdminPostDataModelToAdminPostEntity ( from );

        objAdminPostEntity.CreateBaseData ( from.ModelBase );
        objAdminPostEntity.UserID = from.UserID;
        objAdminPostEntity.User = null;

        List<AdminImageFile> objListFileEntity = MapAdmiFileDataModelToAdminFileEntity(from);

        objAdminPostEntity.ListAdminImageFiles = objListFileEntity;
        objAdminPostEntity.ListAdminPostComments = new List<AdminPostComment> ( );

        return objAdminPostEntity;
    }

    private AdminPost MapAdminPostDataModelToAdminPostEntity ( AdminPostDataModel objAdminPostDM )
    {
        return new AdminPost ( )
        {
            PosterName = objAdminPostDM.PosterName,
            Title = objAdminPostDM.PostTitle,
            PostType = ( EnumPostType ) objAdminPostDM.PostTypeID,
            WebsiteUrl = objAdminPostDM.WebsiteUrl,
            SearchTag = objAdminPostDM.SearchTag,
            ShortNote = objAdminPostDM.ShortNote,
            ListAdminImageFiles = new List<AdminImageFile> ( ),
            ListAdminPostComments = new List<AdminPostComment> ( ),
            PosterContactNumber = objAdminPostDM.PosterContactNumber
        };
    }

    private List<AdminImageFile> MapAdmiFileDataModelToAdminFileEntity ( AdminPostDataModel adminFileDM )
    {
        List<AdminImageFile> objListFileEntity = new List<AdminImageFile>();
        adminFileDM.ListAdminPostFileImages.ForEach ( fileVM =>
        {
            objListFileEntity.Add ( new AdminImageFile ( fileVM.ImageFileContent ) );
        } );
        return objListFileEntity;
    }
}

