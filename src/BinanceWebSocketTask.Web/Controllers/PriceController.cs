using BinanceWebSocketTask.Web.Dto;

namespace BinanceWebSocketTask.Web.Controllers
{
    [Route("api/")]
    public class PriceController : ControllerBase
    {
        private readonly PriceCollectorUseCase _priceCollectorUseCase;

        public PriceController(PriceCollectorUseCase priceCollectorUseCase)
        {
            _priceCollectorUseCase = priceCollectorUseCase;
        }

        [Route("{symbol}/24hAvgPrice")]
        [HttpGet]
        public async Task<ActionResult> GetDayAverage([FromRoute] string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                return BadRequest(symbol);
            }

            return Ok(new PriceResultJsonDto()
            {
                Price = await _priceCollectorUseCase.GetDayAverageForSymbol(symbol),
                Kind = PriceQueryKind.Average24h
            });
        }
    }
}
