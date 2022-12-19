using Dapper;
using System.Data.SqlClient;

namespace BinanceWebSocketTask.DataAccess.Dapper
{
    public class AggregateTradeStreamDataAdapter : IAggregateTradeStreamDataAdapter
    {
        static AggregateTradeStreamDataAdapter()
        {
            InsertAggregateTradeStreamPayloadSql = SqlResourceLoader.LoadScript("InsertAggregateTradeStreamPayload.sql");
            SelectAggregateTradeStreamSymbolDataSql = SqlResourceLoader.LoadScript("SelectSymbolData.sql");
        }

        private static readonly string InsertAggregateTradeStreamPayloadSql;
        private static readonly string SelectAggregateTradeStreamSymbolDataSql;

        private readonly string _connectionString;


        public AggregateTradeStreamDataAdapter(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            
            _connectionString = connectionString;
        }

        public void Save(AggregateTradeStreamPayload payload)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(InsertAggregateTradeStreamPayloadSql, param: new
            {
                symbol = payload.Symbol.ToUpper(),
                eventTime = payload.EventTime,
                tradeTime = payload.TradeTime,
                price = payload.Price,
                quantity = payload.Quantity
            });
        }

        public async Task<decimal> GetAverageFor(string symbol, DateTimeRange period)
        {
            using var connection = new SqlConnection(_connectionString);
            decimal result = await connection.ExecuteScalarAsync<decimal>(SelectAggregateTradeStreamSymbolDataSql, param: new
            {
                symbol = symbol.ToUpper(),
                startDate = period.Start,
                endDate = period.End
            });

            return result;
        }
    }
}
