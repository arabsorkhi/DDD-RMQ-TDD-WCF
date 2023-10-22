using CBSD.Seller.Core.Domain.DomainEvent.Queries;
using CBSD.Seller.Core.Domain.SellerAgg.Data;
using CBSD.Seller.Core.Domain.SellerAgg.DTO;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CBSD.Infra.Data.Sql.Seller
{
    public class DapperSellerQueryService: ISellerQueryService
    {
        private readonly SqlConnection sqlConnection;

        public DapperSellerQueryService(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public SellerDetailDTO Query(GetActiveSeller query)
        {
            string sqlQuery = "Select Top 1 a.Id as 'SellerId'," +
                              " a.Title,a.Text,p.Location as 'photoUrls', up.DisplayName as 'SellersDisplayName' " +
                              " FROM Sellers a " +
                              " Inner Join Picture p on a.Id = p.SellerId " +
                              " Inner Join UserProfiles up on a.OwnerId = up.Id" +
                              " Where State = 2 and " +
                              " a.Id = @SellerId " +
                              " Order By p.[Order]";
            return sqlConnection.QuerySingleOrDefault<SellerDetailDTO>(sqlQuery, new { query.SellerId });
        }

        public SellerSummaryDTO Query(GetActiveSellerList query)
        {
            throw new NotImplementedException();
        }

        public SellerSummaryDTO Query(GetSpecificSeller query)
        {
            throw new NotImplementedException();
        }
    }
}
 
