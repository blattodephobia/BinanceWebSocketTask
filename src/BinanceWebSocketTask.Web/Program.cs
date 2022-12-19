using BinanceWebSocketTask.Web.Adapters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var aggStreamBaseEndPoint = new Uri("wss://stream.binance.com:443");
builder.Services.AddSingleton(new PriceCollectorUseCase(new AggregateStreamWebSocketAdapter(aggStreamBaseEndPoint, "btcusdt")));
builder.Services.AddSingleton(new PriceCollectorUseCase(new AggregateStreamWebSocketAdapter(aggStreamBaseEndPoint, "adausdt")));
builder.Services.AddSingleton(new PriceCollectorUseCase(new AggregateStreamWebSocketAdapter(aggStreamBaseEndPoint, "ethusdt")));

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
