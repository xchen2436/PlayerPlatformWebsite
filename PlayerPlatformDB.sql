USE [PlayerPlatformDB]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 2022-06-25 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[Owner] [nvarchar](50) NOT NULL,
	[CardNumber] [nvarchar](50) NULL,
	[CardHolder] [nvarchar](50) NULL,
	[ExpiredYear] [int] NULL,
	[ExpiredMonth] [nvarchar](50) NULL,
	[CVV] [int] NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[Owner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COCAccounts]    Script Date: 2022-06-25 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COCAccounts](
	[Id] [int] IDENTITY(20000,1) NOT NULL,
	[THLevel] [nvarchar](50) NULL,
	[Gem] [int] NULL,
	[Image] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL,
	[Seller] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[AccountEmail] [nvarchar](50) NULL,
	[AccountPassword] [nvarchar](50) NULL,
	[NoteFromAdmin] [nvarchar](50) NULL,
	[PriceF] [float] NULL,
 CONSTRAINT [PK_COCAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOLAccounts]    Script Date: 2022-06-25 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOLAccounts](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[Server] [nvarchar](50) NULL,
	[Level] [int] NULL,
	[Rank] [nvarchar](50) NULL,
	[RP] [int] NULL,
	[BE] [int] NULL,
	[Champion] [int] NULL,
	[Skin] [int] NULL,
	[Description] [nvarchar](50) NULL,
	[Image] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL,
	[Seller] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[AccountUsername] [nvarchar](50) NULL,
	[AccountPassword] [nvarchar](50) NULL,
	[NoteFromAdmin] [nvarchar](50) NULL,
	[PriceF] [float] NULL,
 CONSTRAINT [PK_GameLOL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2022-06-25 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(5000,1) NOT NULL,
	[Seller] [nvarchar](50) NOT NULL,
	[Buyer] [nvarchar](50) NOT NULL,
	[Price] [nvarchar](50) NOT NULL,
	[Date] [nvarchar](50) NOT NULL,
	[ItemId] [int] NOT NULL,
	[Game] [nvarchar](50) NOT NULL,
	[RateState] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servers]    Script Date: 2022-06-25 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servers](
	[ServerId] [int] IDENTITY(5000,1) NOT NULL,
	[OrderId] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[State] [nvarchar](50) NULL,
	[Requester] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2022-06-25 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(10001,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Balance] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Goodrate] [float] NULL,
	[BadRate] [float] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cards] ([Owner], [CardNumber], [CardHolder], [ExpiredYear], [ExpiredMonth], [CVV], [Type]) VALUES (N'chen713x  ', N'4545454545454545', N'chenx', 2022, N'09', 321, N'VISA')
INSERT [dbo].[Cards] ([Owner], [CardNumber], [CardHolder], [ExpiredYear], [ExpiredMonth], [CVV], [Type]) VALUES (N'chenchen  ', N'4545454545454545', N'testcard', 2023, N'09', 156, N'VISA')
INSERT [dbo].[Cards] ([Owner], [CardNumber], [CardHolder], [ExpiredYear], [ExpiredMonth], [CVV], [Type]) VALUES (N'demo      ', N'4646464646464646', N'DEMO', 2023, N'05', 123, N'VISA')
INSERT [dbo].[Cards] ([Owner], [CardNumber], [CardHolder], [ExpiredYear], [ExpiredMonth], [CVV], [Type]) VALUES (N'TESTUSER  ', N'5454545454575757', N'TESTUSER', 2023, N'01', 456, N'MasterCard')
GO
SET IDENTITY_INSERT [dbo].[COCAccounts] ON 

INSERT [dbo].[COCAccounts] ([Id], [THLevel], [Gem], [Image], [Description], [Price], [Seller], [State], [AccountEmail], [AccountPassword], [NoteFromAdmin], [PriceF]) VALUES (20000, N'13', 154, N'../Image/UploadImage/CoC/202261764532411.png', N'almost full max account', N'153.99', N'chen713x', N'sold', N'qwee123@gmail.com', N'123123', N'Good to go', 153.99000549316406)
SET IDENTITY_INSERT [dbo].[COCAccounts] OFF
GO
SET IDENTITY_INSERT [dbo].[LOLAccounts] ON 

INSERT [dbo].[LOLAccounts] ([Id], [Server], [Level], [Rank], [RP], [BE], [Champion], [Skin], [Description], [Image], [Price], [Seller], [State], [AccountUsername], [AccountPassword], [NoteFromAdmin], [PriceF]) VALUES (10009, N'JP', 229, N'Gold I', 176, 7966, 75, 105, N'good mmr account', N'../Image/UploadImage/LoL/202261774649216.png', N'85.89', N'chen713x', N'sold', N'lbclbclbc', N'123', N'Good to go', 85.889999389648438)
INSERT [dbo].[LOLAccounts] ([Id], [Server], [Level], [Rank], [RP], [BE], [Champion], [Skin], [Description], [Image], [Price], [Seller], [State], [AccountUsername], [AccountPassword], [NoteFromAdmin], [PriceF]) VALUES (10010, N'NA', 76, N'Unrank', 0, 41358, 35, 20, N'new account, good smurf ', N'../Image/UploadImage/LoL/202261764230283.png', N'19.99', N'chen713x', N'sold', N'gggggffff', N'123123', N'Good to go', 19.989999771118164)
INSERT [dbo].[LOLAccounts] ([Id], [Server], [Level], [Rank], [RP], [BE], [Champion], [Skin], [Description], [Image], [Price], [Seller], [State], [AccountUsername], [AccountPassword], [NoteFromAdmin], [PriceF]) VALUES (10011, N'EU', 419, N'Bronze IV', 250, 3120, 140, 100, N'good mmr account', N'../Image/UploadImage/LoL/20226178743874.png', N'35.5', N'chen713x', N'unapproved', N'popopo', N'123123', N'Good to go', 35.5)
INSERT [dbo].[LOLAccounts] ([Id], [Server], [Level], [Rank], [RP], [BE], [Champion], [Skin], [Description], [Image], [Price], [Seller], [State], [AccountUsername], [AccountPassword], [NoteFromAdmin], [PriceF]) VALUES (10012, N'KR', 30, N'Master', 0, 345, 16, 0, N'master account', N'../Image/UploadImage/LoL/20226178943925.png', N'299.99', N'chenchen', N'unapproved', N'aaaaa', N'123', N'Incorrect information', 299.989990234375)
INSERT [dbo].[LOLAccounts] ([Id], [Server], [Level], [Rank], [RP], [BE], [Champion], [Skin], [Description], [Image], [Price], [Seller], [State], [AccountUsername], [AccountPassword], [NoteFromAdmin], [PriceF]) VALUES (10013, N'NA', 419, N'Diamond I', 21, 25000, 140, 343, N'all champions', N'../Image/UploadImage/LoL/202261781110184.png', N'139.5', N'chenchen', N'approved', N'trtytyrer', N'123123', N'', 139.5)
INSERT [dbo].[LOLAccounts] ([Id], [Server], [Level], [Rank], [RP], [BE], [Champion], [Skin], [Description], [Image], [Price], [Seller], [State], [AccountUsername], [AccountPassword], [NoteFromAdmin], [PriceF]) VALUES (10014, N'JP', 500, N'Unrank', 1500, 28376, 140, 1068, N'all champions and skins', N'../Image/UploadImage/LoL/20226178134162.png', N'800', N'chenchen', N'approved', N'qwe456qwe', N'aabbcc', N'', 800)
INSERT [dbo].[LOLAccounts] ([Id], [Server], [Level], [Rank], [RP], [BE], [Champion], [Skin], [Description], [Image], [Price], [Seller], [State], [AccountUsername], [AccountPassword], [NoteFromAdmin], [PriceF]) VALUES (10015, N'NA', 30, N'Unrank', 0, 25000, 16, 0, N'new account', N'../Image/UploadImage/LoL/202261781456447.png', N'5.99', N'chenchen', N'approved', N'smurf00001', N'001002003', N'', 5.9899997711181641)
SET IDENTITY_INSERT [dbo].[LOLAccounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [Seller], [Buyer], [Price], [Date], [ItemId], [Game], [RateState]) VALUES (5010, N'chen713x', N'TESTUSER', N'153.99', N'06/17/2022 7:10 AM', 20000, N'Clash of Clans', N'Good')
INSERT [dbo].[Orders] ([OrderId], [Seller], [Buyer], [Price], [Date], [ItemId], [Game], [RateState]) VALUES (5011, N'chen713x', N'TESTUSER', N'85.89', N'06/17/2022 7:18 AM', 10009, N'League of Legend', N'Good')
INSERT [dbo].[Orders] ([OrderId], [Seller], [Buyer], [Price], [Date], [ItemId], [Game], [RateState]) VALUES (5012, N'testtest', N'chen713x', N'35.99', N'06/22/2022 6:36 AM', 10017, N'League of Legend', N'Notrate')
INSERT [dbo].[Orders] ([OrderId], [Seller], [Buyer], [Price], [Date], [ItemId], [Game], [RateState]) VALUES (5013, N'demo', N'chen713x', N'19.99', N'06/22/2022 9:54 AM', 10018, N'League of Legend', N'Bad')
INSERT [dbo].[Orders] ([OrderId], [Seller], [Buyer], [Price], [Date], [ItemId], [Game], [RateState]) VALUES (6023, N'TESTUSER', N'chen713x', N'49.99', N'06/25/2022 11:28 AM', 20002, N'Clash of Clans', N'Notrated')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Servers] ON 

INSERT [dbo].[Servers] ([ServerId], [OrderId], [Title], [Description], [State], [Requester], [Date]) VALUES (5005, 20000, N'this account has porblems', N'this account missing something', N'Done', N'TESTUSER', N'06/18/2022 9:59 AM')
INSERT [dbo].[Servers] ([ServerId], [OrderId], [Title], [Description], [State], [Requester], [Date]) VALUES (5006, 10009, N'wrong item', N'the seller give me the incorrect username/password', N'Processing', N'TESTUSER', N'06/18/2022 9:59 AM')
INSERT [dbo].[Servers] ([ServerId], [OrderId], [Title], [Description], [State], [Requester], [Date]) VALUES (6005, 10017, N'this account has porblems', N'THIS ACCOUNT HAS INCORRECT INFO<br/>BALABA<br/>BALABA<br/>BALABA', N'Done', N'chen713x', N'06/22/2022 6:39 AM')
INSERT [dbo].[Servers] ([ServerId], [OrderId], [Title], [Description], [State], [Requester], [Date]) VALUES (6006, 10018, N'this account has porblems', N'hello <br/> this account has problems<br/>please help<br/>', N'Done', N'chen713x', N'06/22/2022 9:56 AM')
SET IDENTITY_INSERT [dbo].[Servers] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Username], [Password], [Balance], [Email], [Goodrate], [BadRate]) VALUES (10010, N'admin01', NULL, N'0', NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserId], [Username], [Password], [Balance], [Email], [Goodrate], [BadRate]) VALUES (10011, N'chen713x', N'202cb962ac59075b964b07152d234b70', N'3451.02', N'irisvirlandynx@gmail.com', 2, 0)
INSERT [dbo].[Users] ([UserId], [Username], [Password], [Balance], [Email], [Goodrate], [BadRate]) VALUES (10012, N'TESTUSER', N'202cb962ac59075b964b07152d234b70', N'130.11', N'136459169@qq.com', 0, 0)
INSERT [dbo].[Users] ([UserId], [Username], [Password], [Balance], [Email], [Goodrate], [BadRate]) VALUES (10013, N'chenchen', N'202cb962ac59075b964b07152d234b70', N'95.91', N'irisvirlandynx@gmail.com', 0, 0)
INSERT [dbo].[Users] ([UserId], [Username], [Password], [Balance], [Email], [Goodrate], [BadRate]) VALUES (10014, N'testtest', N'200820e3227815ed1756a6b531e7e0d2', N'357.97', N'irisvirlandynx@gmail.com', 1, 0)
INSERT [dbo].[Users] ([UserId], [Username], [Password], [Balance], [Email], [Goodrate], [BadRate]) VALUES (10015, N'demo', N'202cb962ac59075b964b07152d234b70', N'119.99', N'chen713x@gmail.com', 0, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Balance]  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Goodrate]  DEFAULT ((0)) FOR [Goodrate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_BadRate]  DEFAULT ((0)) FOR [BadRate]
GO
USE [master]
GO
ALTER DATABASE [PlayerPlatformDB] SET  READ_WRITE 
GO
