using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Data;

namespace FineArtsWebApp
{
    public class BrowserSessionReportQueryService : IBrowserSessionReportQueryService
    {
        private readonly WebBusinessEntityContext _dbContext;
        List<BrowserUserSessionQueryModel> listDataQueryModel;

        public BrowserSessionReportQueryService(WebBusinessEntityContext context)
        {
            _dbContext = context;
        }

        public List<BrowserUserSessionQueryModel> GetAllData()
        {
            listDataQueryModel = _dbContext.Database.SqlQueryRaw<BrowserUserSessionQueryModel>("GetBrowserUserSessionLog @BrowserLogID", new SqlParameter("@BrowserLogID", 500) { DbType = DbType.Int32, IsNullable = false }).ToList();
            return listDataQueryModel;
        }
    }
}
