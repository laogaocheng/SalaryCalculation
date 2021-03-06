USE [专用算薪系统]
GO
/****** Object:  Table [dbo].[管培生_综合能力评定_录入]    Script Date: 02/08/2018 08:12:00 ******/
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
	[能力级别] [varchar](10) NULL,
	[开始执行日期] [datetime] NULL,
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
/****** Object:  Table [dbo].[管培生_综合能力评定]    Script Date: 02/08/2018 08:12:00 ******/
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
	[能力级别] [varchar](10) NULL,
	[开始执行日期] [datetime] NULL,
	[截止日期] [datetime] NULL,
	[创建时间] [datetime] NULL,
 CONSTRAINT [PK_管培生_综合能力级别及提资标准] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[管培生_提资标准]    Script Date: 02/08/2018 08:12:00 ******/
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
	[类别] [nvarchar](20) NULL,
	[能力级别] [varchar](10) NULL,
	[序号] [int] NULL,
	[提资周期] [nvarchar](20) NULL,
	[提资序数] [int] NULL,
	[增幅] [decimal](8, 2) NULL,
	[年薪] [decimal](8, 2) NULL,
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
/****** Object:  Table [dbo].[管培生_基本信息_录入]    Script Date: 02/08/2018 08:12:00 ******/
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
 CONSTRAINT [PK_管培生_基本信息_录入] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[管培生_基本信息]    Script Date: 02/08/2018 08:12:00 ******/
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
/****** Object:  Table [dbo].[管培生_工资标准_录入]    Script Date: 02/08/2018 08:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[管培生_工资标准_录入](
	[标识] [uniqueidentifier] NOT NULL,
	[员工编号] [varchar](20) NOT NULL,
	[姓名] [nvarchar](20) NOT NULL,
	[年份] [int] NULL,
	[季度] [int] NULL,
	[增幅] [decimal](8, 2) NULL,
	[年薪] [decimal](8, 2) NULL,
	[备注] [nvarchar](50) NULL,
	[录入人] [nvarchar](20) NULL,
	[录入时间] [datetime] NULL,
	[是验证录入] [bit] NULL,
	[生效时间] [datetime] NULL,
 CONSTRAINT [PK_管培生_提资增幅_录入] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[管培生_工资标准]    Script Date: 02/08/2018 08:12:00 ******/
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
