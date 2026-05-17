using Common;
using Data;
using Model;

namespace FineArtsWebApp
{
    public interface ILoggingService
    {
        Task<List<LogServerError>> GetAllServerErrorLog();

        Task<bool> AddServerErrorLog(Exception exception);

        Task<bool> LogPostDetailPageVisit(EnumLogType fabiaLog, long postID, EnumCountry country, string sessionID);

        Task<bool> LogPostDetailPageVisit(long postID, EnumCountry country, string sessionID);

        Task<bool> LogEntirePageVisit(EnumLogType logType, EnumCountry country, string sessionID);

        Task<bool> LogSearchMarketPageVisit(string searchKey, EnumCountry country, string sessionID);

        Task<bool> LogSubCategoryMarketPageVisit(long subCatID, EnumCountry country, string sessionID);

        Task<bool> LogCategoryMarketPageVisit(long catID, EnumCountry country, string sessionID);

        Task<bool> LogSpecialMarketPageVisit(long catID, EnumCountry country, string sessionID);

        Task<Int32> LogUserSession(LogUserSession objUserSession);

        Task<Int32> LogBrowserInfo(LogBrowserInfo objBrowserLog);

        Task<bool> LogAdvancedSearch(PostViewModel objSearch, string sessionID);

        Task<bool> LogSimpleSearch(string searchKey, string sessionID);

        List<TempTuple> GetVisitedTopSubCategories(int howManyTake);
    }
}
