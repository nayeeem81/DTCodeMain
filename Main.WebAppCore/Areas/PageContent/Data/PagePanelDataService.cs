using Common;
using Data;
using Model;

namespace FineArtsWebApp
{
    public class PagePanelDataService: IPagePanelDataService
    {

        public readonly IProductImageRepository _productImageRepository;
        public readonly IAdminPostImageRepository _adminPostsImageRepository;
        public readonly IPageRepository _pageRepository;

        public PagePanelDataService ( IProductImageRepository productImageRepository,
                                    IAdminPostImageRepository adminPostsImageRepository,
                                    IPageRepository pageRepository )
        {
            _productImageRepository = productImageRepository;
            _adminPostsImageRepository = adminPostsImageRepository;
            _pageRepository = pageRepository;
        }

        public async Task<List<PanelPostViewModel>> GetSelectProducts ( EnumCompanyName company )
        {

            var list = await _productImageRepository.GetSelectProducts(company);


            if ( list == null )
            {
                return new List<PanelPostViewModel> ( );
            }


            List<PanelPostViewModel> listSelectPanelPostVM = new List<PanelPostViewModel>();


            PanelPostViewModel objVM;

            int id = 1;

            list.ForEach ( entity => {

                entity.ListImageFiles.ToList ( ).ForEach ( file =>
                {
                    

                    objVM = new PanelPostViewModel ( );


                    objVM.CategoryID = entity.CategoryID;
                    objVM.PanelPostID = id;
                    objVM.RootID = entity.ProductID;
                    objVM.EnumPostType = entity.PostType;
                    objVM.Price = entity.Price;
                    objVM.PostTitle = entity.ProductName;
                    objVM.ImageFileContent = file.ImageFileContent;
                    objVM.ImageFileID = file.ProductImageFileID;

                    id += 1;
                    listSelectPanelPostVM.Add ( objVM );
                } );

            } );

            return listSelectPanelPostVM.OrderBy ( a => a.CategoryID ).ToList ( );

        }

        public async Task<int> CreateNewPanels (

            LocalModel model,

            EnumCompanyName enumCompany,

            List<PanelPostViewModel> listUserSelectedPosts,

            ModelBase modelBase

            )
        {

            PagePanel panelEntity = new PagePanel();

            panelEntity.PanelTemplate = ( EnumPanelTemplate ) model.TemplateTypeID;

            panelEntity.PanelTitle = model.PanelTitle;

            panelEntity.CreateBaseData ( modelBase );


            listUserSelectedPosts.ForEach ( obj => {

                PanelPost panelPost = new PanelPost ( obj.EnumPostType, obj.RootID, obj.PageID )
                {

                    ImageFileContent = obj.ImageFileContent,

                    Price = obj.Price,

                    PostTitle = obj.PostTitle,

                    PostDescription = obj.PostDescription

                };


                panelPost.CreateBaseData ( modelBase );  

                panelEntity.CreatePanelPost ( panelPost );

            } );


            Model.Page objPageEntity =  await _pageRepository.GetSinglePage ( model.PageID );

            
            PageContent objPageCotentEntity = objPageEntity.GetNewOrExistingPageContent( objPageEntity.PageID, modelBase);
    
            
            objPageCotentEntity.Page = null;

            
            objPageCotentEntity.CreatePagePanel ( panelEntity );


            objPageEntity.SavePageContent ( objPageCotentEntity );


            bool result = await _pageRepository.CreateNewContent( objPageEntity );


            int newPanelID = objPageEntity.ListPageContents
                                              .Last<PageContent>()
                                              .ListPagePanels
                                              .Last<PagePanel>().PanelID;


            return newPanelID;

        } 

        public async Task<List<PanelPostViewModel>> GetSelectAdminPosts ( EnumCompanyName company )
        {

            var list = await _adminPostsImageRepository.GetSelectAdminPosts(company);


            if ( list == null )
            {
                return new List<PanelPostViewModel> ( );
            }


            List<PanelPostViewModel> listSelectPanelPostVM = new List<PanelPostViewModel>();


            PanelPostViewModel objVM;


            list.ForEach ( entity => {

                entity.ListAdminImageFiles.ToList ( ).ForEach ( file =>
                {
                    objVM = new PanelPostViewModel ( );

                    objVM.RootID = entity.AdminPostID;
                    objVM.EnumPostType = entity.PostType;
                    objVM.PostTitle = entity.Title;
                    objVM.ImageFileContent = file.ImageFileContent;

                    listSelectPanelPostVM.Add ( objVM );
                } );

            } );

            return listSelectPanelPostVM.OrderBy ( a => a.PostTitle ).ToList ( );

        }

        public async Task<PagePanelViewModel> GetPreviewPanel ( int panelId )
        {
            PagePanel panelEntity = await _pageRepository.GetContentPanel(panelId);
            
            if ( panelEntity != null )
            {
                PagePanelViewModel panelVM = new PagePanelViewModel ( );
                panelVM.PanelID = panelEntity.PanelID;
                panelVM.PanelTemplate = panelEntity.PanelTemplate;

                PanelPostViewModel postVM;

                panelEntity.ListPanelPosts.ToList ( ).ForEach ( post =>
                {
                    postVM = new PanelPostViewModel ( );
                    postVM.PanelPostID = post.PanelPostID;
                    postVM.PostTitle = (string)post.PostTitle;  
                    postVM.Price = post.Price;
                    postVM.PostDescription = (string)post.PostDescription;
                    postVM.ImageFileContent = post.ImageFileContent;
                    postVM.ImageOrderID = postVM.ImageOrderID;

                    panelVM.CreatePanelPost ( postVM );

                } );

                return panelVM;

            }

            return new PagePanelViewModel ( );
        }

        public async Task<List<PagePanelViewModel>> GetPanelList ( int pageID )
        {

            Model.Page paeEntity = await _pageRepository.GetSinglePage(pageID);


            if ( paeEntity != null )
            {
                var pageContent = paeEntity.ListPageContents.First<PageContent>();

                var listPanels = pageContent.ListPagePanels.ToList();

                List<PagePanelViewModel> panelListVM = new List<PagePanelViewModel>();

                PagePanelViewModel panelVM;

                PanelPostViewModel postVM;


                listPanels.ForEach ( panel => 
                { 

                    panelVM = new PagePanelViewModel ( );


                    panelVM.PanelID = panel.PanelID;

                    panelVM.PanelTemplate = panel.PanelTemplate;
                
                    panelVM.PanelTitle = panel.PanelTitle;

                    
                    panel.ListPanelPosts.ToList ( ).ForEach ( post =>
                    {

                        postVM = new PanelPostViewModel ( );

                        postVM.PanelPostID = post.PanelPostID;

                        postVM.PostTitle = ( string ) post.PostTitle;

                        postVM.Price = post.Price;

                        postVM.PostDescription = ( string ) post.PostDescription;

                        postVM.ImageFileContent = post.ImageFileContent;

                        postVM.ImageOrderID = post.PostOrder;

                        panelVM.CreatePanelPost ( postVM );

                    } );

                    panelListVM.Add ( panelVM );

                } );

               return panelListVM;
            }

            return new List<PagePanelViewModel> ( );
        }

    }
}
