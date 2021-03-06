USE [DevTest]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AppointmentDiary]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentDiary](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[CompanyId] [bigint] NOT NULL,
	[BranchId] [bigint] NOT NULL,
	[CustomerId] [nvarchar](128) NOT NULL,
	[PackageId] [nvarchar](128) NOT NULL,
	[DateTimeScheduled] [datetime] NOT NULL,
	[AppointmentLength] [int] NOT NULL,
	[Notes] [nvarchar](128) NULL,
	[StatusENUM] [int] NOT NULL,
 CONSTRAINT [PK_ConsultantBookings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[RoleDesc] [nvarchar](max) NULL,
	[IsPublic] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[BaseBranchID] [bigint] NOT NULL,
	[AddnlBranchIDs] [nvarchar](max) NULL,
	[EmployeeID] [bigint] NOT NULL,
	[CreatedDt] [datetime] NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Branch]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[BranchRegion] [nvarchar](32) NOT NULL,
	[BranchCode] [nvarchar](50) NOT NULL,
	[BranchName] [nvarchar](128) NOT NULL,
	[BranchHotelName] [nvarchar](50) NULL,
	[BranchSpaName] [nvarchar](50) NULL,
	[BranchAddress] [nvarchar](max) NULL,
	[BranchCity] [nvarchar](50) NULL,
	[BranchState] [nvarchar](50) NULL,
	[BranchCountry] [nvarchar](50) NULL,
	[BranchContactNo] [nvarchar](50) NULL,
	[BranchComment] [nvarchar](max) NULL,
	[BranchIsActive] [char](1) NOT NULL,
	[BranchCreatedBy] [nvarchar](50) NULL,
	[BranchCreatedDt] [datetime] NOT NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC,
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BranchTreatmentCost]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchTreatmentCost](
	[BranchTreatmentCostID] [bigint] IDENTITY(1,1) NOT NULL,
	[BranchID] [bigint] NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[PackageTreatmentXrefID] [bigint] NOT NULL,
	[TreatmentCost] [decimal](8, 2) NOT NULL,
	[Comments] [nvarchar](50) NULL,
 CONSTRAINT [PK_BranchTreatmentCost] PRIMARY KEY CLUSTERED 
(
	[BranchTreatmentCostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](128) NOT NULL,
	[CompanyEmail] [nvarchar](128) NOT NULL,
	[CompanyWebSite] [nvarchar](128) NULL,
	[CompanyDetails] [nvarchar](max) NULL,
	[CompanyDesc] [nvarchar](max) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[CustomerTypeID] [int] NOT NULL,
	[CustomerFname] [nvarchar](50) NULL,
	[CustomerLname] [nvarchar](50) NULL,
	[CustomerGender] [char](1) NOT NULL,
	[CustomerMobileNo] [nvarchar](15) NOT NULL,
	[CustomerDOB] [datetime] NULL,
	[CustomerEmailID] [nvarchar](50) NULL,
	[CustomerAltMobileNo] [nvarchar](15) NULL,
	[CustomerNotes] [nvarchar](max) NULL,
	[CustomerCreatedBranchID] [bigint] NOT NULL,
	[CustomerCountry] [nvarchar](50) NULL,
	[CustomerCreatedBy] [nvarchar](50) NULL,
	[CustomerIsActive] [char](1) NOT NULL,
	[CustomerCreatedDt] [datetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC,
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerMembership]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerMembership](
	[CustomerMembershipID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[CreatedAtBranchID] [bigint] NOT NULL,
	[MembershipID] [bigint] NOT NULL,
	[IsMembershipActive] [char](1) NOT NULL,
	[MembershipStartDt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CustomerMembership] PRIMARY KEY CLUSTERED 
(
	[CustomerMembershipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[BaseBranchID] [bigint] NOT NULL,
	[EmpCode] [nvarchar](50) NULL,
	[EmpFName] [nvarchar](50) NULL,
	[EmpLName] [nvarchar](50) NULL,
	[EmpGender] [char](1) NULL,
	[EmpTypeID] [int] NULL,
	[IsOnPayRoll] [char](1) NOT NULL,
	[EmpContactNo] [nvarchar](20) NULL,
	[IsActive] [char](1) NOT NULL,
	[EmpCreatedDt] [datetime] NOT NULL,
	[EmpCreatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC,
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeType]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeType](
	[EmpTypeID] [int] IDENTITY(1,1) NOT NULL,
	[EmpType] [nvarchar](50) NOT NULL,
	[TypeDesc] [nvarchar](50) NULL,
 CONSTRAINT [PK_LookupEmployeeType] PRIMARY KEY CLUSTERED 
(
	[EmpTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiftCert]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GiftCert](
	[GiftCertID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[IssuedAtBranchID] [bigint] NOT NULL,
	[GiftCertCode] [nvarchar](50) NOT NULL,
	[GiftCertDesc] [nvarchar](100) NULL,
	[GiftCertStartDt] [datetime] NULL,
	[GiftCertEndDt] [datetime] NULL,
	[IsGiftCertActive] [char](1) NOT NULL,
	[GiftCertAmount] [decimal](8, 2) NULL,
	[CreatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_GiftCert] PRIMARY KEY CLUSTERED 
(
	[GiftCertID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InventoryRqdForService]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryRqdForService](
	[InventoryRqdForServiceID] [bigint] IDENTITY(1,1) NOT NULL,
	[ServiceID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[QtyUsed] [decimal](8, 2) NULL,
 CONSTRAINT [PK_InventoryRqdForService] PRIMARY KEY CLUSTERED 
(
	[InventoryRqdForServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InventoryRqdForTreatment]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryRqdForTreatment](
	[InventoryRqdForTreatmentID] [bigint] IDENTITY(1,1) NOT NULL,
	[TreatmentID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[QtyUsed] [decimal](8, 2) NULL,
 CONSTRAINT [PK_InventoryRqdForTreatment] PRIMARY KEY CLUSTERED 
(
	[InventoryRqdForTreatmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LookupBranchRegion]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupBranchRegion](
	[BranchRegionID] [int] NOT NULL,
	[RegionName] [nvarchar](32) NOT NULL,
	[Comment] [nvarchar](50) NULL,
 CONSTRAINT [PK_LookupBranchRegion] PRIMARY KEY CLUSTERED 
(
	[BranchRegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LookupCountry]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupCountry](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryCode] [nvarchar](10) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LookupCountry] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LookupCustomerType]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupCustomerType](
	[CustomerTypeID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerType] [nvarchar](50) NULL,
	[CustomerTypeDesc] [nvarchar](50) NULL,
 CONSTRAINT [PK_LookupCustomerType] PRIMARY KEY CLUSTERED 
(
	[CustomerTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LookUpProductUoM]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookUpProductUoM](
	[ProductUoMID] [int] IDENTITY(1,1) NOT NULL,
	[ProductUoM] [nvarchar](50) NOT NULL,
	[ProductUoMDesc] [nvarchar](100) NULL,
 CONSTRAINT [PK_LookUpProductUoM] PRIMARY KEY CLUSTERED 
(
	[ProductUoMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LookupState]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupState](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[StateCode] [nvarchar](5) NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LookupState] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Membership]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membership](
	[MembershipID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[MembershipName] [nvarchar](50) NOT NULL,
	[MembershipDesc] [nvarchar](50) NULL,
	[MembershipCost] [decimal](8, 2) NULL,
	[MembershipDurationMonths] [int] NULL,
 CONSTRAINT [PK_Membership] PRIMARY KEY CLUSTERED 
(
	[MembershipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[BranchID] [bigint] NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[OrderDt] [datetime] NOT NULL,
	[OrderDiscount] [decimal](8, 2) NULL,
	[OrderGrossAmt] [decimal](8, 2) NULL,
	[OrderNetAmt] [decimal](8, 2) NULL,
	[OrderCreatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductCode] [nvarchar](15) NULL,
	[ProductDesc] [nvarchar](100) NULL,
	[ProductWeight] [decimal](8, 2) NOT NULL,
	[ProductUoMID] [int] NOT NULL,
	[ProductCurrMRP] [decimal](8, 2) NOT NULL,
	[ProductBalanceQty] [int] NULL,
	[ProductMinStockLvl] [int] NULL,
	[ProductVendorID] [bigint] NULL,
	[ProductMfgDt] [datetime] NULL,
	[ProductExpDt] [datetime] NULL,
	[ProductBarCode] [nvarchar](100) NULL,
	[ProductIsActive] [char](1) NOT NULL,
	[ProductCreatedDt] [datetime] NOT NULL,
	[ProductCreatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Service]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[ServiceName] [nvarchar](50) NOT NULL,
	[ServiceDesc] [nvarchar](100) NULL,
	[CreatedDt] [datetime] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uc_Service] UNIQUE NONCLUSTERED 
(
	[CompanyID] ASC,
	[ServiceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tax]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tax](
	[TaxID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[BranchID] [bigint] NOT NULL,
	[TaxName] [nvarchar](10) NOT NULL,
	[TaxPercentage] [decimal](5, 2) NOT NULL,
	[TaxDesc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tax] PRIMARY KEY CLUSTERED 
(
	[TaxID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Treatment]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treatment](
	[TreatmentID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[TreatmentName] [nvarchar](50) NOT NULL,
	[TreatmentDesc] [nvarchar](100) NULL,
	[TreatmentDuration] [int] NULL,
	[CreatedDt] [datetime] NOT NULL,
 CONSTRAINT [PK_Treatment] PRIMARY KEY CLUSTERED 
(
	[TreatmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uc_Treatment] UNIQUE NONCLUSTERED 
(
	[CompanyID] ASC,
	[TreatmentName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Voucher](
	[VoucherID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [bigint] NOT NULL,
	[VoucherCode] [nvarchar](50) NOT NULL,
	[VoucherDesc] [nvarchar](100) NULL,
	[VoucherStartDt] [datetime] NULL,
	[VoucherEndDt] [datetime] NULL,
	[IsVoucherActive] [char](1) NOT NULL,
	[VoucherAmount] [decimal](8, 2) NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[VoucherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[XrefServiceTreatment]    Script Date: 7/31/2015 1:52:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XrefServiceTreatment](
	[ServiceTreatmentXrefID] [bigint] IDENTITY(1,1) NOT NULL,
	[ServiceID] [bigint] NOT NULL,
	[TreatmentID] [bigint] NOT NULL,
	[CompanyID] [bigint] NOT NULL,
 CONSTRAINT [PK_XrefServiceTreatment] PRIMARY KEY CLUSTERED 
(
	[ServiceTreatmentXrefID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AppointmentDiary] ADD  CONSTRAINT [DF_ConsultantBookings_Status]  DEFAULT ((0)) FOR [StatusENUM]
GO
ALTER TABLE [dbo].[Branch] ADD  CONSTRAINT [Df_BranchIsActive]  DEFAULT ('Y') FOR [BranchIsActive]
GO
ALTER TABLE [dbo].[Branch] ADD  CONSTRAINT [Df_BranchCreatedDt]  DEFAULT (switchoffset(sysdatetimeoffset(),'+05:30')) FOR [BranchCreatedDt]
GO
ALTER TABLE [dbo].[BranchTreatmentCost] ADD  CONSTRAINT [DF_BranchTreatmentCost_TreatmentCost]  DEFAULT ((0.0)) FOR [TreatmentCost]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('Y') FOR [CustomerIsActive]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT (switchoffset(sysdatetimeoffset(),'+05:30')) FOR [CustomerCreatedDt]
GO
ALTER TABLE [dbo].[CustomerMembership] ADD  CONSTRAINT [DF_CustomerMembership_IsMembershipActive]  DEFAULT ('Y') FOR [IsMembershipActive]
GO
ALTER TABLE [dbo].[CustomerMembership] ADD  CONSTRAINT [DF_CustomerMembership_MembershipStartDt]  DEFAULT (switchoffset(sysdatetimeoffset(),'+05:30')) FOR [MembershipStartDt]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_IsOnPayRoll]  DEFAULT ('Y') FOR [IsOnPayRoll]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_IsActive]  DEFAULT ('Y') FOR [IsActive]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_EmpCreatedDt]  DEFAULT (switchoffset(sysdatetimeoffset(),'+05:30')) FOR [EmpCreatedDt]
GO
ALTER TABLE [dbo].[GiftCert] ADD  CONSTRAINT [DF_GiftCert_IsGiftCertActive]  DEFAULT ('Y') FOR [IsGiftCertActive]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_OrderDt]  DEFAULT (switchoffset(sysdatetimeoffset(),'+05:30')) FOR [OrderDt]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ProductIsActive]  DEFAULT ('Y') FOR [ProductIsActive]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ProductCreatedDt]  DEFAULT (switchoffset(sysdatetimeoffset(),'+05:30')) FOR [ProductCreatedDt]
GO
ALTER TABLE [dbo].[Service] ADD  CONSTRAINT [DF_Package_CreatedDt]  DEFAULT (switchoffset(sysdatetimeoffset(),'+05:30')) FOR [CreatedDt]
GO
ALTER TABLE [dbo].[Treatment] ADD  CONSTRAINT [DF_Treatment_CreatedDt]  DEFAULT (switchoffset(sysdatetimeoffset(),'+05:30')) FOR [CreatedDt]
GO
ALTER TABLE [dbo].[Voucher] ADD  CONSTRAINT [DF_Voucher_IsVoucherActive]  DEFAULT ('Y') FOR [IsVoucherActive]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Branch]  WITH CHECK ADD  CONSTRAINT [FK_Branch_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Branch] CHECK CONSTRAINT [FK_Branch_Company]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Company]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_LookupCustomerType] FOREIGN KEY([CustomerTypeID])
REFERENCES [dbo].[LookupCustomerType] ([CustomerTypeID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_LookupCustomerType]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_LookupEmployeeType] FOREIGN KEY([EmpTypeID])
REFERENCES [dbo].[EmployeeType] ([EmpTypeID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_LookupEmployeeType]
GO
ALTER TABLE [dbo].[InventoryRqdForService]  WITH CHECK ADD  CONSTRAINT [FK_InventoryRqdForService_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[InventoryRqdForService] CHECK CONSTRAINT [FK_InventoryRqdForService_Product]
GO
ALTER TABLE [dbo].[InventoryRqdForService]  WITH CHECK ADD  CONSTRAINT [FK_InventoryRqdForService_Service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])
GO
ALTER TABLE [dbo].[InventoryRqdForService] CHECK CONSTRAINT [FK_InventoryRqdForService_Service]
GO
ALTER TABLE [dbo].[InventoryRqdForTreatment]  WITH CHECK ADD  CONSTRAINT [FK_InventoryRqdForTreatment_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[InventoryRqdForTreatment] CHECK CONSTRAINT [FK_InventoryRqdForTreatment_Product]
GO
ALTER TABLE [dbo].[InventoryRqdForTreatment]  WITH CHECK ADD  CONSTRAINT [FK_InventoryRqdForTreatment_Treatment] FOREIGN KEY([TreatmentID])
REFERENCES [dbo].[Treatment] ([TreatmentID])
GO
ALTER TABLE [dbo].[InventoryRqdForTreatment] CHECK CONSTRAINT [FK_InventoryRqdForTreatment_Treatment]
GO
ALTER TABLE [dbo].[LookupState]  WITH CHECK ADD  CONSTRAINT [FK_LookupState_LookupCountry] FOREIGN KEY([CountryID])
REFERENCES [dbo].[LookupCountry] ([CountryID])
GO
ALTER TABLE [dbo].[LookupState] CHECK CONSTRAINT [FK_LookupState_LookupCountry]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_LookUpProductUoM] FOREIGN KEY([ProductUoMID])
REFERENCES [dbo].[LookUpProductUoM] ([ProductUoMID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_LookUpProductUoM]
GO
ALTER TABLE [dbo].[XrefServiceTreatment]  WITH CHECK ADD  CONSTRAINT [FK_XrefServiceTreatment_Service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])
GO
ALTER TABLE [dbo].[XrefServiceTreatment] CHECK CONSTRAINT [FK_XrefServiceTreatment_Service]
GO
ALTER TABLE [dbo].[XrefServiceTreatment]  WITH CHECK ADD  CONSTRAINT [FK_XrefServiceTreatment_Treatment] FOREIGN KEY([TreatmentID])
REFERENCES [dbo].[Treatment] ([TreatmentID])
GO
ALTER TABLE [dbo].[XrefServiceTreatment] CHECK CONSTRAINT [FK_XrefServiceTreatment_Treatment]
GO
