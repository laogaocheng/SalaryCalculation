using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    /// <summary>
    /// 工资表
    /// </summary>
    public class SalResult
    {
        public string 日历组 { get; set; }
        public string 期间 { get; set; }
        public string 姓名 { get; set; }
        public string 身份证号 { get; set; }
        public string 员工编号 { get; set; }
        public string 员工类型 { get; set; }
        public int 年度 { get; set; }
        public int 月份 { get; set; }
        public string 公司编号 { get; set; }
        public string 部门编号 { get; set; }
        public string 机构编号 { get; set; }
        public string 银行账号 { get; set; }
        public string 公司名称 { get; set; }
        public string 部门名称 { get; set; }
        public string 财务公司 { get; set; }
        public string 财务部门 { get; set; }
        public int 财务部门序号 { get; set; }
        public int 员工序号 { get; set; }
        public string 帐户名称 { get; set; }
        public string 薪资组 { get; set; }
        public string 薪资集合 { get; set; }
        public string 薪酬体系编号 { get; set; }
        public string 薪等编号 { get; set; }
        public string 薪级编号 { get; set; }
        public string 职务代码 { get; set; }
        public string 职务等级 { get; set; }
        public string 职位编号 { get; set; }
        public string 班别 { get; set; }
        public decimal 企业排班天数 { get; set; }
        public decimal 法定工作日天数 { get; set; }
        public decimal 实际出勤天数 { get; set; }
        public decimal 法定工作日出勤天数 { get; set; }
        public decimal 法定节假日出勤天数 { get; set; }
        public decimal 休息日出勤天数 { get; set; }
        public decimal 月综合出勤天数 { get; set; }
        public decimal 工作日延长出勤小时数 { get; set; }
        public decimal 法定工作日出勤工资 { get; set; }
        public decimal 法定节假日出勤工资 { get; set; }
        public decimal 休息日出勤工资 { get; set; }
        public decimal 月综合出勤工资 { get; set; }
        public decimal 工作日延长工作出勤工资 { get; set; }
        public decimal 未休年休假工资 { get; set; }
        public decimal 社保个人缴纳金额 { get; set; }
        public decimal 社保公司缴纳金额 { get; set; }
        public decimal 养老保险个人缴纳金额 { get; set; }
        public decimal 医疗保险个人缴纳金额 { get; set; }
        public decimal 失业保险个人缴纳金额 { get; set; }
        public decimal 住房公积金个人缴纳金额 { get; set; }
        public decimal 养老保险个人补缴金额 { get; set; }
        public decimal 医疗保险个人补缴金额 { get; set; }
        public decimal 失业保险个人补缴金额 { get; set; }
        public decimal 住房公积金个人补缴金额 { get; set; }        
        public decimal 大病医疗个人缴纳金额 { get; set; }
        public decimal 个人所得税金额 { get; set; }
        public decimal 代垫费用 { get; set; }
        public decimal 职级工资 { get; set; }
        public decimal 挂钩效益工资 { get; set; }
        public decimal 工资降级 { get; set; }
        public decimal 其他所得 { get; set; }
        public decimal 其他扣款 { get; set; }
        public decimal 预留风险金 { get; set; }
        public decimal 出勤工资 { get; set; }
        public decimal 满勤奖 { get; set; }
        public decimal 特殊社保的基准工资 { get; set; }
        public decimal 基数等级与基准工资差额 { get; set; }
        public decimal 上表工资 { get; set; }
        public decimal 设定工资 { get; set; }
        public decimal 基准工资 { get; set; }
        public decimal 应得满勤奖 { get; set; }
        public decimal 实得满勤奖 { get; set; }
        public decimal 津贴补助 { get; set; }
        public decimal 综合考核工资 { get; set; }
        public decimal 奖项 { get; set; }
        public decimal 扣项 { get; set; }
        public decimal 应税工资额 { get; set; }
        public decimal 合计应税工资额 { get; set; }
        public decimal 实发工资总额 { get; set; }
        public decimal 上表工资总额 { get; set; }
        public decimal 工资系数 { get; set; }
        public DateTime 上次同步时间 { get; set; }
        //2018-2-11 新增
        public decimal 交通餐饮补助 { get; set; }
        #region GetList

        //根据日历组获取所有工资项
        public static List<SalResult> GetList(string calRunId, string payGroup)
        {
            List<SalResult> list = new List<SalResult>();

            CalRunInfo calRun = CalRunInfo.Get(calRunId);
            if (calRun == null) return list;
            
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        string payGroupCondition = "";
                        if (string.IsNullOrEmpty(payGroup) == false) payGroupCondition = String.Format(" AND GP_PAYGROUP = '{0}'", payGroup);
                        cmd.CommandText = String.Format("SELECT B.NAME,A.* FROM SYSADM.PS_C_WA_PAY_RSLT A LEFT JOIN PS_PERSONAL_DATA B ON A.EMPLID=B.EMPLID WHERE CAL_RUN_ID='{0}' {1} ORDER BY A.EMPLID", calRunId, payGroupCondition);
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            SalResult item = new SalResult();

                            #region 日历信息

                            item.日历组 = calRunId;
                            item.期间 = calRun.期间;
                            item.年度 = calRun.年度;
                            item.月份 = calRun.月份;

                            #endregion

                            #region 员工信息

                            item.姓名 = MyHelper.RemoveNumber((string)rs["NAME"]);
                            item.员工编号 = (string)rs["EMPLID"];
                            item.员工类型 = (string)rs["C_CHR027"];

                            EmpInfo empInfo = EmpInfo.员工表.Find(a=>a.员工编号 == item.员工编号);
                            if (empInfo != null)
                            {
                                item.身份证号 = empInfo.身份证号;

                                item.财务公司 = empInfo.财务公司;
                                item.财务部门 = empInfo.财务部门;
                                item.财务部门序号 = empInfo.财务部门序号;
                                item.员工序号 = empInfo.员工序号;

                                item.银行账号 = empInfo.银行账号;
                                item.帐户名称 = empInfo.帐户名称;
                            }

                            #endregion
                            
                            #region 所属机构

                            item.公司编号 = (string)rs["COMPANY"];
                            item.机构编号 = (string)rs["DEPTID"];

                            CompanyInfo company = CompanyInfo.Get(item.公司编号);
                            if (company != null) item.公司名称 = company.公司名称;    

                            DeptInfo dept = DeptInfo.Get(item.机构编号);
                            if (dept != null && dept.所在部门 != null)
                            {
                                item.部门编号 = dept.所在部门.部门编号;
                                item.部门名称 = dept.所在部门.部门名称;
                            }

                            #endregion
                                                        
                            #region 薪酬体系

                            item.薪资组 = (string)rs["GP_PAYGROUP"];
                            item.薪资集合 = (string)rs["SETID_SALARY"];
                            item.薪酬体系编号 = (string)rs["SAL_ADMIN_PLAN"];
                            item.薪等编号 = (string)rs["GRADE"];
                            item.薪级编号 = Convert.ToString(rs["STEP"]);

                            #endregion

                            #region 职务数据

                            item.职务代码 = (string)rs["JOBCODE"];
                            //2018-9-10 职务等级以15号为界
                            //item.职务等级 = (string)rs["SUPV_LVL_ID"];
                            item.职务等级 = GetSupvLvlId(item.员工编号, item.年度, item.月份);

                            item.职位编号 = (string)rs["POSITION_NBR"];
                            item.班别 = (string)rs["SHIFT"];

                            #endregion

                            #region 出勤情况

                            item.企业排班天数 = Convert.ToDecimal(rs["C_AMT202"]);
                            item.法定工作日天数 = Convert.ToDecimal(rs["C_AMT243"]);
                            item.实际出勤天数 = Convert.ToDecimal(rs["C_AMT198"]);
                            item.法定工作日出勤天数 = Convert.ToDecimal(rs["C_AMT199"]);
                            item.法定节假日出勤天数 = Convert.ToDecimal(rs["C_AMT201"]);
                            item.休息日出勤天数 = Convert.ToDecimal(rs["C_AMT203"]);
                            item.月综合出勤天数 = Convert.ToDecimal(rs["C_AMT204"]);
                            item.工作日延长出勤小时数 = Convert.ToDecimal(rs["C_AMT205"]);

                            #endregion

                            #region 出勤工资

                            item.法定工作日出勤工资 = Convert.ToDecimal(rs["C_AMT005"]);
                            item.法定节假日出勤工资 = Convert.ToDecimal(rs["C_AMT006"]);
                            item.休息日出勤工资 = Convert.ToDecimal(rs["C_AMT007"]);
                            item.月综合出勤工资 = Convert.ToDecimal(rs["C_AMT009"]);
                            item.工作日延长工作出勤工资 = Convert.ToDecimal(rs["C_AMT010"]);

                            #endregion

                            item.未休年休假工资 = Convert.ToDecimal(rs["C_AMT134"]);

                            #region 社保缴纳

                            item.养老保险个人缴纳金额 = Convert.ToDecimal(rs["C_AMT170"]);
                            item.医疗保险个人缴纳金额 = Convert.ToDecimal(rs["C_AMT171"]);
                            item.失业保险个人缴纳金额 = Convert.ToDecimal(rs["C_AMT172"]);
                            item.住房公积金个人缴纳金额 = Convert.ToDecimal(rs["C_AMT173"]);
                            item.大病医疗个人缴纳金额 = Convert.ToDecimal(rs["C_AMT292"]);                            
                            //社保合计
                            item.社保个人缴纳金额 = Convert.ToDecimal(rs["C_AMT258"]);
                            item.社保公司缴纳金额 = Convert.ToDecimal(rs["C_AMT259"]);
                            //补缴 2015.9.14
                            item.养老保险个人补缴金额 = Convert.ToDecimal(rs["C_AMT174"]);
                            item.医疗保险个人补缴金额 = Convert.ToDecimal(rs["C_AMT175"]);
                            item.失业保险个人补缴金额 = Convert.ToDecimal(rs["C_AMT176"]);
                            item.住房公积金个人补缴金额 = Convert.ToDecimal(rs["C_AMT177"]);
                           
                            #endregion

                            item.个人所得税金额 = Convert.ToDecimal(rs["C_AMT178"]); //C_AMT265 总的个税（含封闭工资）
                            item.代垫费用 = Convert.ToDecimal(rs["C_AMT262"]);

                            item.挂钩效益工资 = Convert.ToDecimal(rs["C_AMT136"]);
                            item.其他所得 = Convert.ToDecimal(rs["C_AMT138"]);
                            item.其他扣款 = Convert.ToDecimal(rs["C_AMT196"]);
                            item.预留风险金 = Convert.ToDecimal(rs["C_AMT241"]);
                            item.出勤工资 = Convert.ToDecimal(rs["C_AMT252"]);
                            item.实得满勤奖 = Convert.ToDecimal(rs["C_AMT017"]);
                            item.应得满勤奖 = Convert.ToDecimal(rs["C_AMT232"]);
                            item.上表工资 = Convert.ToDecimal(rs["C_AMT002"]);
                            item.设定工资 = Convert.ToDecimal(rs["C_AMT003"]);
                            item.基准工资 = Convert.ToDecimal(rs["C_AMT004"]);
                            item.特殊社保的基准工资 = Convert.ToDecimal(rs["C_AMT278"]);
                            item.基数等级与基准工资差额 = Convert.ToDecimal(rs["C_AMT011"]);
                            //item.工资降级 = Convert.ToDecimal(rs["C_AMT008"]) - item.上表工资; //2015.5.20 封闭上表工资 - 上表工资
                            //2017.7.10 直接读取工资降级数据
                            item.工资降级 = PsHelper.GetPayDegrade(item.员工编号, calRun.开始日期);
                            if (item.工资降级 < 0) item.工资降级 = 0; //2015.9.24

                            #region 累加器

                            item.出勤工资 = Convert.ToDecimal(rs["C_AMT252"]);
                            item.津贴补助 = Convert.ToDecimal(rs["C_AMT253"]);
                            item.综合考核工资 = Convert.ToDecimal(rs["C_AMT254"]);
                            item.奖项 = Convert.ToDecimal(rs["C_AMT255"]);
                            item.扣项 = Convert.ToDecimal(rs["C_AMT256"]);

                            #endregion

                            item.交通餐饮补助 = Convert.ToDecimal(rs["C_AMT248"]); 

                            item.应税工资额 = Convert.ToDecimal(rs["C_AMT260"]);
                            //含年休假工资（260是不含年休假的工资总额）
                            //即：合计应税工资额 = 应税工资额 + 年休假工资
                            item.合计应税工资额 = Convert.ToDecimal(rs["C_AMT261"]);
                            item.上表工资总额 = Convert.ToDecimal(rs["C_AMT257"]);
                            item.实发工资总额 = Convert.ToDecimal(rs["C_AMT263"]);     
                            list.Add(item);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return list;
        }

        public static string GetSupvLvlId(string emplid, int year, int month)
        {
            DateTime period_begin = new DateTime(year, month, 1);
            DateTime period_begin_next_month = period_begin.AddMonths(1);
            string supvLvlId = PsHelper.GetEmployeeSupvLvl(emplid, year, month);
            //如果是本月15号后入职的，取下月15号前职务等级
            if (supvLvlId == null) supvLvlId = PsHelper.GetEmployeeSupvLvl(emplid, period_begin_next_month.Year, period_begin_next_month.Month);
            return supvLvlId;
        }

        #endregion
    }
}
