using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using YiKang.RBACS.DataObjects;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using Aspose.Cells;
using System.Data;


namespace Hwagain.SalaryCalculation
{
    public partial class MonthlySalaryForm : XtraForm
    {
        string 副总经理以上职等 = "董事长,副董事长,总裁,副总裁,总经理,副总经理";

        string salary_plan = null;
        string group = null;
        string company_code = null;
        JobGrade jobgrade;
        
        List<MonthlySalary> monthly_salary_list = new List<MonthlySalary>();
        
        public MonthlySalaryForm(string salary_plan, string group)
            : this()
        {
            this.salary_plan = salary_plan;
            this.group = group;
            //获取公司代码
            company_code = PsHelper.GetCompanyCode(salary_plan);
            //获取职等（默认自动为每个职等建立一个群组）
            jobgrade = JobGrade.GetJobGrade(salary_plan, group);  
        }

        public MonthlySalaryForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // TODO: Add any initialization after the InitializeComponent call
        }

        #region CreateWaitDialog

        WaitDialogForm dlg = null;
        public void CreateWaitDialog()
        {
            CreateWaitDialog("正在启动...", "请稍等");
        }
        public void CreateWaitDialog(string caption, string title, Size size)
        {
            CloseWaitDialog();
            dlg = new DevExpress.Utils.WaitDialogForm(caption, title, size);
        }
        public void CreateWaitDialog(string caption, string title)
        {
            CloseWaitDialog();
            dlg = new DevExpress.Utils.WaitDialogForm(caption, title);
        }
        public void SetWaitDialogCaption(string fCaption)
        {
            if (dlg != null)
                dlg.Caption = fCaption;
        }
        public void CloseWaitDialog()
        {
            if (dlg != null)
                dlg.Close();
        }
        #endregion

        #region 加载数据

        protected void LoadData()
        {
            CreateWaitDialog("正在查询...", "请稍等");

            List<EmployeeInfo> emp_list = GetEmployeeList();
            //排序
            emp_list = emp_list.OrderBy(a => a.部门序号).ThenBy(a => a.员工序号).ToList();

            List<MonthlySalary> monthly_salary_list = new List<MonthlySalary>(); 

            foreach (EmployeeInfo emp in emp_list)
            {
                //获取员工的执行月薪记录
                MonthlySalary ms = MonthlySalary.GetEffective(emp.员工编号, DateTime.Today);
                //如果没有找到，构造一个空的实例
                if (ms == null)
                {
                    ms = new MonthlySalary();
                    ms.员工编号 = emp.员工编号;
                }
                monthly_salary_list.Add(ms);
            }
            //排序
            monthly_salary_list = monthly_salary_list.OrderByDescending(a => a.执行_月薪).ToList();
            int order = 1;
            foreach (MonthlySalary item in monthly_salary_list)
            {
                item.序号 = order++;
                if (jobgrade == null) item.执行_月薪类型 = "特资";
            }

            SetWaitDialogCaption("正在加载...");            

            CloseWaitDialog();
            gridControl1.DataSource = monthly_salary_list;
            gridControl1.RefreshDataSource();

            btn导出.Enabled = true;

            CloseWaitDialog();
        }        

        #endregion       

        #region 获取员工名单

        List<EmployeeInfo> GetEmployeeList()
        {
            //上月期间开始
            DateTime date = SalaryResult.GetLastSalaryDate(group);

            //2018-7-11 获取软件开发人员
            List<EmployeeInfo> developer_list = new List<EmployeeInfo>();
            List<string> names = Developer.GetDeveloperList();
            foreach (string name in names)
            {
                EmployeeInfo emp = EmployeeInfo.GetEmployeeInfoByName(name);
                if (emp != null) developer_list.Add(emp);
            }

            List<EmployeeInfo> emp_list = new List<EmployeeInfo>();
            if (jobgrade != null)
            {
                if (salary_plan == "软件开发")
                {
                    emp_list = developer_list;
                }
                else
                {
                    //先将在职员工信息加载到内存
                    EmployeeInfo.GetEmployeeList(company_code, group, true);
                    //获取上月工资表中的人员名单
                    emp_list = SalaryResult.GetEmployeeList(date.Year, date.Month, company_code, group, true);

                    //剔除软件开发人员
                    foreach (EmployeeInfo emp in developer_list)
                        emp_list.RemoveAll(a => a.员工编号 == emp.员工编号);
                }
            }
            else
            {
                if (group == "管培生")
                {
                    //先将在职员工信息加载到内存
                    EmployeeInfo.GetEmployeeList(company_code, null, true);
                    //获取上月工资表中的人员名单
                    emp_list = SalaryResult.GetEmployeeList(date.Year, date.Month, company_code, null, true);
                    //移除非管培生
                    emp_list.RemoveAll(a => a.是管培生 == false);
                }
                else
                {
                    string[] grade_list = null;
                    if (group == "副总经理以上") grade_list = 副总经理以上职等.Split(new char[] { ',' });
                    if (grade_list != null)
                    {
                        for (int i = 0; i < grade_list.Length; i++)
                        {
                            //先将在职员工信息加载到内存
                            EmployeeInfo.GetEmployeeList(company_code, group, true);
                            //获取上月工资表中的人员名单
                            List<EmployeeInfo> emps = SalaryResult.GetEmployeeList(date.Year, date.Month, company_code, grade_list[i], true);
                            emp_list.AddRange(emps);
                        }
                    }
                }
                //剔除软件开发人员
                foreach (EmployeeInfo emp in developer_list)
                    emp_list.RemoveAll(a => a.员工编号 == emp.员工编号);
            }
            //如果不是管培生组，剔除管培生
            if (group != "管培生") emp_list.RemoveAll(a => a.是管培生);

            return emp_list;
        }

        #endregion

        private void btn导出_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = lbl标题.Text;

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                XlsExportOptions options = new XlsExportOptions();
                options.RawDataMode = false;
                advBandedGridView1.ExportToXls(filename, options);

                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(filename);
                Worksheet sheet = workbook.Worksheets[0];
                sheet.AutoFitColumns();
                workbook.Save(filename);
            }
        }

        private void MonthlySalaryForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = group + "【薪酬执行】明细表";
            LoadData();
        }

        private void MonthlySalaryForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null) this.Owner.Hide();
        }

        private void MonthlySalaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }
    }
}

