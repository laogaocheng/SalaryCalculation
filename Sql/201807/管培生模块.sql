USE [专用算薪系统]
GO
/****** Object:  Table [dbo].[软件开发人员]    Script Date: 07/12/2018 16:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[软件开发人员](
	[姓名] [nvarchar](20) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_软件开发人员_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[管培生_综合能力评定_录入]    Script Date: 07/12/2018 16:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[管培生_综合能力评定_录入](
	[标识] [uniqueidentifier] NOT NULL,
	[员工编号] [varchar](20) NOT NULL,
	[姓名] [nvarchar](20) NOT NULL,
	[年度] [int] NOT NULL,
	[能力级别] [varchar](10) NULL,
	[开始执行日期] [datetime] NULL,
	[届别] [nvarchar](10) NULL,
	[岗位级别] [nvarchar](10) NULL,
	[序号] [int] NULL,
	[录入人] [nvarchar](20) NULL,
	[录入时间] [datetime] NULL,
	[是验证录入] [bit] NULL,
	[生效时间] [datetime] NULL,
 CONSTRAINT [PK_管培生_综合能力评定_录入] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[管培生_综合能力评定]    Script Date: 07/12/2018 16:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[管培生_综合能力评定](
	[标识] [uniqueidentifier] NOT NULL,
	[员工编号] [varchar](20) NOT NULL,
	[姓名] [nvarchar](20) NOT NULL,
	[年度] [int] NOT NULL,
	[能力级别] [varchar](10) NULL,
	[创建时间] [datetime] NULL,
	[序号] [int] NULL,
	[届别] [nvarchar](10) NULL,
	[岗位级别] [nvarchar](10) NULL,
	[更新时间] [datetime] NULL,
 CONSTRAINT [PK_管培生_综合能力级别及提资标准] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[管培生_专业属性_录入]    Script Date: 07/12/2018 16:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[管培生_专业属性_录入](
	[标识] [uniqueidentifier] NOT NULL,
	[岗位级别] [nvarchar](20) NULL,
	[学历] [nvarchar](20) NULL,
	[专业名称] [nvarchar](50) NULL,
	[属性] [nvarchar](20) NULL,
	[序号] [int] NULL,
	[录入人] [nvarchar](20) NULL,
	[录入时间] [datetime] NULL,
	[是验证录入] [bit] NULL,
	[生效时间] [datetime] NULL,
	[已确认] [bit] NULL,
	[届别] [nvarchar](10) NULL,
 CONSTRAINT [PK_管培生_专业属性_录入] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[管培生_专业属性]    Script Date: 07/12/2018 16:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[管培生_专业属性](
	[标识] [uniqueidentifier] NOT NULL,
	[岗位级别] [nvarchar](20) NULL,
	[学历] [nvarchar](20) NULL,
	[专业名称] [nvarchar](50) NULL,
	[属性] [nvarchar](20) NULL,
	[届别] [nvarchar](10) NULL,
	[序号] [int] NULL,
	[更新时间] [datetime] NULL,
 CONSTRAINT [PK_管培生_专业属性] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[管培生_提资标准_录入]    Script Date: 07/12/2018 16:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[管培生_提资标准_录入](
	[标识] [uniqueidentifier] NOT NULL,
	[届别] [nvarchar](10) NULL,
	[岗位级别] [varchar](10) NULL,
	[类别] [nvarchar](20) NULL,
	[序号] [int] NULL,
	[一阶起薪] [decimal](6, 2) NULL,
	[二阶起薪] [decimal](6, 2) NULL,
	[满阶A起薪] [decimal](6, 2) NULL,
	[满阶B起薪] [decimal](6, 2) NULL,
	[满阶C起薪] [decimal](6, 2) NULL,
	[一阶起薪方式] [int] NULL,
	[二阶起薪方式] [int] NULL,
	[满阶起薪方式] [int] NULL,
	[一阶增幅1] [decimal](6, 2) NULL,
	[一阶增幅2] [decimal](6, 2) NULL,
	[一阶增幅3] [decimal](6, 2) NULL,
	[一阶增幅4] [decimal](6, 2) NULL,
	[一阶增幅5] [decimal](6, 2) NULL,
	[一阶增幅6] [decimal](6, 2) NULL,
	[一阶增幅7] [decimal](6, 2) NULL,
	[一阶增幅8] [decimal](6, 2) NULL,
	[一阶增幅9] [decimal](6, 2) NULL,
	[一阶增幅10] [decimal](6, 2) NULL,
	[一阶增幅11] [decimal](6, 2) NULL,
	[一阶增幅12] [decimal](6, 2) NULL,
	[二阶增幅1] [decimal](6, 2) NULL,
	[二阶增幅2] [decimal](6, 2) NULL,
	[二阶增幅3] [decimal](6, 2) NULL,
	[二阶增幅4] [decimal](6, 2) NULL,
	[二阶增幅5] [decimal](6, 2) NULL,
	[二阶增幅6] [decimal](6, 2) NULL,
	[生效时间] [datetime] NULL,
	[创建人] [nvarchar](20) NULL,
	[录入人] [nvarchar](20) NULL,
	[录入时间] [datetime] NULL,
	[是验证录入] [bit] NULL,
 CONSTRAINT [PK_管培生_提资标准_录入] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[管培生_提资标准]    Script Date: 07/12/2018 16:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[管培生_提资标准](
	[标识] [uniqueidentifier] NOT NULL,
	[届别] [nvarchar](10) NULL,
	[岗位级别] [varchar](10) NULL,
	[能力级别] [varchar](10) NULL,
	[类别] [nvarchar](20) NULL,
	[序号] [int] NULL,
	[提资周期] [nvarchar](20) NULL,
	[提资序数] [int] NULL,
	[增幅] [decimal](8, 2) NULL,
	[年薪] [decimal](8, 2) NULL,
	[提资方式] [int] NULL,
	[创建人] [nvarchar](20) NULL,
	[创建时间] [datetime] NULL,
 CONSTRAINT [PK_管培生_提资标准] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[管培生_基本信息_录入]    Script Date: 07/12/2018 16:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[管培生_基本信息_录入](
	[标识] [uniqueidentifier] NOT NULL,
	[员工编号] [varchar](20) NOT NULL,
	[姓名] [nvarchar](20) NOT NULL,
	[学历] [nvarchar](20) NULL,
	[学历备注] [nvarchar](20) NULL,
	[专业名称] [nvarchar](20) NULL,
	[专业属性] [nvarchar](10) NULL,
	[岗位级别] [nvarchar](10) NULL,
	[岗位类型] [nvarchar](20) NULL,
	[入职时间] [datetime] NULL,
	[届别] [nvarchar](10) NULL,
	[年薪] [decimal](8, 2) NULL,
	[备注] [nvarchar](50) NULL,
	[录入人] [nvarchar](20) NULL,
	[录入时间] [datetime] NULL,
	[是验证录入] [bit] NULL,
	[生效时间] [datetime] NULL,
	[序号] [int] NULL,
 CONSTRAINT [PK_管培生_基本信息_录入] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[管培生_基本信息]    Script Date: 07/12/2018 16:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[管培生_基本信息](
	[标识] [uniqueidentifier] NOT NULL,
	[员工编号] [varchar](20) NOT NULL,
	[姓名] [nvarchar](20) NOT NULL,
	[学历] [nvarchar](20) NULL,
	[学历备注] [nvarchar](20) NULL,
	[专业名称] [nvarchar](20) NULL,
	[专业属性] [nvarchar](10) NULL,
	[岗位级别] [nvarchar](10) NULL,
	[岗位类型] [nvarchar](20) NULL,
	[入职时间] [datetime] NULL,
	[届别] [nvarchar](10) NULL,
	[年薪] [decimal](8, 2) NULL,
	[备注] [nvarchar](50) NULL,
	[截止日期] [datetime] NULL,
	[更新时间] [datetime] NULL,
 CONSTRAINT [PK_管培生_基本信息] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[管培生_工资标准_录入]    Script Date: 07/12/2018 16:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[管培生_工资标准_录入](
	[标识] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[序号] [int] NULL,
	[员工编号] [nvarchar](20) NULL,
	[提资序数] [int] NULL,
	[年份] [int] NULL,
	[季度] [int] NULL,
	[增幅] [decimal](8, 2) NULL,
	[年薪] [decimal](8, 2) NULL,
	[月薪] [int] NULL,
	[备注] [nvarchar](50) NULL,
	[开始执行时间] [datetime] NULL,
	[录入人] [nvarchar](20) NULL,
	[录入时间] [datetime] NULL,
	[是验证录入] [bit] NULL,
	[生效时间] [datetime] NULL,
	[姓名] [nvarchar](20) NULL,
 CONSTRAINT [PK_管培生_工资标准_录入] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[管培生_工资标准]    Script Date: 07/12/2018 16:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[管培生_工资标准](
	[标识] [uniqueidentifier] NOT NULL,
	[员工编号] [varchar](20) NOT NULL,
	[姓名] [nvarchar](20) NOT NULL,
	[提资序数] [int] NULL,
	[年份] [int] NULL,
	[季度] [int] NULL,
	[增幅] [decimal](8, 2) NULL,
	[年薪] [decimal](8, 2) NULL,
	[月薪] [int] NULL,
	[备注] [nvarchar](50) NULL,
	[开始执行时间] [datetime] NULL,
	[创建人] [nvarchar](20) NULL,
	[创建时间] [datetime] NULL,
 CONSTRAINT [PK_管培生_提资增幅] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
