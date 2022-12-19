namespace System
{
    public static class DateTimeUtilities
    {
        public static DateTime FromBinanceTimeStamp(long timeStamp)
        {
            var epochStart = new DateTime(1970, 1, 1);

            return epochStart.AddMilliseconds(timeStamp);
        }
    }
}
