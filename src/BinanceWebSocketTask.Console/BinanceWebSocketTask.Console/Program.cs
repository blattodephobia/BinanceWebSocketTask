// See https://aka.ms/new-console-template for more information

using Websocket.Client;
using WebSocketSharp;

//private static void OnMessage(object sender, MessageEventArgs eventArgs)
//{

//}

//var ws = new WebSocket("wss://stream.binance.com:9443");
//ws.OnMessage += OnMessage;
var exitEvent = new ManualResetEvent(false);

using var client = new WebsocketClient(new Uri("wss://stream.binance.com:443/stream?streams=btcusdt@aggTrade"))
{
    ReconnectTimeout = TimeSpan.FromSeconds(30)
};

client.ReconnectionHappened.Subscribe(info =>
{
    Console.WriteLine("Reconnection happened, type: " + info.Type);
});

client.MessageReceived.Subscribe(msg =>
{
    Console.WriteLine($"Message received: {msg}\n===========");
    Console.WriteLine(msg.Text);
    Console.WriteLine("===========");
});

client.Start();
client.Send(@"
{
  ""method:"": ""SUBSCRIBE"",
  ""params"": [
    ""btcusdt@aggTrade"",
    ""btcusdt@depth""
  ],
  ""id"": 1
}
");
exitEvent.WaitOne();