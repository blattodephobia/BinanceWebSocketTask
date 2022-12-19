using BinanceWebSocketTask.Web.Dto;
using BinanceWebSocketTask.Web.Mappers;
using Newtonsoft.Json;
using Websocket.Client;

namespace BinanceWebSocketTask.Web
{
    public class WebSocketAdapter : IWebSocketAdapter
    {
        private readonly WebsocketClient _client;

        public WebSocketAdapter(Uri streamEndpoint)
        {
            _client = new WebsocketClient(streamEndpoint);
            _client.MessageReceived.Subscribe(OnMessageReceived);
        }

        public event Action<AggregateTradeStreamPayload>? OnPayloadReceived;

        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task Start()
        {
            await _client.Start();
            _client.Send(@"
{
  ""method:"": ""SUBSCRIBE"",
  ""params"": [
    ""btcusdt@aggTrade"",
    ""btcusdt@depth""
  ],
  ""id"": 1
}
");
        }

        public async Task Stop()
        {
            await _client.Stop(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, string.Empty);
        }

        private void OnMessageReceived(ResponseMessage msg)
        {
            AggregateTradeStreamPayload payload = msg.Text != null
                ? JsonConvert.DeserializeObject<WebSocketResponseJsonDto<AggregateTradeStreamPayloadJsonDto>>(msg.Text)?.Data?.Map() ?? AggregateTradeStreamPayload.Null
                : AggregateTradeStreamPayload.Null;

            if (payload != AggregateTradeStreamPayload.Null) OnPayloadReceived?.Invoke(payload);
        }
    }
}
