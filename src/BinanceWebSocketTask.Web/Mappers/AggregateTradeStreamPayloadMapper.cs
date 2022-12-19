using BinanceWebSocketTask.Web.Dto;
using Websocket.Client;

namespace BinanceWebSocketTask.Web.Mappers
{
    public static class AggregateTradeStreamPayloadMapper
    {
        public static AggregateTradeStreamPayload? Map(this AggregateTradeStreamPayloadJsonDto webSocketMessage)
        {
            try
            {
                return new AggregateTradeStreamPayload
                {
                    AggregateTradeId = webSocketMessage.AggregateTradeId,
                    EventTime = DateTimeUtilities.FromBinanceTimeStamp(webSocketMessage.EventTime),
                    FirstTradeId = webSocketMessage.FirstTradeId,
                    Ignore = webSocketMessage.Ignore,
                    IsBuyerMarketMaker = webSocketMessage.IsBuyerMarketMaker,
                    LastTradeId = webSocketMessage.LastTradeId,
                    Price = decimal.Parse(webSocketMessage.Price),
                    Quantity = double.Parse(webSocketMessage.Quantity),
                    Symbol = webSocketMessage.Symbol,
                    TradeTime = DateTimeUtilities.FromBinanceTimeStamp(webSocketMessage.TradeTime)
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
