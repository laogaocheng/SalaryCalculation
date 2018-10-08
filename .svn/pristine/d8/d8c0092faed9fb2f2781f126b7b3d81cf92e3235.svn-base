using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using log4net;
using DevExpress.Data.Filtering;
using System.Data.SqlClient;
using Hwagain;
using YiKang;
using System.Data.OleDb;
using System.Reflection;
using System.ComponentModel;

namespace Hwagain.SalaryCalculation.Components
{
    //调整职等
    public partial class AdjustJobGrade
    {
        static readonly ILog log = LogManager.GetLogger(typeof(AdjustJobGrade));

        bool is_verify = false; //是否验证录入
        internal JobGrade jobGrade;
        SemiannualType semiannual;
        GradeSalaryAdjust gsa;
        List<RankSalaryStandardInput> rss_list = new List<RankSalaryStandardInput>();
        int year = 0;
        int period = 0;

        public AdjustJobGrade(string rankNames)
        {
            is_separator = true;
            string[] names = rankNames.Split(new char[] { ':' });
            for (int i = 0; i < names.Length; i++)
            {
                //赋值
                string propertyName = "R" + (i + 1).ToString();
                PropertyInfo property = this.GetType().GetProperty(propertyName);
                if (property != null) property.SetValue(this, names[i], null);
            }
        }
        public AdjustJobGrade(JobGrade grade, int year, SemiannualType semiannual, bool isVerify)
        {
            is_separator = false;
            
            this.jobGrade = grade;
            this.year = year;
            this.semiannual = semiannual;
            this.is_verify = isVerify;

            this.period = year * 10 + (byte)semiannual;

            LoadData();
        }

        public void Refresh()
        {
            LoadData();
        }

        void LoadData()
        {
            //分隔行没有数据
            if (is_separator) return;

            薪酬体系 = jobGrade.薪酬体系;
            名称 = jobGrade.名称;
            期号 = period;
            职等 = jobGrade;

            RankNames = "";
            标识 = jobGrade.标识;

            rss_list.Clear();

            List<JobRank> jobranks = JobRank.GetJobRanks(jobGrade.标识);
            foreach (JobRank rank in jobranks)
            {
                //本期标准
                RankSalaryStandardInput rss = RankSalaryStandardInput.AddRankSalaryStandardInput(jobGrade.薪酬体系, jobGrade.名称, rank.名称, period, rank.序号, is_verify);
                rss_list.Add(rss);
                开始执行日期 = rss.开始执行日期;
                //赋值
                string propertyName = "R" + rss.序号;
                string monthlySalary = rss.月薪.ToString();
                PropertyInfo property = this.GetType().GetProperty(propertyName);
                if (property != null) property.SetValue(this, monthlySalary, null);

                if (RankNames != "") RankNames += ":";
                RankNames += rank.名称;
            }

            int t = is_verify ? 2 : 1; //统计表类型：0： 正式, 1: 初次录入, 2: 验证录入
            gsa = GradeSalaryAdjust.GetGradeSalaryAdjust(jobGrade.薪酬体系, jobGrade.名称, period, t);
            if (gsa == null)
            {
                gsa = GradeSalaryAdjust.AddGradeSalaryAdjust(jobGrade.薪酬体系, jobGrade.名称, period, t);
                gsa.Calculate();
            }

            SetFieldValue();
        }
        //获取属性值
        public object GetPropertyValue(string propertyName)
        {
            PropertyInfo property = this.GetType().GetProperty(propertyName);
            if (property == null) return null;
            return property.GetValue(this, null);
        }

        public void SetFieldValue()
        {
            if (gsa == null) return;

            职等数 = gsa.职等数.ToString();
            级差 = gsa.级差.ToString();
            平均工资 = gsa.平均工资.ToString();
            最低工资 = gsa.最低工资;
            最高工资 = gsa.最高工资;
            对比的职等 = gsa.对比的职等;
            调整金额 = gsa.半年调资额;

            if (gsa.年调率 > 0)
            {
                半年调资额 = gsa.半年调资额.ToString();
                年调 = gsa.每年调资额.ToString();

                半年调率 = (gsa.年调率 * 100 / 1.5).ToString("#0.#") + "%";
                年调率 = (gsa.年调率 * 100).ToString("#0.#") + "%";
            }
            if (gsa.年调率 == 1) 年调率 = "";
            if (!string.IsNullOrEmpty(对比的职等)) 职等差 = gsa.职等差.ToString();
            if (gsa.上期调整 != null) 上期级别平均 = gsa.上期调整.平均工资.ToString();
        }

        public static List<AdjustJobGrade> GetAdjustJobGradeList(string salary_plan, int year, SemiannualType semiannual, bool insert_separator, bool isVerify)
        {
            List<AdjustJobGrade> gradeList = new List<AdjustJobGrade>();

            int period = year * 10 + (byte)semiannual;
            List<RankSalaryStandardInput> rss_list = RankSalaryStandardInput.GetRankSalaryStandardInputs(salary_plan, null, period, isVerify);
            List<JobGrade> jobGrades = JobGrade.GetJobGrades(salary_plan);
            foreach (JobGrade grade in jobGrades)
            {
                AdjustJobGrade snGrade = new AdjustJobGrade(grade, year, semiannual, isVerify);
                gradeList.Add(snGrade);
            }

            string prev_line_ranknames = ""; //上一行职级名称列表
            List<AdjustJobGrade> grades_result = new List<AdjustJobGrade>();
            //遍历
            foreach (AdjustJobGrade sgrade in gradeList)
            {
                if (sgrade.RankNames != "")
                {
                    //如果职级划分不同，插入一行分割数据
                    if (prev_line_ranknames != sgrade.RankNames)
                    {
                        if (prev_line_ranknames != "")
                            grades_result.Add(new AdjustJobGrade(sgrade.RankNames));

                        prev_line_ranknames = sgrade.RankNames;
                    }
                }
                grades_result.Add(sgrade);                
            }
            return grades_result;
        }

        #region CompareInputContent
        //比较录入的内容
        public void CompareInputContent()
        {
            contentDifferentFields = null;
            GetModifiyFields();
        }
        #endregion

        #region GetModifiyFields

        public void GetModifiyFields()
        {
            if (contentDifferentFields == null)
            {
                contentDifferentFields = new List<ModifyField>();

                if (另一人录入的记录 != null)
                {
                    contentDifferentFields = MyHelper.GetModifyFields(this, 另一人录入的记录);
                }

            }
        }
        #endregion

        #region 职级工资表

        public List<RankSalaryStandardInput> 职级工资表
        {
            get
            {
                return rss_list;
            }
        }

        #endregion

        #region 调整记录

        public GradeSalaryAdjust 调整记录
        {
            get { return gsa; }
        }

        #endregion

        #region 另一人录入的记录

        AdjustJobGrade anotherInput = null;
        [Browsable(false)]
        public AdjustJobGrade 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {                    
                    anotherInput = new AdjustJobGrade(jobGrade, year, semiannual, !is_verify);
                }
                return anotherInput;
            }
        }
        #endregion

        [WatchMember]
        public DateTime 开始执行日期 { get; set; }
        public string 薪酬体系 { get; set; }
        public int 期号 { get; set; }
        [WatchMember]
        public int 调整金额 { get; set; }
        [WatchMember]
        public string 职等数 { get; set; }
        [WatchMember]
        public string 级差 { get; set; }
        public string 半年调资额 { get; set; }
        public string 年调 { get; set; }
        public string 半年调率 { get; set; }
        public string 年调率 { get; set; }
        public string 平均工资 { get; set; }
        public string 职等差 { get; set; }
        [WatchMember]
        public string 对比的职等 { get; set; }
        public string 上期级别平均 { get; set; }        
        [WatchMember]
        public string R1 { get; set; }
        [WatchMember]
        public string R2 { get; set; }
        [WatchMember]
        public string R3 { get; set; }
        [WatchMember]
        public string R4 { get; set; }
        [WatchMember]
        public string R5 { get; set; }
        [WatchMember]
        public string R6 { get; set; }
        [WatchMember]
        public string R7 { get; set; }
        [WatchMember]
        public string R8 { get; set; }
        [WatchMember]
        public string R9 { get; set; }
        [WatchMember]
        public string R10 { get; set; }
        [WatchMember]
        public string R11 { get; set; }
        [WatchMember]
        public string R12 { get; set; }
        [WatchMember]
        public string R13 { get; set; }
        [WatchMember]
        public string R14 { get; set; }
        [WatchMember]
        public string R15 { get; set; }
        [WatchMember]
        public string R16 { get; set; }
        [WatchMember]
        public string R17 { get; set; }
        [WatchMember]
        public string R18 { get; set; }
        [WatchMember]
        public string R19 { get; set; }
        [WatchMember]
        public string R20 { get; set; }

        public string RankNames { get; set; }
        public int 最低工资 { get; set; }
        public int 最高工资 { get; set; }
        public Guid 标识 { get; set; }
        public string 名称 { get; set; }

        public JobGrade 职等 { get; set; }
        public bool is_separator{ get; set; } //分隔器，非数据容器，用于分割不同职级方案，只显示职级名称

        #region 内容不同的字段

        List<ModifyField> contentDifferentFields = null;
        [Browsable(false)]
        public List<ModifyField> 内容不同的字段
        {
            get
            {
                if (contentDifferentFields == null) GetModifiyFields();
                return contentDifferentFields;
            }
        }

        #endregion
    }
}