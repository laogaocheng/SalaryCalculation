using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using Hwagain.SalaryCalculation.Components;
using Hwagain.Components;
using DevExpress.XtraEditors.Controls;


namespace Hwagain.SalaryCalculation
{
    public partial class LevelConfigForm : XtraForm
    {
        List<LevelInfo> levelList = new List<LevelInfo>();

        public LevelConfigForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }
        private void LevelConfig_Load(object sender, System.EventArgs e)
        {
            LevelInfo.Reset();

            Init();
        }

        private void Init()
        {            
            //初始化职务等级列表
            repositoryItemImageComboBox.Items.Clear();
            List<职务等级> lvlList = new List<职务等级>();
            foreach (DictionaryEntry entry in PsHelper.GetSupvLvls())
            {
                职务等级 lvl = new 职务等级 { 编码 = (string)entry.Value, 名称 = (string)entry.Key };
                lvlList.Add(lvl);
            }
            lvlList = lvlList.OrderBy(a => a.编码).ToList();
            foreach (职务等级 lvl in lvlList)
            {
                ImageComboBoxItem item = new ImageComboBoxItem(lvl.名称, lvl.编码);
                repositoryItemImageComboBox.Items.Add(item);
            }

            LoadData();
        }

        private void LoadData()
        {
            levelList.Clear();
            foreach (LevelInfo rg in LevelInfo.GetAll())
            {
                levelList.Add(rg);
            }
            gridControl1.DataSource = levelList;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LevelInfo level = new LevelInfo();
            level.标识 = Guid.NewGuid();
            levelList.Add(level);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实删除当前记录吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    LevelInfo currentSalaryLevel = (LevelInfo)colView.GetFocusedRow();
                    if (currentSalaryLevel != null)
                    {
                        levelList.Remove(currentSalaryLevel);
                        currentSalaryLevel.Delete();
                        gridControl1.RefreshDataSource();
                        MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {

        }

        #region btn保存_Click

        private void btn保存_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                LevelInfo currentItem = (LevelInfo)colView.GetFocusedRow();
                if (currentItem != null)
                {
                    currentItem.Save();
                }
            }
            MessageBox.Show("保存成功。", "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region btn自动根据最低工资额生成级别_Click

        private void btn自动根据最低工资额生成级别_Click(object sender, EventArgs e)
        {
            List<LevelInfo> list = levelList.OrderByDescending(a => a.最低工资额).ToList();
            int order = 1;
            foreach (LevelInfo level in list)
            {
                level.级别 = order;
                level.Save();
                order++;
            }
            levelList = list;
            LoadData();
            MessageBox.Show("自动设置级别成功。", "自动设置级别提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
    struct 职务等级
    {
        public string 编码;
        public string 名称;

        public override string ToString()
        {
            return 名称;
        }
    }
}

