using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BinanceWebSocketTask.Web.Dto
{
    public class PriceResultJsonDto
    {
        public decimal Price { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PriceQueryKind Kind { get; init; } = PriceQueryKind.Undefined;
    }
}
