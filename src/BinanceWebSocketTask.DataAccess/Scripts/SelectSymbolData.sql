SELECT AVG([Price]) FROM [bwst].[dbo].[AggregateTradeStreamData]
WHERE [Symbol] = @symbol
  AND (@startDate <= [EventTime] AND [EventTime] <= @endDate)