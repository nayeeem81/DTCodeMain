using Model;

namespace FineArtsWebApp
{
    public interface IGroupPanelPostMappingService
    {
        PostViewModel LoadAValues(PostViewModel postViewModel);

        void MapGroupPanelPostEntityToPostViewModelForEdit(GroupPanelPost groupPanelPost, PostViewModel postVm);

        void MapGroupPanelPostEntityToPostViewModelReadonly(GroupPanelPost groupPanelPost, PostViewModel postVM);
    }
}
