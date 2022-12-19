namespace System
{
    public struct DateTimeRange
    {
        public DateTime Start { get; }

        public DateTime End { get; }

        public DateTimeRange(DateTime start, DateTime end) : this()
        {
            if (end - start < TimeSpan.Zero) throw new ArgumentException("Period start cannot come after end.");

            Start = start;
            End = end;
        }
    }
}
