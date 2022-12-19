USE [bwst]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AggregateTradeStreamData](
	[Id] [bigint] IDENTITY(1, 1), CONSTRAINT PK_AggTradeStream_Id PRIMARY KEY (Id),
	[Symbol] [char](7) NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[TradeTime] [datetime] NOT NULL,
	[Price] [money] NOT NULL,
	[Quantity] [float] NOT NULL
) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_AggTradeStream_Symbol] ON [dbo].[AggregateTradeStreamData]
(
	[Symbol] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO