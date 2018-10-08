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
    public partial class TraineeInfoForm : XtraForm
    {        
        protected bool isCheck = false; //是否验证录入

        string division = null;
        string grade = null;

        List<ManagementTraineeInfoInput> trainee_info_list = new List<ManagementTraineeInfoInput>();
        List<ManagementTraineeInfoInput> trainee_info_list_opposite = new List<ManagementTraineeInfoInput>();

        bool showDifferent = false;

        public TraineeInfoForm(string division, string grade, bool isCheck)
            : this()
        {
            this.division = division;
            this.grade = grade;
            this.isCheck = isCheck;            
        }

        public TraineeInfoForm()
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

        List<ManagementTraineeInfoInput> CreateEditingRows()
        {
            List<ManagementTraineeInfoInput> list = new List<ManagementTraineeInfoInput>();

            //清除历史记录
            ManagementTraineeInfoInput.ClearTraineeInfo(division, grade);

            //通过薪等编号获取员工名单
            List<EmployeeInfo> emp_list = GetEmployeeList();            
            //排序
            emp_list = emp_list.OrderBy(a => a.部门序号).ThenBy(a => a.机构序号).ThenBy(a => a.机构名称).ThenBy(a => a.员工序号).ToList();

            int order = 1;
            foreach (EmployeeInfo emp in emp_list)
            {
                TraineeInfo ti = TraineeInfo.Get(emp.员工编号);
                if (ti != null && ti.届别 == division && ti.岗位级别 == grade)
                {
                    ManagementSpecialtyProperty sp = ManagementSpecialtyProperty.GetManagementSpecialtyProperty(division, grade, ti.学历, ti.学习专业);
                    //创建员工月薪记录
                    ManagementTraineeInfoInput ms = ManagementTraineeInfoInput.AddManagementTraineeInfoInput(emp.员工编号, isCheck);
                    ms.序号 = order;
                    ms.届别 = division;
                    ms.岗位级别 = grade;
                    ms.学历 = ti.学历;
                    ms.专业名称 = ti.学习专业;
                    ms.入职时间 = ti.入职时间;
                    ms.专业属性 = sp == null ? "" : sp.属性;
                    ms.Save();
                    list.Add(ms);
                    order++;
                }
            }

            return list;
        }

        #endregion

        #region 获取员工名单

        List<EmployeeInfo> GetEmployeeList()
        {
            //上月期间开始
            DateTime date = SalaryResult.GetLastSalaryDate(null);
            List<EmployeeInfo> emp_list = EmployeeInfo.GetGuanPeiShengList(null, check包括离职人员.Checked == false);
            return emp_list;
        }

        #endregion

        #region 加载数据

        protected void LoadData(bool compare)
        {
            bool isSameEditor = false;

            CreateWaitDialog("正在查询...", "请稍等");

            trainee_info_list = ManagementTraineeInfoInput.GetEditingRows(division, grade, isCheck);
            //如果没有记录，自动创建
            if (trainee_info_list.Count == 0) trainee_info_list = CreateEditingRows();

            //如果比较
            if (compare) trainee_info_list_opposite = ManagementTraineeInfoInput.GetEditingRows(this.division, grade, !isCheck);
            
            SetWaitDialogCaption("正在加载...");            
            
            if (isSameEditor)
            {
                CloseWaitDialog();

                MessageBox.Show("两次录入不能是同一个人");
                this.Close();
            }

            gridControl1.DataSource = trainee_info_list;
            gridControl1.RefreshDataSource();

            CloseWaitDialog();

            showDifferent = compare;            
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

        private void AdjustMonthlySalaryForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = division + " 届" + grade + "定职人员基础信息";
            gridBand专业.Visible = grade != "一级";
            gridBand岗位类型.Visible = grade == "一级";
            gridBand专业属性.Visible = grade != "一级";
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
                foreach (ManagementTraineeInfoInput ms in trainee_info_list)
                {
                    if (ms.年薪 == 0)
                    {
                        MessageBox.Show("温馨提醒：发现有年薪为 0 的人员，请仔细检查确认");
                        break;
                    }
                }
                //重新排序
                trainee_info_list = trainee_info_list.OrderBy(a => a.序号).ThenByDescending(a => a.年薪).ThenBy(a=>a.入职时间).ToList();


                int order = 1;
                foreach (ManagementTraineeInfoInput item in trainee_info_list)
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

                foreach (ManagementTraineeInfoInput item in trainee_info_list)
                {
                    //手动比较录入的内容
                    item.CompareInputContent();
                }

                SetWaitDialogCaption("正在比较双人录入是否一致...");

                LoadData(true);
                //检查差异
                bool all_same = true;
                foreach (ManagementTraineeInfoInput ms in trainee_info_list)
                {
                    if (!ms.另一人已录入 || ms.内容不同的字段.Count > 0)
                    {
                        all_same = false;
                        break;
                    }
                }
                if (all_same)
                {
                    trainee_info_list = trainee_info_list.OrderBy(a=>a.序号).ThenByDescending(a => a.年薪).ThenBy(a => a.入职时间).ToList();
                    //转成正式
                    foreach (ManagementTraineeInfoInput ms in trainee_info_list)
                    {
                        ms.UpdateToFormalTable();
                        //生成员工第一年的提资标准
                        ManagementTraineePayStandard.CreatePayStandards(ms.员工编号, Convert.ToInt32(ms.届别));
                    }
                    MessageBox.Show("双人录入成功");
                }
                else
                {
                    //显示差异
                    gridControl1.DataSource = trainee_info_list;
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

            ManagementTraineeInfoInput row = advBandedGridView1.GetRow(e.RowHandle) as ManagementTraineeInfoInput;
            if (row != null)
            {
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

        #region advBandedGridView1_CellValueChanged

        private void advBandedGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            
        }

        #endregion

        private void AdjustMonthlySalaryForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Owner.Visible) this.Owner.Hide();
        }

        private void AdjustMonthlySalaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        private void btn返回目录_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn更新名单_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("更新名单会清除已经录入的数据，继续吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
            {
                CreateEditingRows();
                LoadData(false);
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

