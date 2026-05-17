using Common;

namespace FineArtsWebApp
{
    public interface IPostVisitService
    {
        Task<bool> SavePostVisit(long postID, string email, string phone, EnumPostVisitAction visitAction);

        Task<List<LogPostVisitViewModel>> GetUserAllPostVisits(long userID, EnumPostVisitAction visitAction);
    }
}
