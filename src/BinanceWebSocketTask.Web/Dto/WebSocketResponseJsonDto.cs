namespace BinanceWebSocketTask.Web.Dto
{
    public class WebSocketResponseJsonDto<T>
    {
        public string Stream { get; set; } = string.Empty;

        public T Data { get; set; }
    }
}
