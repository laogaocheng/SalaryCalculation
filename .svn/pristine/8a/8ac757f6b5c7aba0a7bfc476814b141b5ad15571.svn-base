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
    public partial class TraineeSalaryStandardInputForm : XtraForm
    {        
        protected bool isCheck = false; //是否验证录入

        int year = DateTime.Today.Year;
        ManagementTraineeInfo trainee; //管培生信息
        ManagementTraineePayStandard prevStandard = null; //上期标准

        List<ManagementTraineePayStandardInput> trainee_salary_list = new List<ManagementTraineePayStandardInput>();
        List<ManagementTraineePayStandardInput> trainee_salary_list_opposite = new List<ManagementTraineePayStandardInput>();

        bool showDifferent = false;

        public TraineeSalaryStandardInputForm(ManagementTraineeInfo trainee, bool isCheck)
            : this()
        {
            this.trainee = trainee;
            this.isCheck = isCheck;            

            prevStandard = ManagementTraineePayStandard.GetLatestBeforeOneday(trainee.员工编号, new DateTime(year, 7, 1));

            if (prevStandard == null)
            {
                MessageBox.Show("错误：找不到上期年薪");
                this.Close();
            }
        }

        public TraineeSalaryStandardInputForm()
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

        #region 创建编辑记录

        List<ManagementTraineePayStandardInput> CreateEditingRows()
        {
            List<ManagementTraineePayStandardInput> list = new List<ManagementTraineePayStandardInput>();

            int 提资序数 = prevStandard.提资序数 + 1;
            ManagementTraineePayStandard first = ManagementTraineePayStandard.CreateFirstStandard(trainee.员工编号);

            for (int i = 0; i < 4; i++)
            {
                int 年度 = i >= 2 ? year + 1 : year;
                DateTime 年度开始 = new DateTime(年度, 1, 1);
                int 季度 = (i + 2) % 4 + 1;

                int m = 年度 - first.年份;
                int n = 季度 - first.季度;
                int q = m * 4 + n; //距离起薪季度数

                string type = trainee.岗位级别 == "一级" ? trainee.岗位类型 : trainee.专业属性;
                //升阶（满足升阶条件，先升阶，每阶+100, 满阶是 10000）
                double step = ManagementTraineePayStandard.GetStep(trainee.届别, trainee.岗位级别, type, q);
                if (step == 0) 提资序数 = 10000;
                if (step == 2) 提资序数 = 100;

                ManagementTraineePayStandardInput item = ManagementTraineePayStandardInput.AddManagementTraineePayStandardInput(trainee.员工编号, 年度, 季度, i + 1, 提资序数, isCheck);
                list.Add(item);

                提资序数++;
            }

            return list;
        }

        #endregion

        #region 加载数据

        protected void LoadData(bool compare)
        {
            bool isSameEditor = false;

            CreateWaitDialog("正在查询...", "请稍等");

            trainee_salary_list = ManagementTraineePayStandardInput.GetEditingRows(trainee.员工编号, year, isCheck);
            //如果没有记录，自动创建
            if (trainee_salary_list.Count == 0) trainee_salary_list = CreateEditingRows();

            //如果比较
            if (compare) trainee_salary_list_opposite = ManagementTraineePayStandardInput.GetEditingRows(trainee.员工编号, year, !isCheck);
            
            SetWaitDialogCaption("正在加载...");            
            
            if (isSameEditor)
            {
                CloseWaitDialog();

                MessageBox.Show("两次录入不能是同一个人");
                this.Close();
            }

            gridControl1.DataSource = trainee_salary_list;
            gridControl1.Refresh();

            CloseWaitDialog();

            showDifferent = compare;            
        }        

        #endregion       

        private void AdjustMonthlySalaryForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = "定职人员提资标准录入录入";
            lbl姓名.Text = "姓名：" + trainee.姓名;
            lbl上期年薪.Text = "上期年薪：" + (prevStandard.年薪 * 10000).ToString("#0.##") + " 元";
            LoadData(false);
        }

        private void advBandedGridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            
        }

        #region btn保存提交_Click

        private void btn保存提交_Click(object sender, EventArgs e)
        {
            bool isSameEditor = false;

            CreateWaitDialog("正在准备保存...", "请稍等");
            try
            {
                //检查是否所有职等都录入完成
                foreach (ManagementTraineePayStandardInput item in trainee_salary_list)
                {
                    if (item.年薪 == 0)
                    {
                        MessageBox.Show("错误：年薪不能为空");
                        return;
                    }
                }                

                int order = 1;
                foreach (ManagementTraineePayStandardInput item in trainee_salary_list)
                {
                    if (item.另一人录入的记录 != null)
                    {
                        string editor = AccessController.CurrentUser.姓名;
                        string editor_opposite = item.另一人录入的记录.录入人.Trim();
                        if (editor == editor_opposite && editor_opposite != "")
                        {
                            isSameEditor = true;
                            break;
                        }
                    }
                    item.序号 = order++;
                    item.录入人 = AccessController.CurrentUser.姓名;
                    item.录入时间 = DateTime.Now;
                    item.Save();
                }

                if (isSameEditor)
                {
                    CloseWaitDialog();

                    MessageBox.Show("提交失败：两次录入不能是同一个人");
                    return;
                }

                foreach (ManagementTraineePayStandardInput item in trainee_salary_list)
                {
                    //手动比较录入的内容
                    item.CompareInputContent();
                }

                SetWaitDialogCaption("正在比较双人录入是否一致...");

                LoadData(true);
                //检查差异
                bool all_same = true;
                foreach (ManagementTraineePayStandardInput ms in trainee_salary_list)
                {
                    if (!ms.另一人已录入 || ms.内容不同的字段.Count > 0)
                    {
                        all_same = false;
                        break;
                    }
                }
                if (all_same)
                {
                    //转成正式
                    foreach (ManagementTraineePayStandardInput ms in trainee_salary_list)
                    {
                        ms.UpdateToFormalTable();
                    }
                    MessageBox.Show("双人录入成功");
                }
                else
                {
                    //显示差异
                    gridControl1.DataSource = trainee_salary_list;
                    gridControl1.Refresh();
                    MessageBox.Show("提交失败：红色项目不一致，请重新核对修改");
                }
                gridControl1.Focus();
                this.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                CloseWaitDialog();
            }
        }
        
        #endregion

        #region gridView1_CustomDrawCell

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (showDifferent == false) return;

            e.Appearance.ForeColor = Color.Black;
            e.Appearance.BackColor = Color.Transparent;

            ManagementTraineePayStandardInput row = advBandedGridView1.GetRow(e.RowHandle) as ManagementTraineePayStandardInput;
            if (row != null)
            {
                foreach (ModifyField field in row.内容不同的字段)
                {
                    if (field.名称 == e.Column.FieldName && field.名称 == "年薪")
                    {
                        e.Appearance.ForeColor = Color.Yellow;
                        e.Appearance.BackColor = Color.Red;
                    }
                }
            }
        }
        #endregion

        #region advBandedGridView1_CellValueChanged

        private void advBandedGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ManagementTraineePayStandardInput row = advBandedGridView1.GetRow(e.RowHandle) as ManagementTraineePayStandardInput;
            if (row != null)
            {
                decimal prevYearSalary = 0; //上期年薪
                if (e.RowHandle == 0)
                    prevYearSalary = prevStandard.年薪;
                else
                {
                    ManagementTraineePayStandardInput prev = trainee_salary_list[e.RowHandle - 1];
                    if (prev != null) prevYearSalary = prev.年薪;
                }

                if (e.Column.FieldName == "年薪" && prevYearSalary > 0)
                {                    
                    //重算后面的增幅
                    for (int i = e.RowHandle; i < trainee_salary_list.Count; i++)
                    {
                        if (i > e.RowHandle + 1) break; //只需要更新当前记录和后面一条记录
                        
                        ManagementTraineePayStandardInput item = trainee_salary_list[i];
                        if (i > e.RowHandle && item.年薪 == 0) break; //后面的记录如果还没有录入

                        decimal year_salary = item.年薪;
                        decimal rise_rate = 100 * ((decimal)(year_salary - prevYearSalary) / prevYearSalary);
                        rise_rate = Math.Round(rise_rate, 1);
                        decimal month_salary = Convert.ToInt32((year_salary * (decimal)10000.0) / (decimal)12.0);

                        item.增幅 = rise_rate;
                        item.月薪 = Convert.ToInt32(month_salary);
                        item.Save();

                        prevYearSalary = year_salary;
                    }
                    gridControl1.RefreshDataSource();
                    gridControl1.Refresh();
                }
            }
        }

        #endregion

        private void AdjustMonthlySalaryForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null) this.Owner.Hide();
        }

        private void AdjustMonthlySalaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        private void btn返回目录_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn查漏_Click(object sender, EventArgs e)
        {
            CreateEditingRows();
            LoadData(false);
        }

        private void advBandedGridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "增幅")
            {
                decimal rise_rate = Convert.ToDecimal(e.Value);
                if (rise_rate != 0) e.DisplayText = rise_rate.ToString("0.#") + "%";
            }
        }
    }

}

