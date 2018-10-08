using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
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

namespace Hwagain.SalaryCalculation
{
    public partial class SalaryStructureListForm : XtraForm
    {
        string 副总经理以上职等 = "董事长,副董事长,总裁,副总裁,总经理,副总经理";

        string salary_plan = null;
        string group = null;
        string company_code = null;
        JobGrade jobgrade;

        List<EmployeeSalaryStructure> all_rows = new List<EmployeeSalaryStructure>();   //所有记录
        public SalaryStructureListForm(string salary_plan, string group)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            this.salary_plan = salary_plan;
            this.group = group;
            //获取公司代码
            company_code = PsHelper.GetCompanyCode(salary_plan);
            //获取职等（默认自动为每个职等建立一个群组）
            jobgrade = JobGrade.GetJobGrade(salary_plan, group);
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

        private void EditSalaryStructureForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = group + "【薪酬结构】明细表";
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            bool 有年休假工资 = false, 有交通餐饮补贴 = false;
            bool 有绩效工资 = false, 有工资借款 = false, 有报账工资 = false, 有福利借款 = false, 有契约津贴 = false;
            CreateWaitDialog("正在查询...", "请稍等");

            List<EmployeeInfo> emp_list = GetEmployeeList();
            //排序
            emp_list = emp_list.OrderBy(a => a.部门序号).ThenBy(a => a.员工序号).ToList();

            List<EmployeeSalaryStructure> monthly_salary_list = new List<EmployeeSalaryStructure>();

            foreach (EmployeeInfo emp in emp_list)
            {
                //获取员工的执行月薪记录
                EmployeeSalaryStructure ss = new EmployeeSalaryStructure(emp);
                if (ss.月薪项目_减项_绩效工资 != 0) 有绩效工资 = true;
                if (ss.月薪项目_减项_工资借款 != 0) 有工资借款 = true;
                if (ss.月薪项目_减项_报账工资 != 0) 有报账工资 = true;
                if (ss.月薪项目_减项_福利借款 != 0) 有福利借款 = true;
                if (ss.月薪项目_减项_契约津贴 != 0) 有契约津贴 = true;
                if (ss.月薪项目_年休假 != 0) 有年休假工资 = true;
                if (ss.月薪项目_交通餐饮补贴 != 0) 有交通餐饮补贴 = true;
                monthly_salary_list.Add(ss);
            }

            //排序
            monthly_salary_list = monthly_salary_list.OrderByDescending(a => a.年薪_合计).ToList();
            int order = 1;
            foreach (EmployeeSalaryStructure item in monthly_salary_list)
            {
                item.序号 = order++;
            }

            SetWaitDialogCaption("正在加载...");

            CloseWaitDialog();
            gridControl1.DataSource = monthly_salary_list;
            gridControl1.RefreshDataSource();

            btn导出.Enabled = true;

            CloseWaitDialog();

            if (!有年休假工资) gridBand年休假.Visible = false;
            if (!有交通餐饮补贴) gridBand交通餐饮补贴.Visible = false;
            //设置减项栏是否显示
            if (!有绩效工资) gridBand绩效工资.Visible = false;
            if (!有工资借款) gridBand工资借款.Visible = false;
            if (!有报账工资) gridBand报账工资.Visible = false;
            if (!有福利借款) gridBand福利借款.Visible = false;
            if (!有契约津贴) gridBand契约津贴.Visible = false;

            if(!有绩效工资 && !有工资借款 && !有报账工资 && !有福利借款 && !有契约津贴)
                gridBand月薪酬减项.Visible = false;
        }

        #endregion

        #region 获取员工名单

        List<EmployeeInfo> GetEmployeeList()
        {
            //上月期间开始
            DateTime date = SalaryResult.GetLastSalaryDate(group);

            List<EmployeeInfo> emp_list = new List<EmployeeInfo>();
            if (jobgrade != null)
            {
                //先将在职员工信息加载到内存
                EmployeeInfo.GetEmployeeList(company_code, group, true);
                //获取上月工资表中的人员名单
                emp_list = SalaryResult.GetEmployeeList(date.Year, date.Month, company_code, group, true);
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
            }
            //如果不是管培生组，剔除管培生
            if (group != "管培生") emp_list.RemoveAll(a => a.是管培生);
            return emp_list;
        }

        #endregion

        #region bandedGridView1_InvalidRowException

        private void bandedGridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.ThrowException;
        }
        #endregion

        #region bandedGridView1_CellValueChanged

        private void bandedGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            
        }
        #endregion

        #region bandedGridView1_CustomDrawCell

        private void bandedGridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            
        }
        #endregion

        #region bandedGridView1_FocusedRowChanged

        private void bandedGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SalaryStructure row = bandedGridView1.GetRow(e.PrevFocusedRowHandle) as SalaryStructure;
            if (row != null)
            {
            }
        }
        #endregion

        #region bandedGridView1_CellValueChanging

        private void bandedGridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            SalaryStructure row = bandedGridView1.GetRow(e.RowHandle) as SalaryStructure;

            if (row != null)
            {
                
            }
        }
        #endregion

        #region ProcessCmdKey

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                BaseEdit editor = bandedGridView1.ActiveEditor;
                if (editor != null && string.IsNullOrEmpty(editor.ErrorText) == false)
                {
                    editor.EditValue = editor.OldEditValue;
                    return true;
                }
                else
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region bandedGridView1_CustomRowCellEditForEditing

        private void bandedGridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {            
        }

        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            BaseEdit editor = bandedGridView1.ActiveEditor as BaseEdit;
        }
        #endregion

        #region bandedGridView1_DoubleClick

        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            ShowDetailItems();
        }
        #endregion

        #region bandedGridView1_RowCellClick

        private void bandedGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Caption == "查看明细") ShowDetailItems();
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
                bandedGridView1.ExportToXls(filename, options);

                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(filename);
                Worksheet sheet = workbook.Worksheets[0];
                sheet.AutoFitColumns();
                workbook.Save(filename);
            }
        }
        private void SalaryStructureListForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null) this.Owner.Hide();
        }

        private void SalaryStructureListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        private void ShowDetailItems()
        {
            MessageBox.Show("薪酬结构历史明细表开发中...");
            //RembursementSalary item = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle) as RembursementSalary;
            //if (item != null)
            //{
            //    MyRembursementSalaryListForm form = new MyRembursementSalaryListForm(item);
            //    form.ShowDialog();
            //}
        }

        private void bandedGridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }
    }

}

