using BinanceWebSocketTask;
using BinanceWebSocketTask.DataAccess;
using BinanceWebSocketTask.DataAccess.Dapper;
using BinanceWebSocketTask.Web.Adapters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json");
var connectionStrings = new ConnectionStrings();
builder.Services.AddSingleton(connectionStrings);
builder.Configuration.GetSection("connectionStrings").Bind(connectionStrings);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var dataAdapter = new AggregateTradeStreamDataAdapter(connectionStrings.Default) as IAggregateTradeStreamDataAdapter;
builder.Services.AddSingleton(dataAdapter);
var aggStreamBaseEndPoint = new Uri("wss://stream.binance.com:443");
builder.Services.AddSingleton(new PriceCollectorUseCase(new AggregateStreamWebSocketAdapter(aggStreamBaseEndPoint, "btcusdt"), dataAdapter));
builder.Services.AddSingleton(new PriceCollectorUseCase(new AggregateStreamWebSocketAdapter(aggStreamBaseEndPoint, "adausdt"), dataAdapter));
builder.Services.AddSingleton(new PriceCollectorUseCase(new AggregateStreamWebSocketAdapter(aggStreamBaseEndPoint, "ethusdt"), dataAdapter));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
