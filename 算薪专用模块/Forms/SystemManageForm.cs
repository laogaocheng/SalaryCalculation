using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hwagain.Common;
using Hwagain.SalaryCalculation.Modules;
using Hwagain.SalaryCalculation.Components;
using Aspose.Cells;

namespace Hwagain.SalaryCalculation.Forms
{
    public partial class SystemManageForm : FrmFrameBase
    {
        public SystemManageForm()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            ShowModule("模块界面测试1");
        }
        protected override void RegistModules()
        {
            RegistModule("模块界面测试1", typeof(TestModule1), "测试而已");
            RegistModule("模块界面测试2", typeof(TestModule2), "测试而已");
            RegistModule("基础资料维护", typeof(BaseDataModule), "基础资料维护");
            RegistModule("基础资料类型定义", typeof(TypeDefineModule), "基础资料类型定义");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ShowModule("模块界面测试1");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ShowModule("模块界面测试2");
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ShowModule("行政区域维护");
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ShowModule("基础资料维护");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            ShowModule("基础资料类型定义");
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            ShowModule("经销商资料维护");
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            ShowModule("商场资料维护");
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            ShowModule("门店资料维护");
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            ShowModule("产品信息维护");
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            ShowModule("促销费用标准录入界面");
        }
    }
}