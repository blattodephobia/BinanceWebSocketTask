namespace BinanceWebSocketTask.DataAccess.Dapper.Tests
{
    [TestFixture]
    public class AggregateTradeStreamDataAdapterTests
    {
        [Test]
        public void CreatesTables()
        {
            string createTablesSql = SqlResourceLoader.LoadScript("CreateTables.sql");
        }
    }
}
