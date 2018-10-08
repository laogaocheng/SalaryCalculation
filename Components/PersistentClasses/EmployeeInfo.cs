using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("员工信息")]
    public partial class EmployeeInfo : XPLiteObject
    {
        string f员工编号;
        [Key]
        [Size(20)]
        public string 员工编号
        {
            get { return f员工编号; }
            set { SetPropertyValue<string>("员工编号", ref f员工编号, value); }
        }
        string f姓名;
        [Size(10)]
        public string 姓名
        {
            get { return f姓名; }
            set { SetPropertyValue<string>("姓名", ref f姓名, value); }
        }
        string f性别;
        [Size(2)]
        public string 性别
        {
            get { return f性别; }
            set { SetPropertyValue<string>("性别", ref f性别, value); }
        }
        string f公司;
        [Size(20)]
        public string 公司
        {
            get { return f公司; }
            set { SetPropertyValue<string>("公司", ref f公司, value); }
        }
        string f部门;
        [Size(20)]
        public string 部门
        {
            get { return f部门; }
            set { SetPropertyValue<string>("部门", ref f部门, value); }
        }
        string f状态;
        [Size(10)]
        public string 状态
        {
            get { return f状态; }
            set { SetPropertyValue<string>("状态", ref f状态, value); }
        }
        string f身份证号;
        [Size(20)]
        public string 身份证号
        {
            get { return f身份证号; }
            set { SetPropertyValue<string>("身份证号", ref f身份证号, value); }
        }
        string f职位代码;
        [Size(50)]
        public string 职位代码
        {
            get { return f职位代码; }
            set { SetPropertyValue<string>("职位代码", ref f职位代码, value); }
        }
        string f职务代码;
        [Size(20)]
        public string 职务代码
        {
            get { return f职务代码; }
            set { SetPropertyValue<string>("职务代码", ref f职务代码, value); }
        }
        string f职务等级;
        [Size(20)]
        public string 职务等级
        {
            get { return f职务等级; }
            set { SetPropertyValue<string>("职务等级", ref f职务等级, value); }
        }
        string f族群代码;
        [Size(20)]
        public string 族群代码
        {
            get { return f族群代码; }
            set { SetPropertyValue<string>("族群代码", ref f族群代码, value); }
        }
        string f集合;
        [Size(10)]
        public string 集合
        {
            get { return f集合; }
            set { SetPropertyValue<string>("集合", ref f集合, value); }
        }
        string f薪资体系;
        [Size(20)]
        public string 薪资体系
        {
            get { return f薪资体系; }
            set { SetPropertyValue<string>("薪资体系", ref f薪资体系, value); }
        }
        string f薪等;
        [Size(20)]
        public string 薪等
        {
            get { return f薪等; }
            set { SetPropertyValue<string>("薪等", ref f薪等, value); }
        }
        int f薪级;
        public int 薪级
        {
            get { return f薪级; }
            set { SetPropertyValue<int>("薪级", ref f薪级, value); }
        }
        string f薪资组;
        [Size(20)]
        public string 薪资组
        {
            get { return f薪资组; }
            set { SetPropertyValue<string>("薪资组", ref f薪资组, value); }
        }
        string f上个月薪资组;
        [Size(20)]
        public string 上个月薪资组
        {
            get { return f上个月薪资组; }
            set { SetPropertyValue<string>("上个月薪资组", ref f上个月薪资组, value); }
        }
        string f银行账号;
        public string 银行账号
        {
            get { return f银行账号; }
            set { SetPropertyValue<string>("银行账号", ref f银行账号, value); }
        }
        string f帐户名称;
        public string 帐户名称
        {
            get { return f帐户名称; }
            set { SetPropertyValue<string>("帐户名称", ref f帐户名称, value); }
        }
        string f财务公司;
        [Size(50)]
        public string 财务公司
        {
            get { return f财务公司; }
            set { SetPropertyValue<string>("财务公司", ref f财务公司, value); }
        }
        string f财务部门;
        [Size(50)]
        public string 财务部门
        {
            get { return f财务部门; }
            set { SetPropertyValue<string>("财务部门", ref f财务部门, value); }
        }
        int f财务部门序号;
        public int 财务部门序号
        {
            get { return f财务部门序号; }
            set { SetPropertyValue<int>("财务部门序号", ref f财务部门序号, value); }
        }
        int f员工序号;
        public int 员工序号
        {
            get { return f员工序号; }
            set { SetPropertyValue<int>("员工序号", ref f员工序号, value); }
        }
        DateTime f出生日期;
        public DateTime 出生日期
        {
            get { return f出生日期; }
            set { SetPropertyValue<DateTime>("出生日期", ref f出生日期, value); }
        }
        DateTime f创建时间;
        public DateTime 创建时间
        {
            get { return f创建时间; }
            set { SetPropertyValue<DateTime>("创建时间", ref f创建时间, value); }
        }
        DateTime f离职时间;
        public DateTime 离职时间
        {
            get { return f离职时间; }
            set { SetPropertyValue<DateTime>("离职时间", ref f离职时间, value); }
        }
        DateTime f上次同步时间;
        public DateTime 上次同步时间
        {
            get { return f上次同步时间; }
            set { SetPropertyValue<DateTime>("上次同步时间", ref f上次同步时间, value); }
        }
        //2018-1-8 新增，用于存储工资职级, 相当于职务等级的子类，比如 主任级包括 主任、生产支持主任、生成辅助主任、生产一线主任
        string f职等;
        [Size(50)]
        public string 职等
        {
            get { return f职等; }
            set { SetPropertyValue<string>("职等", ref f职等, value); }
        }
        //2018-1-23 新增
        bool f是管培生;
        public bool 是管培生
        {
            get { return f是管培生; }
            set { SetPropertyValue<bool>("是管培生", ref f是管培生, value); }
        }
        public EmployeeInfo(Session session) : base(session) { }
        public EmployeeInfo() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
