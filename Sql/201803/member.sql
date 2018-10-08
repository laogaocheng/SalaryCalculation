USE [专用算薪系统]
GO
/****** Object:  Table [dbo].[会员_等级]    Script Date: 03/20/2018 08:29:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[会员_等级](
	[标识] [uniqueidentifier] NOT NULL,
	[员工编号] [nvarchar](20) NOT NULL,
	[公司编码] [nvarchar](10) NULL,
	[职务等级] [nvarchar](10) NULL,
 CONSTRAINT [PK_会员_等级] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[会员_部门_录入]    Script Date: 03/20/2018 08:29:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[会员_部门_录入](
	[标识] [uniqueidentifier] NOT NULL,
	[员工编号] [nvarchar](20) NOT NULL,
	[可查公司编码] [varchar](50) NULL,
	[可查部门编号] [varchar](50) NULL,
	[录入人] [nvarchar](20) NULL,
	[录入时间] [datetime] NULL,
	[是验证录入] [bit] NULL,
	[生效时间] [datetime] NULL,
	[创建人] [nvarchar](20) NULL,
 CONSTRAINT [PK_会员_部门_录入] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[会员_部门]    Script Date: 03/20/2018 08:29:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[会员_部门](
	[标识] [uniqueidentifier] NOT NULL,
	[员工编号] [nvarchar](20) NOT NULL,
	[所属公司编号] [varchar](50) NULL,
	[所属部门编号] [varchar](50) NULL,
	[职务等级代码] [varchar](50) NULL,
	[可查公司编码] [varchar](50) NULL,
	[可查部门编号] [varchar](50) NULL,
 CONSTRAINT [PK_会员_部门] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[会员]    Script Date: 03/20/2018 08:29:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[会员](
	[标识] [uniqueidentifier] NOT NULL,
	[员工编号] [nvarchar](20) NOT NULL,
	[姓名] [nvarchar](10) NULL,
	[密码] [varchar](100) NULL,
	[盐] [varchar](10) NULL,
	[身份证号码] [varchar](20) NULL,
	[用户类型] [nvarchar](20) NULL,
	[有异动] [bit] NULL,
	[创建时间] [datetime] NULL,
	[最后登录时间] [datetime] NULL,
	[公司编号] [nvarchar](50) NULL,
	[部门编号] [nvarchar](50) NULL,
	[职务等级] [nvarchar](50) NULL,
 CONSTRAINT [PK_会员] PRIMARY KEY CLUSTERED 
(
	[标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
