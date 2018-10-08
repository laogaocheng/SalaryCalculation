﻿using System;
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
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;


namespace Hwagain.SalaryCalculation
{
    public partial class AdjustGradeSalaryStandardByIncreaseForm : XtraForm
    {
        protected bool isCheck = false; //是否验证录入
        
        string salary_plan = null;
        int year;
        SemiannualType sntype;
        List<AdjustJobGrade> grade_list = new List<AdjustJobGrade>();
        List<AdjustJobGrade> grade_list_opposite = new List<AdjustJobGrade>();        
        bool showDifferent = false;

        public AdjustGradeSalaryStandardByIncreaseForm(string salary_plan, int year, SemiannualType st, bool isCheck)
            : this()
        {
            this.salary_plan = salary_plan;
            this.year = year;
            this.sntype = st;
            this.isCheck = isCheck;
        }

        public AdjustGradeSalaryStandardByIncreaseForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void AdjustGradeSalaryStandardByIncreaseForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = year + sntype.ToString() + "职级及职级工资录入";

            LoadData(false);

            this.WindowState = FormWindowState.Maximized;
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

        protected void LoadData(bool compare)
        {            
            CreateWaitDialog("正在查询职级信息...", "请稍等");

            //如果比较
            if (compare) grade_list_opposite = AdjustJobGrade.GetAdjustJobGradeList(salary_plan, year, sntype, false, !isCheck);
            grade_list = AdjustJobGrade.GetAdjustJobGradeList(salary_plan, year, sntype, true, isCheck);
            //初始化
            foreach(AdjustJobGrade item in grade_list)
            {
                if (item.平均工资 == "0") UpdateRankSalary(item);
            }

            SetWaitDialogCaption("正在加载数据...");
            
            gridControl1.DataSource = grade_list;
            SetMonthlySalaryColumnInfo();

            showDifferent = compare;

            CloseWaitDialog();
        }

        #endregion

        #region SetMonthlySalaryColumnInfo
        //设置月薪字段的表头名称
        void SetMonthlySalaryColumnInfo()
        {
            for (int i = 1; i <= 20; i++)
            {
                string fieldName = "R" + i;
                //获取第 i 列对象
                GridColumn col = gridView1.Columns[fieldName];
                //查找第 i 列值不为空的记录
                AdjustJobGrade ag = grade_list.Find(a => a.GetPropertyValue(fieldName) != null);

                if (ag != null)
                {
                    col.Caption = "　";
                    RankSalaryStandardInput rss = grade_list[0].职级工资表.Find(a => a.序号 == i);
                    if (rss != null)
                    {
                        col.Caption = rss.职级;
                        //设置开始执行日期
                        date开始执行日期.DateTime = rss.开始执行日期;
                    }
                    col.Visible = true;
                    col.Width = 50;
                    col.OptionsColumn.AllowEdit = false;
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                else
                    col.Visible = false;
            }
        }
        #endregion

        private void btn返回上一层_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn职级及工资录入_Click(object sender, EventArgs e)
        {
            EditGradeSalaryStandard();
        }

        private void EditGradeSalaryStandard()
        {
            AdjustJobGrade row = gridView1.GetRow(gridView1.FocusedRowHandle) as AdjustJobGrade;
            if (row != null && row.is_separator == false)
            {
                EditGradeSalaryStandardForm form = new EditGradeSalaryStandardForm(row, isCheck);
                form.OnFinished += form_OnFinished;
                form.ShowDialog();
            }
        }

        private void form_OnFinished(AdjustJobGrade grade, GradeSalaryAdjust gsa, List<RankSalaryStandardInput> rss_input)
        {
            int focusRowHandle = gridView1.FocusedRowHandle;

            LoadData(false);

            gridView1.FocusedRowHandle = focusRowHandle;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //EditGradeSalaryStandard();
        }

        private void btn保存提交_Click(object sender, EventArgs e)
        {
            bool isSameEditor = false;

            if (grade_list.Count > 0 && grade_list[0].职级工资表 != null)
            {
                if (grade_list[0].职级工资表.Count > 0)
                {
                    RankSalaryStandardInput rss_1 = grade_list[0].职级工资表[0];
                    string editor = rss_1.录入人;
                    string editor_opposite = rss_1.另一人录入的记录 != null ? rss_1.另一人录入的记录.录入人.Trim() : "";
                    if (AccessController.CurrentUser.姓名 == editor_opposite && editor_opposite != "")
                    {
                        isSameEditor = true;
                    }
                }
            }

            if (isSameEditor)
            {                
                MessageBox.Show("两次录入不能是同一个人");
                return;
            }

            date开始执行日期.ForeColor = Color.Black;
            date开始执行日期.BackColor = Color.Transparent;

            DateTime lastSalaryDate = SalaryResult.GetLastSalaryDate();

            if (date开始执行日期.DateTime < lastSalaryDate)
            {
                MessageBox.Show("提交失败：开始执行日期不正确，不能小于 " + lastSalaryDate.ToString("yyyy年M月d日"));
                return;
            }

            CreateWaitDialog("正在准备保存...", "请稍等");
            try
            {
                //保存执行日期
                foreach (AdjustJobGrade grade in grade_list)
                {
                    if (grade.职级工资表 == null) continue;
                    foreach (RankSalaryStandardInput rss in grade.职级工资表)
                    {
                        rss.开始执行日期 = date开始执行日期.DateTime;
                        rss.录入人 = AccessController.CurrentUser.姓名;
                        rss.录入时间 = DateTime.Now;
                        rss.Save();
                    }
                }

                //检查是否所有职等都录入完成
                foreach (AdjustJobGrade grade in grade_list)
                {
                    if (grade.is_separator) continue;

                    if (grade.职级工资表 == null || grade.职级工资表.Count == 0)
                    {
                        MessageBox.Show("提交失败：职级工资未录入完成");
                        return;
                    }
                    foreach (RankSalaryStandardInput rss in grade.职级工资表)
                    {
                        if (rss.月薪 == 0)
                        {
                            MessageBox.Show("提交失败：月薪不能为 0");
                            return;
                        }
                    }
                }
                //如果另一个人没有录入，返回
                RankSalaryStandardInput rss_1 = grade_list[0].职级工资表[0];
                if (rss_1.另一人录入的记录 == null)
                {
                    CloseWaitDialog();
                    MessageBox.Show("提交失败：另一个人还没有录入");
                    return;
                }

                SetWaitDialogCaption("正在比较双人录入是否一致...");
                
                LoadData(true);
                //检查差异
                bool all_same = true;
                bool startdate_err = false;
                foreach (AdjustJobGrade grade in grade_list)
                {
                    if (grade.is_separator) continue; //忽略分割行
                    
                    //手动比较录入的内容
                    grade.CompareInputContent();

                    if (grade.内容不同的字段.Count > 0)
                    {
                        foreach(ModifyField field in grade.内容不同的字段)
                        {
                            if (field.名称.StartsWith("R")) continue;
                            if (field.名称 == "开始执行日期") startdate_err = true;
                            all_same = false;
                        }
                        break;
                    }
                }
                if (all_same)
                {
                    date开始执行日期.ForeColor = Color.Black;
                    date开始执行日期.BackColor = Color.Transparent;
                    //转成正式
                    foreach (AdjustJobGrade grade in grade_list)
                    {
                        if (grade.is_separator) continue; //忽略分割行
                        if (grade.职级工资表 == null) continue;
                        foreach (RankSalaryStandardInput rss in grade.职级工资表)
                        {
                            rss.UpdateToFormalTable();
                        }
                        grade.调整记录.UpdateToFormalRecord();
                    }
                    CloseWaitDialog();
                    MessageBox.Show("双人录入成功");
                }
                else
                {
                    //显示差异
                    gridControl1.RefreshDataSource();
                    gridControl1.Refresh();
                    //设置开始执行日期颜色
                    if(startdate_err)
                    {
                        date开始执行日期.ForeColor = Color.Yellow;
                        date开始执行日期.BackColor = Color.Red;
                    }
                    //转成正式
                    MessageBox.Show("红色项目不一致，请重新核对修改");
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

        #region gridView1_CustomDrawCell

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (showDifferent == false) return;

            if (e.Column.FieldName != "调整金额") return;

            e.Appearance.ForeColor = Color.Black;
            e.Appearance.BackColor = Color.Transparent;

            AdjustJobGrade row = gridView1.GetRow(e.RowHandle) as AdjustJobGrade;
            if (row != null)
            {
                if (row.is_separator) return;

                foreach (ModifyField field in row.内容不同的字段)
                {
                    if (field.名称 == e.Column.FieldName)
                    {
                        e.Appearance.ForeColor = Color.Yellow;
                        e.Appearance.BackColor = Color.Red;
                    }
                }
            }
        }
        #endregion

        private void AdjustGradeSalaryStandardByIncreaseForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null) this.Owner.Hide();
        }

        private void AdjustGradeSalaryStandardByIncreaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            AdjustJobGrade row = gridView1.GetRow(gridView1.FocusedRowHandle) as AdjustJobGrade;
            if (row != null && row.is_separator == false)
            {
                //自动创建职级工资记录
                if (e.Column.FieldName == "调整金额")
                {
                    UpdateRankSalary(row);
                    gridControl1.RefreshDataSource();
                    gridControl1.Refresh();
                }
            }
        }

        private void UpdateRankSalary(AdjustJobGrade row)
        {
            GradeSalaryAdjust gsa = row.调整记录;
            int 上级月薪 = gsa.最高工资 + gsa.级差 * 2;
            foreach (RankSalaryStandardInput rss in row.职级工资表)
            {
                if (rss.上期标准 != null)
                {
                    rss.月薪 = rss.上期标准.月薪 + row.调整金额;
                }
                else
                {
                    rss.月薪 = 上级月薪 - gsa.级差;
                }
                rss.Save();
                上级月薪 = rss.月薪;
            }
            gsa.半年调资额 = row.调整金额;
            gsa.Calculate();
            row.Refresh();
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            //自动创建职级工资记录
            if (e.Column.FieldName == "调整金额" && (int)e.Value == 0)
            {
                e.DisplayText = "";
            }
        }
    }

}

