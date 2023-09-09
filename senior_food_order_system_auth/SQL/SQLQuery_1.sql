CREATE TABLE [User] (

    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    PhoneNo VARCHAR(8) NOT NULL,

    UserName NVARCHAR(50) NOT NULL DEFAULT '',

    Passcode VARCHAR(255) NOT NULL DEFAULT '',

    RoleType NVARCHAR(50) NOT NULL DEFAULT '',

    DateTimeCreated DATETIMEOFFSET DEFAULT GETDATE(),

    DateTimeUpdated DATETIMEOFFSET DEFAULT GETDATE(),

    CONSTRAINT PK_User PRIMARY KEY (Id)

);

 

CREATE TABLE [dbo].[Order](

    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),  

   [OrderName] [varchar](100) NOT NULL,  

   [OrderDescription] [varchar](5000) NULL,  

    [OrderDate] DATETIMEOFFSET DEFAULT GETDATE(),  

     [UserId] UNIQUEIDENTIFIER NOT NULL,  

     [FoodName] NVARCHAR(100) NOT NULL,

     [FoodCustomization] NVARCHAR(100) NOT NULL,

     [FoodPrice] [decimal](11, 2) NOT NULL,

     [Quantity] [decimal](11, 2) NOT NULL,

    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED  

     (   [Id] ASC ) ) ON [PRIMARY];

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_User_Order] FOREIGN KEY([UserId])

REFERENCES [dbo].[User] ([Id])

GO

ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_User_Order]

GO

 

 

 CREATE TABLE [dbo].[Stall](  

     Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),  

      [StallName] [varchar](100) NOT NULL,

      [StallDescription] [varchar](5000) NULL,

      [StallOwner] [varchar](100) NOT NULL,

      DateTimeCreated DATETIMEOFFSET DEFAULT GETDATE(),

      DateTimeUpdated DATETIMEOFFSET DEFAULT GETDATE(),

       CONSTRAINT [PK_Stall] PRIMARY KEY CLUSTERED

       (   [Id] ASC

       ) ) ON [PRIMARY];
 

CREATE TABLE [Payment](

    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    [OrderID] UNIQUEIDENTIFIER NOT NULL,

    [Amount] [decimal](19, 4) NOT NULL,

    [StallID] UNIQUEIDENTIFIER NOT NULL,

    [PaymentStatus] [varchar](10) NOT NULL,

    DateTimeCreated DATETIMEOFFSET DEFAULT GETDATE(),

    DateTimeUpdated DATETIMEOFFSET DEFAULT GETDATE(),

 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED

(

    [Id] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

) ON [PRIMARY]

ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Stall] FOREIGN KEY([StallID])

REFERENCES [dbo].[Stall] ([Id])

GO

ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Stall]

GO

ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Order] FOREIGN KEY([OrderID])

REFERENCES [dbo].[Order] ([Id])

GO

ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Order]

GO

 

CREATE TABLE [dbo].[CustomerEnquiries](

    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    [EnquiriesSubject] [varchar](1000) NOT NULL,

    [EnquiriesDescription] [varchar](5000) NOT NULL,

    DateTimeCreated DATETIMEOFFSET DEFAULT GETDATE(),

    DateTimeUpdated DATETIMEOFFSET DEFAULT GETDATE(),

    [IsDeleted] [bit] NULL,

    [UserId] [uniqueidentifier] NOT NULL,

 CONSTRAINT [PK_CustomerEnquiries] PRIMARY KEY CLUSTERED

(

    [Id] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CustomerEnquiries]  WITH CHECK ADD  CONSTRAINT [FK_Customer_CustomerEnquiries] FOREIGN KEY([UserId])

REFERENCES [dbo].[User] ([Id])

GO

ALTER TABLE [dbo].[CustomerEnquiries] CHECK CONSTRAINT [FK_Customer_CustomerEnquiries]

GO

 

CREATE TABLE [dbo].[Foods](

    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    [FoodName] [varchar](100) NOT NULL,

    [FoodDescription] [varchar](5000) NULL,

    [FoodPrice] [decimal](11, 2) NOT NULL,

    DateTimeCreated DATETIMEOFFSET DEFAULT GETDATE(),

    DateTimeUpdated DATETIMEOFFSET DEFAULT GETDATE(),

    [IsDeleted] [bit] NULL,

    StallId UNIQUEIDENTIFIER NOT NULL,

 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED

(

    [Id] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Foods]  WITH CHECK ADD  CONSTRAINT [FK_Food_Stall] FOREIGN KEY([StallID])

REFERENCES [dbo].[Stall] ([Id])

GO

ALTER TABLE [dbo].[Foods] CHECK CONSTRAINT [FK_Food_Stall]

GO

 

CREATE TABLE [dbo].[FoodsCustomization](

    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

    [FoodCustomizationName] [varchar](100) NOT NULL,

    [FoodCustomizationPrice] [decimal](11, 2) NOT NULL,

    DateTimeCreated DATETIMEOFFSET DEFAULT GETDATE(),

    DateTimeUpdated DATETIMEOFFSET DEFAULT GETDATE(),

    [IsDeleted] [bit] NULL,

    [FoodId] [uniqueidentifier] NOT NULL,

 CONSTRAINT [PK_FoodsCustomization] PRIMARY KEY CLUSTERED

(

    [Id] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

) ON [PRIMARY]

GO

 

ALTER TABLE [dbo].[FoodsCustomization]  WITH CHECK ADD  CONSTRAINT [FK_Foods_FoodsCustomization] FOREIGN KEY([FoodId])

REFERENCES [dbo].[Foods] ([Id])

GO

ALTER TABLE [dbo].[FoodsCustomization] CHECK CONSTRAINT [FK_Foods_FoodsCustomization]

GO

 

