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
using DevExpress.Xpo;


namespace Hwagain.SalaryCalculation
{
    public partial class EditGradeSalaryStandardForm : XtraForm
    {
        protected bool isCheckInput = false; //是否验证录入
        public delegate void FinishGradeSalaryStandardInputHandle(AdjustJobGrade grade, GradeSalaryAdjust gsa, List<RankSalaryStandardInput> rss_input);
        public event FinishGradeSalaryStandardInputHandle OnFinished;

        List<RankSalaryStandardInput> currInputRows = new List<RankSalaryStandardInput>();
        AdjustJobGrade grade = null; //职等
        GradeSalaryAdjust gsa = null;

        public EditGradeSalaryStandardForm(AdjustJobGrade sGrade, bool isCheck) 
            : this()
        {
            isCheckInput = isCheck;
            grade = sGrade;
            lbl职等名称.Text = "职等名称：" + sGrade.名称;
        }

        public EditGradeSalaryStandardForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void EditGradeSalaryStandardForm_Load(object sender, EventArgs e)
        {             
            //初始化职等列表
            List<JobGrade> grades = JobGrade.GetJobGrades(grade.薪酬体系);
            cb对比的职等.Properties.Items.Clear();
            foreach (JobGrade g in grades)
            {
                cb对比的职等.Properties.Items.Add(g.名称); 
            }

            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            gsa = GradeSalaryAdjust.AddGradeSalaryAdjust(grade.薪酬体系, grade.名称, grade.期号, isCheckInput ? 2 : 1);

            cb对比的职等.EditValue = grade.对比的职等;
            txt职等数.Text = grade.职等数;
            text半年调资额.Text = gsa.半年调资额.ToString();

            currInputRows = GetRows();
            vGridControl1.DataSource = currInputRows;
            vGridControl1.RefreshDataSource();
            vGridControl1.Refresh();
        }

        #endregion

        #region GetRows

        private List<RankSalaryStandardInput> GetRows()
        {
            List<RankSalaryStandardInput> rows = new List<RankSalaryStandardInput>();
            List<JobRank> ranks = JobRank.GetJobRanks(grade.标识);
            foreach (JobRank rank in ranks)
            {
                RankSalaryStandardInput row = RankSalaryStandardInput.AddRankSalaryStandardInput(rank.职等.薪酬体系, rank.职等.名称, rank.名称, grade.期号, rank.序号, isCheckInput);
                rows.Add(row);
            }
            return rows;
        }
        #endregion

        private void btn添加职级_Click(object sender, EventArgs e)
        {
            string names = newRankName.Text.Trim();
            if (names.Trim() == "")
                MessageBox.Show("职级名称不能为空");
            else
            {
                grade.职等.AppendRanks(names);
                newRankName.Text = "";
                LoadData();
            }
        }

        private void btn删除职级_Click(object sender, EventArgs e)
        {
            RankSalaryStandardInput row = vGridControl1.GetRecordObject(vGridControl1.FocusedRecord) as RankSalaryStandardInput;
            if (row != null)
            {
                if (MessageBox.Show("确实删除当前选择的职级吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    currInputRows.Remove(row);
                    
                    JobRank rank = grade.职等.职级表.Find(a=>a.名称 == row.职级);
                    if (rank != null)
                    {
                        MyHelper.WriteLog(LogType.信息, "删除职级", rank.ToString<JobRank>());
                        rank.Delete();                        
                    }
                    row.Delete();

                    vGridControl1.RefreshDataSource();
                    MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("请点击选择要删除的职级再删");
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            if (YiKang.Common.IsInteger(text半年调资额.Text) == false)
            {
                MessageBox.Show("必须录入半年调资额。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            JobGrade jGrade = grade.职等;
            jGrade.对比的职等 = (string)cb对比的职等.EditValue;
            jGrade.职等数 = txt职等数.Text.Trim() == "" ? 1 : Convert.ToInt32(txt职等数.Text.Trim());
            jGrade.Save();
            
            //检查级差是否相同
            int prev_diff = 0;
            int x = 0;
            RankSalaryStandardInput prev_row = null;
            List<RankSalaryStandardInput> rows = GetRows().OrderBy(a => a.序号).ToList();
            foreach (RankSalaryStandardInput row in rows)
            {
                if (prev_row != null)
                {
                    int diff = row.月薪 - prev_row.月薪;
                    if (x > 1 && diff != prev_diff && grade.薪酬体系 != "软件开发")
                    {
                        MessageBox.Show("级差不一致，请重新录入");
                        return;
                    }
                    prev_diff = row.月薪 - prev_row.月薪;
                }
                x++;
                prev_row = row;
                row.序号 = x; //重置序号，使其从1开始，步长为1
            }
            //保存(必须调用，否则并没有实际存入数据库，VGridControl 不像 GridControl 会自动存)
            Session.DefaultSession.Save(rows);
            //保存更新职等信息
            gsa.职等数 = jGrade.职等数;
            gsa.对比的职等 = jGrade.对比的职等;
            gsa.半年调资额 = Convert.ToInt32(text半年调资额.Text);       
            //统计
            gsa.Calculate();
            gsa.Save();
            //刷新
            grade.Refresh();
            //触发完成事件
            if (OnFinished != null)
            {
                OnFinished(grade, gsa, rows);
            }
            this.Close();
        }

        private void btn返回上一层_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn调整顺序_Click(object sender, EventArgs e)
        {
            if (月薪.Visible)
            {
                btn调整顺序.Text = "顺序调整完成";
                月薪.Visible = false;
                序号.Visible = true;                
            }
            else
            {
                btn调整顺序.Text = "调整顺序";
                月薪.Visible = true;
                序号.Visible = false;
            }
            LoadData();
        }

        private void btn清除_Click(object sender, EventArgs e)
        {
            cb对比的职等.EditValue = "";
        }

        private void btn添加默认_Click(object sender, EventArgs e)
        {
            grade.职等.AppendRanks("优,A+,A,A-,B+,B,B-,C+,C,C-");
            LoadData();
        }
    }

}

