using BusinessModel;

namespace FineArtsWebApp
{
    public interface IAdminPostMappingService
    {
        AdminPostDataModel MapAdminPostViewModelToAdminPostEntity ( AdminPostViewModel objAdminPostVM);

        void MapAdminPostDataModelToAdminPostViewModelListModel( AdminPostDataModel postDataModel, AdminPostViewModel postViewModel);

        List<AdminImageFileDataModel> MapAdmiFileViweModelToAdminFileEntity ( AdminPostViewModel adminFileVM);
    }
}
