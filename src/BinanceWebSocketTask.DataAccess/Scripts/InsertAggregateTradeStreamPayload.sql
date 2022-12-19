INSERT INTO [bwst].[dbo].[AggregateTradeStreamData] ([Symbol], [EventTime], [TradeTime], [Price], [Quantity])
VALUES (@symbol, @eventTime, @tradeTime, @price, @quantity)