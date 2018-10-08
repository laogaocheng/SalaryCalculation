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


namespace Hwagain.SalaryCalculation
{
    public partial class EditPersonPayRateForm : XtraForm
    {
        protected bool isCheckInput = false; //是否验证录入
        protected List<PersonPayRateInput> currInputRows = new List<PersonPayRateInput>();
        protected PersonPayRateInput currPersonPayRate = null;//当前记录

        public EditPersonPayRateForm(bool isCheck) 
            : this()
        {
            isCheckInput = isCheck;
        }

        public EditPersonPayRateForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void EditPersonPayRateForm_Load(object sender, EventArgs e)
        {
            this.Text = "个人职级工资录入 - " + (this.是验证录入 ? "验证录入" : "初次录入");

            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            //清除原来的数据
            currInputRows = PersonPayRateInput.GetEditingRows(this.是验证录入);
            //根据权限过滤
            currInputRows = currInputRows.FindAll(a => a.员工信息 != null && AccessController.CheckPayGroup(a.员工信息.薪资组));
            currInputRows = currInputRows.OrderBy(a => a.录入时间).ToList(); 
            
            gridControl1.DataSource = currInputRows;
            gridControl1.RefreshDataSource();
            gridView1.ExpandAllGroups();
        }

        #endregion

        #region BecomeEffective

        private void BecomeEffective(PersonPayRateInput input)
        {
            PersonPayRate m = new PersonPayRate();
            PersonPayRate found = PersonPayRate.GetPersonPayRate(input.员工编号, input.生效日期);
            if (found != null)
            {
                m = found;
            }
            input.CopyWatchMember(m);

            PersonPayRateInput anotherInput = input.另一人录入的记录 as PersonPayRateInput;

            m.录入人 = !input.是验证录入 ? input.录入人 : anotherInput.录入人;
            m.录入时间 = !input.是验证录入 ? input.录入时间 : anotherInput.录入时间;
            m.验证人 = input.是验证录入 ? input.录入人 : anotherInput.录入人;
            m.验证时间 = input.是验证录入 ? input.录入时间 : anotherInput.录入时间;
            m.有效 = true;
            m.Save();
            //将前一个有效记录作废            
            PersonPayRate prev = PersonPayRate.GetEffective(input.员工编号, input.生效日期.AddDays(-1));
            if(prev != null)
            {
                prev.有效 = false;
                prev.Save();
            }
            input.Save();
        }
        #endregion

        #region 是验证录入

        public bool 是验证录入
        {
            get
            {
                return isCheckInput;
            }
            set
            {
                isCheckInput = value;
            }
        }
        #endregion

        #region btn保存_Click

        private void btn保存_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                PersonPayRateInput currentItem = (PersonPayRateInput)colView.GetFocusedRow();
                if (currentItem != null) currentItem.Save();
                //遍历
                foreach(PersonPayRateInput row in currInputRows)
                {
                    row.GetModifiyFields();
                    //如果完全相同，转为正式
                    if (row.月薪 > 0 && row.内容不同的字段.Count == 0 && row.另一人已录入) BecomeEffective(row);
                }
                MessageBox.Show("保存成功！");
                LoadData();
            }
            MyHelper.WriteLog(LogType.信息, "修改个人职级工资记录", null);
        }
        #endregion

        #region btn添加_Click

        private void btn添加_Click(object sender, EventArgs e)
        {
            SearchEmployeeInfoForm form = new SearchEmployeeInfoForm();
            form.OnSelected += OnEmployeeSelectd;
            form.ShowDialog();
        }

        private void OnEmployeeSelectd(object sender, EmployeeInfo emp)
        {
            PersonPayRateInput item = PersonPayRateInput.GetEditing(emp.员工编号, this.是验证录入);
            if (item == null)
            {
                item = new PersonPayRateInput();
                item.生效日期 = MyHelper.GetPrevMonth1Day();
                item.是验证录入 = this.是验证录入;
                item.员工编号 = emp.员工编号;
                item.姓名 = emp.姓名;
                item.职务 = emp.职务名称;
            }
            item.录入人 = AccessController.CurrentUser.姓名;
            item.录入时间 = DateTime.Now;
            currInputRows.Add(item);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
            gridView1.ExpandAllGroups();

            MyHelper.WriteLog(LogType.信息, "新增不执行标准的个人职级工资记录", item.ToString<PersonPayRateInput>());
        }
        #endregion

        #region btn删除_Click

        private void btn删除_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实删除当前记录吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    try
                    {
                        PersonPayRateInput currentItem = (PersonPayRateInput)colView.GetFocusedRow();
                        currInputRows.Remove(currentItem);
                        currentItem.Delete();

                        MyHelper.WriteLog(LogType.信息, "删除个人职级工资", currentItem.ToString<PersonPayRateInput>());
                    }
                    catch { }
                    gridControl1.RefreshDataSource();
                    MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region btn刷新_Click

        private void btn刷新_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region gridView1_InvalidRowException

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }
        #endregion

        #region gridView1_CellValueChanged

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            PersonPayRateInput row = gridView1.GetRow(e.RowHandle) as PersonPayRateInput;

            if (row != null)
            {
                if (e.Column.FieldName == "员工编号")
                {
                    PersonalInfo pInfo = PersonalInfo.Get(row.员工编号);
                    if (pInfo == null)
                    {
                        MessageBox.Show("找不到指定编号的员工");
                    }
                    else
                    {
                        row.姓名 = pInfo.姓名;
                        row.职务 = pInfo.职务;
                        gridControl1.RefreshDataSource();
                    }
                }

                row.GetModifiyFields();
            }
        }
        #endregion

        #region gridView1_CustomDrawCell

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            e.Appearance.ForeColor = Color.Black;
            e.Appearance.BackColor = Color.Transparent;

            PersonPayRateInput row = gridView1.GetRow(e.RowHandle) as PersonPayRateInput;
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

        #region gridView1_FocusedRowChanged

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            PersonPayRateInput row = gridView1.GetRow(e.PrevFocusedRowHandle) as PersonPayRateInput;
            if (row != null)
            {
                row.GetModifiyFields();
            }
        }
        #endregion
    }

}

