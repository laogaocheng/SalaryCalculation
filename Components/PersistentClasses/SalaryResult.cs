using System;
using DevExpress.Xpo;
namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("基础工资表")]
    public partial class SalaryResult : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f日历组;
        [Size(20)]
        public string 日历组
        {
            get { return f日历组; }
            set { SetPropertyValue<string>("日历组", ref f日历组, value); }
        }
        string f期间;
        [Size(20)]
        public string 期间
        {
            get { return f期间; }
            set { SetPropertyValue<string>("期间", ref f期间, value); }
        }
        string f姓名;
        [Size(20)]
        public string 姓名
        {
            get { return f姓名; }
            set { SetPropertyValue<string>("姓名", ref f姓名, value); }
        }
        string f员工编号;
        [Size(20)]
        public string 员工编号
        {
            get { return f员工编号; }
            set { SetPropertyValue<string>("员工编号", ref f员工编号, value); }
        }
        string f员工类型;
        [Size(20)]
        public string 员工类型
        {
            get { return f员工类型; }
            set { SetPropertyValue<string>("员工类型", ref f员工类型, value); }
        }
        int f年度;
        public int 年度
        {
            get { return f年度; }
            set { SetPropertyValue<int>("年度", ref f年度, value); }
        }
        int f月份;
        public int 月份
        {
            get { return f月份; }
            set { SetPropertyValue<int>("月份", ref f月份, value); }
        }
        string f公司编号;
        [Size(3)]
        public string 公司编号
        {
            get { return f公司编号; }
            set { SetPropertyValue<string>("公司编号", ref f公司编号, value); }
        }
        string f部门编号;
        [Size(10)]
        public string 部门编号
        {
            get { return f部门编号; }
            set { SetPropertyValue<string>("部门编号", ref f部门编号, value); }
        }
        string f机构编号;
        [Size(10)]
        public string 机构编号
        {
            get { return f机构编号; }
            set { SetPropertyValue<string>("机构编号", ref f机构编号, value); }
        }
        string f银行账号;
        public string 银行账号
        {
            get { return f银行账号; }
            set { SetPropertyValue<string>("银行账号", ref f银行账号, value); }
        }
        string f公司名称;
        public string 公司名称
        {
            get { return f公司名称; }
            set { SetPropertyValue<string>("公司名称", ref f公司名称, value); }
        }
        string f部门名称;
        public string 部门名称
        {
            get { return f部门名称; }
            set { SetPropertyValue<string>("部门名称", ref f部门名称, value); }
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
        string f帐户名称;
        public string 帐户名称
        {
            get { return f帐户名称; }
            set { SetPropertyValue<string>("帐户名称", ref f帐户名称, value); }
        }
        string f薪资组;
        [Size(10)]
        public string 薪资组
        {
            get { return f薪资组; }
            set { SetPropertyValue<string>("薪资组", ref f薪资组, value); }
        }
        string f薪资组名称;
        public string 薪资组名称
        {
            get { return f薪资组名称; }
            set { SetPropertyValue<string>("薪资组名称", ref f薪资组名称, value); }
        }
        string f薪资集合;
        [Size(3)]
        public string 薪资集合
        {
            get { return f薪资集合; }
            set { SetPropertyValue<string>("薪资集合", ref f薪资集合, value); }
        }
        string f薪酬体系编号;
        [Size(4)]
        public string 薪酬体系编号
        {
            get { return f薪酬体系编号; }
            set { SetPropertyValue<string>("薪酬体系编号", ref f薪酬体系编号, value); }
        }
        string f薪等编号;
        [Size(3)]
        public string 薪等编号
        {
            get { return f薪等编号; }
            set { SetPropertyValue<string>("薪等编号", ref f薪等编号, value); }
        }
        string f薪等名称;
        public string 薪等名称
        {
            get { return f薪等名称; }
            set { SetPropertyValue<string>("薪等名称", ref f薪等名称, value); }
        }
        string f薪级编号;
        [Size(3)]
        public string 薪级编号
        {
            get { return f薪级编号; }
            set { SetPropertyValue<string>("薪级编号", ref f薪级编号, value); }
        }
        string f职务代码;
        [Size(6)]
        public string 职务代码
        {
            get { return f职务代码; }
            set { SetPropertyValue<string>("职务代码", ref f职务代码, value); }
        }
        string f职务等级;
        [Size(10)]
        public string 职务等级
        {
            get { return f职务等级; }
            set { SetPropertyValue<string>("职务等级", ref f职务等级, value); }
        }
        string f职位编号;
        [Size(8)]
        public string 职位编号
        {
            get { return f职位编号; }
            set { SetPropertyValue<string>("职位编号", ref f职位编号, value); }
        }
        string f班别;
        [Size(2)]
        public string 班别
        {
            get { return f班别; }
            set { SetPropertyValue<string>("班别", ref f班别, value); }
        }
        string f身份证号;
        [Size(20)]
        public string 身份证号
        {
            get { return f身份证号; }
            set { SetPropertyValue<string>("身份证号", ref f身份证号, value); }
        }
        decimal f企业排班天数;
        public decimal 企业排班天数
        {
            get { return f企业排班天数; }
            set { SetPropertyValue<decimal>("企业排班天数", ref f企业排班天数, value); }
        }
        decimal f法定工作日天数;
        public decimal 法定工作日天数
        {
            get { return f法定工作日天数; }
            set { SetPropertyValue<decimal>("法定工作日天数", ref f法定工作日天数, value); }
        }
        decimal f实际出勤天数;
        public decimal 实际出勤天数
        {
            get { return f实际出勤天数; }
            set { SetPropertyValue<decimal>("实际出勤天数", ref f实际出勤天数, value); }
        }
        decimal f法定工作日出勤天数;
        public decimal 法定工作日出勤天数
        {
            get { return f法定工作日出勤天数; }
            set { SetPropertyValue<decimal>("法定工作日出勤天数", ref f法定工作日出勤天数, value); }
        }
        decimal f法定节假日出勤天数;
        public decimal 法定节假日出勤天数
        {
            get { return f法定节假日出勤天数; }
            set { SetPropertyValue<decimal>("法定节假日出勤天数", ref f法定节假日出勤天数, value); }
        }
        decimal f休息日出勤天数;
        public decimal 休息日出勤天数
        {
            get { return f休息日出勤天数; }
            set { SetPropertyValue<decimal>("休息日出勤天数", ref f休息日出勤天数, value); }
        }
        decimal f月综合出勤天数;
        public decimal 月综合出勤天数
        {
            get { return f月综合出勤天数; }
            set { SetPropertyValue<decimal>("月综合出勤天数", ref f月综合出勤天数, value); }
        }
        decimal f工作日延长出勤小时数;
        public decimal 工作日延长出勤小时数
        {
            get { return f工作日延长出勤小时数; }
            set { SetPropertyValue<decimal>("工作日延长出勤小时数", ref f工作日延长出勤小时数, value); }
        }
        decimal f法定工作日出勤工资;
        public decimal 法定工作日出勤工资
        {
            get { return f法定工作日出勤工资; }
            set { SetPropertyValue<decimal>("法定工作日出勤工资", ref f法定工作日出勤工资, value); }
        }
        decimal f法定节假日出勤工资;
        public decimal 法定节假日出勤工资
        {
            get { return f法定节假日出勤工资; }
            set { SetPropertyValue<decimal>("法定节假日出勤工资", ref f法定节假日出勤工资, value); }
        }
        decimal f休息日出勤工资;
        public decimal 休息日出勤工资
        {
            get { return f休息日出勤工资; }
            set { SetPropertyValue<decimal>("休息日出勤工资", ref f休息日出勤工资, value); }
        }
        decimal f月综合出勤工资;
        public decimal 月综合出勤工资
        {
            get { return f月综合出勤工资; }
            set { SetPropertyValue<decimal>("月综合出勤工资", ref f月综合出勤工资, value); }
        }
        decimal f工作日延长工作出勤工资;
        public decimal 工作日延长工作出勤工资
        {
            get { return f工作日延长工作出勤工资; }
            set { SetPropertyValue<decimal>("工作日延长工作出勤工资", ref f工作日延长工作出勤工资, value); }
        }
        decimal f未休年休假工资;
        public decimal 未休年休假工资
        {
            get { return f未休年休假工资; }
            set { SetPropertyValue<decimal>("未休年休假工资", ref f未休年休假工资, value); }
        }
        decimal f社保个人缴纳金额;
        public decimal 社保个人缴纳金额
        {
            get { return f社保个人缴纳金额; }
            set { SetPropertyValue<decimal>("社保个人缴纳金额", ref f社保个人缴纳金额, value); }
        }
        decimal f社保公司缴纳金额;
        public decimal 社保公司缴纳金额
        {
            get { return f社保公司缴纳金额; }
            set { SetPropertyValue<decimal>("社保公司缴纳金额", ref f社保公司缴纳金额, value); }
        }
        decimal f养老保险个人缴纳金额;
        public decimal 养老保险个人缴纳金额
        {
            get { return f养老保险个人缴纳金额; }
            set { SetPropertyValue<decimal>("养老保险个人缴纳金额", ref f养老保险个人缴纳金额, value); }
        }
        decimal f医疗保险个人缴纳金额;
        public decimal 医疗保险个人缴纳金额
        {
            get { return f医疗保险个人缴纳金额; }
            set { SetPropertyValue<decimal>("医疗保险个人缴纳金额", ref f医疗保险个人缴纳金额, value); }
        }
        decimal f失业保险个人缴纳金额;
        public decimal 失业保险个人缴纳金额
        {
            get { return f失业保险个人缴纳金额; }
            set { SetPropertyValue<decimal>("失业保险个人缴纳金额", ref f失业保险个人缴纳金额, value); }
        }
        decimal f住房公积金个人缴纳金额;
        public decimal 住房公积金个人缴纳金额
        {
            get { return f住房公积金个人缴纳金额; }
            set { SetPropertyValue<decimal>("住房公积金个人缴纳金额", ref f住房公积金个人缴纳金额, value); }
        }
        decimal f大病医疗个人缴纳金额;
        public decimal 大病医疗个人缴纳金额
        {
            get { return f大病医疗个人缴纳金额; }
            set { SetPropertyValue<decimal>("大病医疗个人缴纳金额", ref f大病医疗个人缴纳金额, value); }
        }        
        decimal f个人所得税金额;
        public decimal 个人所得税金额
        {
            get { return f个人所得税金额; }
            set { SetPropertyValue<decimal>("个人所得税金额", ref f个人所得税金额, value); }
        }
        decimal f代垫费用;
        public decimal 代垫费用
        {
            get { return f代垫费用; }
            set { SetPropertyValue<decimal>("代垫费用", ref f代垫费用, value); }
        }
        decimal f职级工资;
        public decimal 职级工资
        {
            get { return f职级工资; }
            set { SetPropertyValue<decimal>("职级工资", ref f职级工资, value); }
        }
        decimal f挂钩效益工资;
        public decimal 挂钩效益工资
        {
            get { return f挂钩效益工资; }
            set { SetPropertyValue<decimal>("挂钩效益工资", ref f挂钩效益工资, value); }
        }        
        decimal f工资降级;
        public decimal 工资降级
        {
            get { return f工资降级; }
            set { SetPropertyValue<decimal>("工资降级", ref f工资降级, value); }
        }
        decimal f其他所得;
        public decimal 其他所得
        {
            get { return f其他所得; }
            set { SetPropertyValue<decimal>("其他所得", ref f其他所得, value); }
        }
        decimal f其他扣款;
        public decimal 其他扣款
        {
            get { return f其他扣款; }
            set { SetPropertyValue<decimal>("其他扣款", ref f其他扣款, value); }
        }
        decimal f预留风险金;
        public decimal 预留风险金
        {
            get { return f预留风险金; }
            set { SetPropertyValue<decimal>("预留风险金", ref f预留风险金, value); }
        }
        decimal f特殊社保的基准工资;
        public decimal 特殊社保的基准工资
        {
            get { return f特殊社保的基准工资; }
            set { SetPropertyValue<decimal>("特殊社保的基准工资", ref f特殊社保的基准工资, value); }
        }
        decimal f基数等级与基准工资差额;
        public decimal 基数等级与基准工资差额
        {
            get { return f基数等级与基准工资差额; }
            set { SetPropertyValue<decimal>("基数等级与基准工资差额", ref f基数等级与基准工资差额, value); }
        }
        decimal f出勤工资;
        public decimal 出勤工资
        {
            get { return f出勤工资; }
            set { SetPropertyValue<decimal>("出勤工资", ref f出勤工资, value); }
        }
        decimal f应得满勤奖;
        public decimal 应得满勤奖
        {
            get { return f应得满勤奖; }
            set { SetPropertyValue<decimal>("应得满勤奖", ref f应得满勤奖, value); }
        }
        decimal f实得满勤奖;
        public decimal 实得满勤奖
        {
            get { return f实得满勤奖; }
            set { SetPropertyValue<decimal>("实得满勤奖", ref f实得满勤奖, value); }
        }
        decimal f设定工资;
        public decimal 设定工资
        {
            get { return f设定工资; }
            set { SetPropertyValue<decimal>("设定工资", ref f设定工资, value); }
        }
        decimal f上表工资;
        public decimal 上表工资
        {
            get { return f上表工资; }
            set { SetPropertyValue<decimal>("上表工资", ref f上表工资, value); }
        }        
        decimal f基准工资;
        public decimal 基准工资
        {
            get { return f基准工资; }
            set { SetPropertyValue<decimal>("基准工资", ref f基准工资, value); }
        }
        decimal f津贴补助;
        public decimal 津贴补助
        {
            get { return f津贴补助; }
            set { SetPropertyValue<decimal>("津贴补助", ref f津贴补助, value); }
        }
        decimal f综合考核工资;
        public decimal 综合考核工资
        {
            get { return f综合考核工资; }
            set { SetPropertyValue<decimal>("综合考核工资", ref f综合考核工资, value); }
        }
        decimal f奖项;
        public decimal 奖项
        {
            get { return f奖项; }
            set { SetPropertyValue<decimal>("奖项", ref f奖项, value); }
        }
        decimal f扣项;
        public decimal 扣项
        {
            get { return f扣项; }
            set { SetPropertyValue<decimal>("扣项", ref f扣项, value); }
        }
        decimal f上表工资总额;
        public decimal 上表工资总额
        {
            get { return f上表工资总额; }
            set { SetPropertyValue<decimal>("上表工资总额", ref f上表工资总额, value); }
        }
        decimal f应税工资额;
        public decimal 应税工资额
        {
            get { return f应税工资额; }
            set { SetPropertyValue<decimal>("应税工资额", ref f应税工资额, value); }
        }
        decimal f合计应税工资额;
        public decimal 合计应税工资额
        {
            get { return f合计应税工资额; }
            set { SetPropertyValue<decimal>("合计应税工资额", ref f合计应税工资额, value); }
        }
        decimal f实发工资总额;
        public decimal 实发工资总额
        {
            get { return f实发工资总额; }
            set { SetPropertyValue<decimal>("实发工资总额", ref f实发工资总额, value); }
        }
        decimal f工资系数;
        public decimal 工资系数
        {
            get { return f工资系数; }
            set { SetPropertyValue<decimal>("工资系数", ref f工资系数, value); }
        }
        DateTime f上次同步时间;
        public DateTime 上次同步时间
        {
            get { return f上次同步时间; }
            set { SetPropertyValue<DateTime>("上次同步时间", ref f上次同步时间, value); }
        }
        //2018-1-8 新增，用于存储工资职级, 相当于职务等级的子类，比如 主任级包括 主任、生产支持主任、生成辅助主任、生产一线主任
        string f工资职等;
        [Size(50)]
        public string 工资职等
        {
            get { return f工资职等; }
            set { SetPropertyValue<string>("工资职等", ref f工资职等, value); }
        }
        decimal f交通餐饮补助;
        public decimal 交通餐饮补助
        {
            get { return f交通餐饮补助; }
            set { SetPropertyValue<decimal>("交通餐饮补助", ref f交通餐饮补助, value); }
        }
        public SalaryResult(Session session) : base(session) { }
        public SalaryResult() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
