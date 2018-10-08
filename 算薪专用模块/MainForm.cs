using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System.IO;
using System.Runtime.InteropServices;
using DevExpress.Utils;
using Hwagain;
using Hwagain.SalaryCalculation;
using System.Diagnostics;
using Hwagain.Common;
using Hwagain.SalaryCalculation.Forms;
using System.Reflection;
using DevExpress.XtraEditors;
using Hwagain.SalaryCalculation.Components.Common;
using Hwagain.SalaryCalculation.Modules;
using Hwagain.SalaryCalculation.Components;
using Hwagain.Common.Components;
using Hwagain.SalaryCalculation.Components.Forms;
using Hwagain.SalaryCalculation.Components.Forms.IndexForms;

namespace Hwagain.SalaryCalculation
{
    public partial class MainForm : RibbonForm
    {
        private Timer timer = new Timer();
        FormSystemManage frmSystemManage = null;
        MessageForm msgForm = new MessageForm();

        bool showWebView = true; //文件夹是否显示常见任务

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr vParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int nMaxLen);

        #region MainForm

        public MainForm()
        {
            InitializeComponent();
            defaultLookAndFeel1.LookAndFeel.SkinName = MyHelper.LookAndFeel;
            this.Size = new System.Drawing.Size(900, 600);
            InitSkinGallery();
            this.WindowState = FormWindowState.Maximized;
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        #endregion

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

        #region MainForm_FormClosing

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确实要关闭系统吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
            {
                if (AccessController.CurrentUser != null)
                {
                    Hwagain.Components.Log.WriteLog(YiKang.LogType.成功审核, "关闭系统", AccessController.CurrentUser.用户名);
                    AccessController.CurrentRoles = null;
                    AccessController.CurrentUser = null;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region MainForm_Load

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer.Interval = 200;
            timer.Tick += timer_Tick;
            timer.Enabled = true;
            Login();
            //ShowWindow(typeof(SelectCompanyForm), true);
        }
        #endregion

        #region Login

        public void Login()
        {
            using (FormLogin frmLogin = new FormLogin())
            {
                frmLogin.MainForm = this;
                DialogResult result = frmLogin.ShowDialog();
                switch (result)
                {
                    case DialogResult.OK:
                        break;
                    default:
                        break;
                }
            }
            if (AccessController.CurrentUser != null)
                currUsername.Caption = string.Format("当前用户：{0}", AccessController.CurrentUser.用户名);
            else
                currUsername.Caption = "——未登录——";

            SetButtonEnabled();
        }
        #endregion

        #region timer_Tick

        //定时器触发
        private void timer_Tick(object sender, EventArgs e)
        {
            MyHelper.UpdateTime();
            siServerTime.Caption = MyHelper.当前时间.ToString();
            SetButtonEnabled();
        }
        #endregion

        #region SetButtonEnabled

        //设置按钮可用性
        void SetButtonEnabled()
        {

            i上表工资.Enabled = AccessController.CurrentUser != null;
            i工资单.Enabled = AccessController.CurrentUser != null;

            btnChangePassword.Enabled = AccessController.CurrentUser != null;
            i工资报盘表.Enabled = AccessController.CurrentUser != null;
            i工资部门汇总报表.Enabled = AccessController.CurrentUser != null;
            i纳税申报表.Enabled = AccessController.CurrentUser != null;
            i工资发放审核表.Enabled = AccessController.CurrentUser != null;
            i个人所得税.Enabled = AccessController.CurrentUser != null;
            i上表工资.Enabled = AccessController.CurrentUser != null;
            i打印工资条.Enabled = AccessController.CurrentUser != null;
            i薪酬体系目录.Enabled = AccessController.CurrentUser != null;
            i工资标准.Enabled = AccessController.CurrentUser != null;
            i员工工资职级初次录入.Enabled = AccessController.CurrentUser != null;
            i员工工资职级验证录入.Enabled = AccessController.CurrentUser != null;
            i员工工资职级查询.Enabled = AccessController.CurrentUser != null;

            i其它奖项.Enabled = AccessController.CurrentUser != null;
            i其它扣项.Enabled = AccessController.CurrentUser != null;
            i其它代垫费用.Enabled = AccessController.CurrentUser != null;
            i工资降级.Enabled = AccessController.CurrentUser != null;
            i导入其它奖扣.Enabled = AccessController.CurrentUser != null;
            i工资系数浏览.Enabled = AccessController.CurrentUser != null;
            i工资系数导入.Enabled = AccessController.CurrentUser != null;

            i初次录入标准职级工资.Enabled = AccessController.CurrentUser != null;
            i验证录入标准职级工资.Enabled = AccessController.CurrentUser != null;

            i初次录入个人职级工资.Enabled = AccessController.CurrentUser != null;
            i验证录入个人职级工资.Enabled = AccessController.CurrentUser != null;
            i个人职级工资查询.Enabled = AccessController.CurrentUser != null;
            i调整个人职级工资顺序.Enabled = AccessController.CurrentUser != null;

            //报销标准录入
            i报销标准验证录入.Enabled = AccessController.CurrentUser != null;
            i报销标准初次录入.Enabled = AccessController.CurrentUser != null;
            i报销标准查询.Enabled = AccessController.CurrentUser != null;
            //约定绩效工资录入
            i约定绩效工资初次录入.Enabled = AccessController.CurrentUser != null;
            i约定绩效工资验证录入.Enabled = AccessController.CurrentUser != null;
            i约定绩效工资查询.Enabled = AccessController.CurrentUser != null;
            //员工报销记录录入
            i报销初次录入.Enabled = AccessController.CurrentUser != null;
            i报销验证录入.Enabled = AccessController.CurrentUser != null;
            i报销记录查询.Enabled = AccessController.CurrentUser != null;
            //执行绩效工资录入
            i执行绩效工资初次录入.Enabled = AccessController.CurrentUser != null;
            i执行绩效工资验证录入.Enabled = AccessController.CurrentUser != null;
            i执行绩效工资查询.Enabled = AccessController.CurrentUser != null;
            //借款录入
            i借款初次录入.Enabled = AccessController.CurrentUser != null;
            i借款验证录入.Enabled = AccessController.CurrentUser != null;
            i借款记录查询.Enabled = AccessController.CurrentUser != null;
            i还款记录查询.Enabled = AccessController.CurrentUser != null;

            i工资审核表.Enabled = AccessController.CurrentUser != null;
            i工资抽查审核.Enabled = AccessController.CurrentUser != null;

            i封闭工资结构.Enabled = AccessController.CurrentUser != null;
            i封闭工资标准.Enabled = AccessController.CurrentUser != null;

            i薪酬计算表.Enabled = AccessController.CurrentUser != null;
            i薪酬结构及标准明细.Enabled = AccessController.CurrentUser != null;

            //报表权限
            i员工月薪明细表.Enabled = AccessController.CurrentUser != null;
            i工资发放表.Enabled = AccessController.CurrentUser != null;
            i封闭工资计算表.Enabled = AccessController.CurrentUser != null;
            iSystemManage.Enabled = AccessController.CurrentUser != null;
            i值列表.Enabled = AccessController.CurrentUser != null;
            i部门体系.Enabled = AccessController.CurrentUser != null;
            i数据库配置.Enabled = AccessController.CurrentUser != null;
            i职等配置.Enabled = AccessController.CurrentUser != null;

            btnRefreshData.Enabled = AccessController.CurrentUser != null;
            i工资表.Enabled = AccessController.CurrentUser != null;
            i封闭工资发放清单.Enabled = AccessController.CurrentUser != null;
            i销售公司部门薪酬统计表.Enabled = AccessController.CurrentUser != null;
            i按部门薪酬统计.Enabled = AccessController.CurrentUser != null;
            i按省办薪酬统计.Enabled = AccessController.CurrentUser != null;
            i部门薪酬统计表.Enabled = AccessController.CurrentUser != null;
            i职务薪酬统计表.Enabled = AccessController.CurrentUser != null;
            i正常工资薪金.Enabled = AccessController.CurrentUser != null;

            i职等管理.Enabled = AccessController.CurrentUser != null;
            i准入电脑.Enabled = AccessController.CurrentUser != null;
            i权限查询.Enabled = AccessController.CurrentUser != null;
            i查询权限初次录入.Enabled = AccessController.CurrentUser != null;
            i查询权限验证录入.Enabled = AccessController.CurrentUser != null;

            i录入职级工资.Enabled = AccessController.CurrentUser != null;
            i查看各职等职级月薪执行标准.Enabled = AccessController.CurrentUser != null;
            i录入各职等等管理人员薪酬执行明细.Enabled = AccessController.CurrentUser != null;
            i查看各职等管理人员薪酬执行明细.Enabled = AccessController.CurrentUser != null;
            i录入异动人员工资.Enabled = AccessController.CurrentUser != null;
            i薪酬结构表.Enabled = AccessController.CurrentUser != null;

            //薪酬结构模块
            i实际报账发放计算.Enabled = AccessController.CurrentUser != null;
            i实际报账工资初次录入.Enabled = AccessController.CurrentUser != null;
            i实际报账工资验证录入.Enabled = AccessController.CurrentUser != null;

            i实际工资借款发放计算.Enabled = AccessController.CurrentUser != null;
            i实际工资借款初次录入.Enabled = AccessController.CurrentUser != null;
            i实际工资借款验证录入.Enabled = AccessController.CurrentUser != null;

            i薪酬结构查询.Enabled = AccessController.CurrentUser != null;
            i薪酬结构初次录入.Enabled = AccessController.CurrentUser != null;
            i薪酬结构验证录入.Enabled = AccessController.CurrentUser != null;

            i工资借款查询.Enabled = AccessController.CurrentUser != null;
            i工资借款初次录入.Enabled = AccessController.CurrentUser != null;
            i工资借款验证录入.Enabled = AccessController.CurrentUser != null;

            i查询报账工资.Enabled = AccessController.CurrentUser != null;
            i报账工资初次录入.Enabled = AccessController.CurrentUser != null;
            i报账工资验证录入.Enabled = AccessController.CurrentUser != null;

            i报账工资明细表.Enabled = AccessController.CurrentUser != null;
            i工资借款明细表.Enabled = AccessController.CurrentUser != null;
            
            //管培生管理
            i薪酬计划表.Enabled = AccessController.CurrentUser != null;
            i录入提资表.Enabled = AccessController.CurrentUser != null;
            i基础信息录入.Enabled = AccessController.CurrentUser != null;
            i专业属性确认.Enabled = AccessController.CurrentUser != null;
            i工资增幅表.Enabled = AccessController.CurrentUser != null;


            SetButtonEnableByRight();
        }
        #endregion

        #region SetButtonEnableByRight

        private void SetButtonEnableByRight()
        {
            //业务权限
            if (i其它奖项.Enabled) i其它奖项.Enabled = AccessController.CheckInputSalaryItem();
            if (i其它扣项.Enabled) i其它扣项.Enabled = AccessController.CheckInputSalaryItem();
            if (i其它代垫费用.Enabled) i其它代垫费用.Enabled = AccessController.CheckInputSalaryItem();
            if (i工资降级.Enabled) i工资降级.Enabled = AccessController.CheckInputSalaryItem();
            if (i导入其它奖扣.Enabled) i导入其它奖扣.Enabled = AccessController.CheckInputSalaryItem();
            if (i工资系数浏览.Enabled) i工资系数浏览.Enabled = AccessController.CheckInputSalaryItem();
            if (i工资系数导入.Enabled) i工资系数导入.Enabled = AccessController.CheckInputSalaryItem();
            //工资结构
            if (i封闭工资结构.Enabled) i封闭工资结构.Enabled = AccessController.CheckManagePrivateSalaryTree();
            if (i封闭工资标准.Enabled) i封闭工资标准.Enabled = AccessController.CheckLookupStepPayRate();
            //标准职级工资录入
            if (i初次录入标准职级工资.Enabled) i初次录入标准职级工资.Enabled = AccessController.CheckInputEmpPayRate();
            if (i验证录入标准职级工资.Enabled) i验证录入标准职级工资.Enabled = AccessController.CheckInputEmpPayRate();
            //不执行标准的职级工资录入
            if (i初次录入个人职级工资.Enabled) i初次录入个人职级工资.Enabled = AccessController.CheckInputPersonPayRate();
            if (i验证录入个人职级工资.Enabled) i验证录入个人职级工资.Enabled = AccessController.CheckInputPersonPayRate();
            if (i个人职级工资查询.Enabled) i个人职级工资查询.Enabled = AccessController.CheckInputPersonPayRate();
            if (i调整个人职级工资顺序.Enabled) i调整个人职级工资顺序.Enabled = AccessController.CheckInputPersonPayRate();
            //员工工资职级录入
            if (i员工工资职级初次录入.Enabled) i员工工资职级初次录入.Enabled = AccessController.CheckEmployeeSalaryStepInput();
            if (i员工工资职级验证录入.Enabled) i员工工资职级验证录入.Enabled = AccessController.CheckEmployeeSalaryStepInput();
            if (i员工工资职级查询.Enabled) i员工工资职级查询.Enabled = AccessController.CheckEmployeeSalaryStepInput();
            //报销标准录入
            if (i报销标准验证录入.Enabled) i报销标准验证录入.Enabled = AccessController.CheckReimbursementStandardInput();
            if (i报销标准初次录入.Enabled) i报销标准初次录入.Enabled = AccessController.CheckReimbursementStandardInput();
            if (i报销标准查询.Enabled) i报销标准查询.Enabled = AccessController.CheckReimbursementStandardInput();
            //约定绩效工资录入
            if (i约定绩效工资初次录入.Enabled) i约定绩效工资初次录入.Enabled = AccessController.CheckPerformanceSalaryInput();
            if (i约定绩效工资验证录入.Enabled) i约定绩效工资验证录入.Enabled = AccessController.CheckPerformanceSalaryInput();
            if (i约定绩效工资查询.Enabled) i约定绩效工资查询.Enabled = AccessController.CheckPerformanceSalaryInput();
            //员工报销记录录入
            if (i报销初次录入.Enabled) i报销初次录入.Enabled = AccessController.CheckPersonReimbursementInput();
            if (i报销验证录入.Enabled) i报销验证录入.Enabled = AccessController.CheckPersonReimbursementInput();
            if (i报销记录查询.Enabled) i报销记录查询.Enabled = AccessController.CheckPersonReimbursementInput();
            //执行绩效工资录入
            if (i执行绩效工资初次录入.Enabled) i执行绩效工资初次录入.Enabled = AccessController.CheckEffectivePerformanceSalaryInput();
            if (i执行绩效工资验证录入.Enabled) i执行绩效工资验证录入.Enabled = AccessController.CheckEffectivePerformanceSalaryInput();
            if (i执行绩效工资查询.Enabled) i执行绩效工资查询.Enabled = AccessController.CheckEffectivePerformanceSalaryInput();
            //借款录入
            if (i借款初次录入.Enabled) i借款初次录入.Enabled = AccessController.CheckPersonBorrowInput();
            if (i借款验证录入.Enabled) i借款验证录入.Enabled = AccessController.CheckPersonBorrowInput();
            if (i借款记录查询.Enabled) i借款记录查询.Enabled = AccessController.CheckPersonBorrowInput();
            if (i还款记录查询.Enabled) i还款记录查询.Enabled = AccessController.CheckPersonBorrowInput();
            //工资审核
            if (i工资审核表.Enabled) i工资审核表.Enabled =  AccessController.CheckDoAuditingPay() || AccessController.CheckLockPay();
            if (i工资抽查审核.Enabled) i工资抽查审核.Enabled = AccessController.CheckDoAuditingPay();
            if (i薪酬计算表.Enabled) i薪酬计算表.Enabled = AccessController.CheckDoAuditingPay();
            if (i薪酬结构及标准明细.Enabled) i薪酬结构及标准明细.Enabled = AccessController.CheckDoAuditingPay();
            if (i打印工资条.Enabled) i打印工资条.Enabled = AccessController.CheckPrintPayReport();
            
            //报表权限
            if (i员工月薪明细表.Enabled) i员工月薪明细表.Enabled = AccessController.CheckOpenPayReport();
            if (i工资发放表.Enabled) i工资发放表.Enabled = AccessController.CheckOpenPayReport();
            if (i封闭工资计算表.Enabled) i封闭工资计算表.Enabled = AccessController.CheckOpenPayReport();
            if (i工资报盘表.Enabled) i工资报盘表.Enabled = AccessController.CheckOpenPayReport();
            if (i工资部门汇总报表.Enabled) i工资部门汇总报表.Enabled = AccessController.CheckOpenPayReport();
            if (i工资发放审核表.Enabled) i工资发放审核表.Enabled = AccessController.CheckOpenPayReport();
            if (i个人所得税.Enabled) i个人所得税.Enabled = AccessController.CheckOpenPayReport();
            if (i薪酬体系目录.Enabled) i薪酬体系目录.Enabled = AccessController.CheckOpenPayReport();
            if (i工资标准.Enabled) i工资标准.Enabled = AccessController.CheckOpenPayReport();
            if (i工资表.Enabled) i工资表.Enabled = AccessController.CheckOpenPayReport();
            if (i封闭工资发放清单.Enabled) i封闭工资发放清单.Enabled = AccessController.CheckOpenPayReport();

            if (i销售公司部门薪酬统计表.Enabled) i销售公司部门薪酬统计表.Enabled = AccessController.CheckOpenTaxReport();
            if (i按部门薪酬统计.Enabled) i按部门薪酬统计.Enabled = AccessController.CheckOpenTaxReport();
            if (i按省办薪酬统计.Enabled) i按省办薪酬统计.Enabled = AccessController.CheckOpenTaxReport();
            if (i部门薪酬统计表.Enabled) i部门薪酬统计表.Enabled = AccessController.CheckOpenTaxReport();
            if (i职务薪酬统计表.Enabled) i职务薪酬统计表.Enabled = AccessController.CheckOpenTaxReport();
            
            //纳税申报表只有谢总能看
            if (i纳税申报表.Enabled) i纳税申报表.Enabled = AccessController.CheckOpenTaxReport();
            if (i正常工资薪金.Enabled) i正常工资薪金.Enabled = AccessController.CheckOpenTaxReport();
            
            //查询权录入
            if (i准入电脑.Enabled) i准入电脑.Enabled = AccessController.CheckConfig();
            if (i权限查询.Enabled) i权限查询.Enabled = AccessController.CheckQueryLevelInput();
            if (i查询权限初次录入.Enabled) i查询权限初次录入.Enabled = AccessController.CheckQueryLevelInput();
            if (i查询权限验证录入.Enabled) i查询权限验证录入.Enabled = AccessController.CheckQueryLevelInput();
            
            //系统权限            
            if (i值列表.Enabled) i值列表.Enabled = AccessController.CheckConfig();
            if (i职等管理.Enabled) i职等管理.Enabled = AccessController.CheckConfig();
            if (i部门体系.Enabled) i部门体系.Enabled = AccessController.CheckConfig();
            if (i数据库配置.Enabled) i数据库配置.Enabled = AccessController.CheckConfig();
            if (i职等配置.Enabled) i职等配置.Enabled = AccessController.CheckConfig();            
            if (iSystemManage.Enabled) iSystemManage.Enabled = AccessController.CheckManagePermission() || AccessController.CheckConfig() || AccessController.CheckManageUser();

            //月薪标准
            if (i录入职级工资.Enabled) i录入职级工资.Enabled = AccessController.CheckInputEmpPayRate();
            if (i查看各职等职级月薪执行标准.Enabled) i查看各职等职级月薪执行标准.Enabled = AccessController.CheckInputEmpPayRate();
            if (i录入各职等等管理人员薪酬执行明细.Enabled) i录入各职等等管理人员薪酬执行明细.Enabled = AccessController.CheckInputPersonPayRate();
            if (i录入异动人员工资.Enabled) i录入异动人员工资.Enabled = AccessController.CheckInputPersonPayRate();
            if (i薪酬结构表.Enabled) i薪酬结构表.Enabled = AccessController.CheckInputEmpPayRate();
            if (i查看各职等管理人员薪酬执行明细.Enabled) i查看各职等管理人员薪酬执行明细.Enabled = AccessController.CheckInputPersonPayRate();

            //薪酬结构模块
            if (i实际报账发放计算.Enabled) i实际报账发放计算.Enabled = AccessController.CheckInputEmpPayRate();
            if (i实际报账工资初次录入.Enabled) i实际报账工资初次录入.Enabled = AccessController.CheckInputEmpPayRate();
            if (i实际报账工资验证录入.Enabled) i实际报账工资验证录入.Enabled = AccessController.CheckInputEmpPayRate();

            //if (i实际工资借款发放计算.Enabled) i实际工资借款发放计算.Enabled = AccessController.CheckInputEmpPayRate();
            if (i实际工资借款初次录入.Enabled) i实际工资借款初次录入.Enabled = AccessController.CheckInputEmpPayRate();
            if (i实际工资借款验证录入.Enabled) i实际工资借款验证录入.Enabled = AccessController.CheckInputEmpPayRate();

            if (i薪酬结构查询.Enabled) i薪酬结构查询.Enabled = AccessController.CheckInputEmpPayRate();
            if (i薪酬结构初次录入.Enabled) i薪酬结构初次录入.Enabled = AccessController.CheckInputEmpPayRate();
            if (i薪酬结构验证录入.Enabled) i薪酬结构验证录入.Enabled = AccessController.CheckInputEmpPayRate();

            if (i工资借款查询.Enabled) i工资借款查询.Enabled = AccessController.CheckInputEmpPayRate();
            if (i工资借款初次录入.Enabled) i工资借款初次录入.Enabled = AccessController.CheckInputEmpPayRate();
            if (i工资借款验证录入.Enabled) i工资借款验证录入.Enabled = AccessController.CheckInputEmpPayRate();

            if (i查询报账工资.Enabled) i查询报账工资.Enabled = AccessController.CheckInputEmpPayRate();
            if (i报账工资初次录入.Enabled) i报账工资初次录入.Enabled = AccessController.CheckInputEmpPayRate();
            if (i报账工资验证录入.Enabled) i报账工资验证录入.Enabled = AccessController.CheckInputEmpPayRate();

            if (i报账工资明细表.Enabled) i报账工资明细表.Enabled = AccessController.CheckInputEmpPayRate();
            if (i工资借款明细表.Enabled) i工资借款明细表.Enabled = AccessController.CheckInputEmpPayRate();

            //管培生管理
            if (i薪酬计划表.Enabled) i薪酬计划表.Enabled = AccessController.CheckInputEmpPayRate();
            if (i录入提资表.Enabled) i录入提资表.Enabled = AccessController.CheckInputEmpPayRate();
            if (i基础信息录入.Enabled) i基础信息录入.Enabled = AccessController.CheckInputEmpPayRate();
            if (i专业属性确认.Enabled) i专业属性确认.Enabled = AccessController.CheckInputEmpPayRate();
            if (i工资增幅表.Enabled) i工资增幅表.Enabled = AccessController.CheckInputEmpPayRate();
        }
        #endregion

        #region SetStatus

        public void SetStatus(string s)
        {
            siStatus.Caption = s;
        }
        #endregion

        #region iLogin_ItemClick

        private void iLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            Login();
        }
        #endregion

        #region iPermission_ItemClick

        private void iPermission_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(FormSystemManage), false);
        }
        #endregion

        #region ShowMessage

        public void ShowMessage(string title, string msg)
        {
            this.Activate();

            msgForm.标题 = title;
            msgForm.消息 = msg;

            if (!msgForm.Visible)
                msgForm.ShowDialog();
        }
        #endregion

        #region iAbout_ItemClick

        private void iAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
#if(DEBUG)
            string supvLvlId = SalResult.GetSupvLvlId("A05549", 2008, 10);
            MessageBox.Show(supvLvlId);
            //string a = SalaryResult.GetGrade("一级经理");
            //string b = SalaryResult.GetGrade("经理级");
            //string c = SalaryResult.GetGrade("岗位工级");

            //string d;
            //Last5YearMonthlySalaryStandardForm form = new Last5YearMonthlySalaryStandardForm("赣州纸品", "厂长");
            //form.ShowDialog();
            //WageLoan.AutoGenerateMonthlyWageLoanItems(2018, 4);
            //List<string> arr = LevelInfo.副经理以下管理人员职等;
            //MessageBox.Show(arr.Count.ToString());
            //EmployeeInfo empInfo = EmployeeInfo.GetEmployeeInfo("A03378");
            //string grade = EmployeeInfo.GetGrade(empInfo);
            //测试
            //TaxInfo tax = TaxInfo.Get(5000);
            //MessageBox.Show(tax.税率.ToString());
            //tax = TaxInfo.Get(8000);
            //MessageBox.Show(tax.税率.ToString());
            //tax = TaxInfo.Get(16000);
            //MessageBox.Show(tax.税率.ToString());
            //JobGrade.SychJobGrade();

            //JobGrade grade = JobGrade.GetJobGrade(new Guid("BF3C76AD-F418-4E73-9289-9686C8279F4C"));
            //grade.CreateRanks("优,A+, A, A-,B+, B, B-,C+, C, C-");
            //grade.AppendRank("D+");
            //List<AdjustJobGrade> gradeList = AdjustJobGrade.GetAdjustJobGradeList("HJ05", 2017, SemiannualType.上半年, false, false);
            //AdjustJobGrade grade = gradeList.Find(a => a.职级表.Count > 0);            
            //ShowWindow(typeof(EditGradeSalaryStandardForm), true, new object[] { grade, false });
            //ShowWindow(typeof(AdjustGradeSalaryStandardForm), false, new object[] { "HJ05", 2017, SemiannualType.上半年, true });            
            //ShowWindow(typeof(GradeSalaryStandardForm), false, new object[] { "HJ05", 2017, SemiannualType.上半年 });            
            //ShowWindow(typeof(AdjustMonthlySalaryForm), false, new object[] { "HJ05", "赣纸-总经理", 2017, SemiannualType.上半年, true });                        
            //MonthlySalary.ClearInvalidRecord();
            //ShowWindow(typeof(GradeSalaryAdjustForm), false, new object[] { "集团总部", 2017, SemiannualType.下半年, true });
            //GradeSalaryAdjustInput.CreateGradeSalaryAdjustTable("集团总部", 20172, false);
#endif
        }
        #endregion

        #region rgbiSkins_GalleryItemCheckedChanged

        private void rgbiSkins_GalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            MyHelper.LookAndFeel = e.Item.Caption;
        }
        #endregion

        #region iTest_ItemClick

        private void iTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SystemManageForm), false);
        }
        #endregion

        #region i基础资料_ItemClick

        private void i基础资料_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(BaseDataManageForm), false);
        }
        #endregion

        #region CloseAlWindow

        public void CloseAlWindow()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }
        #endregion

        #region ShowWindow

        public void ShowWindow(Type windowType, bool isDialog)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child.GetType() == windowType && !child.IsDisposed)
                {
                    child.Activate();
                    child.Show();
                    return;
                }
            }

            ConstructorInfo constructorInfoObj = windowType.GetConstructor(Type.EmptyTypes);
            if (constructorInfoObj == null)
                MessageBox.Show(windowType.FullName + "没有不带参数的构造器");
            else
            {
                CreateWaitDialog("正在查询...", "请稍等", new Size(160, 50));

                Form ret = constructorInfoObj.Invoke(null) as Form;

                CloseWaitDialog();

                if (isDialog)
                    ret.ShowDialog();
                else
                {
                    ret.MdiParent = this;
                    ret.Show();
                }
            }
        }

        #region ShowWindow

        public Form ShowWindow(Type windowType, bool isDialog, object[] parameters)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child.GetType() == windowType && !child.IsDisposed)
                {
                    object[] tag = child.Tag as object[];
                    if (tag == null || parameters == null)
                    {
                        if (tag == null && parameters == null)
                        {
                            child.Activate();
                            child.Show();
                            return child;
                        }
                    }
                    else
                    {
                        if (tag.Length == parameters.Length)
                        {
                            bool isSame = true;
                            for (int i = 0; i < tag.Length; i++)
                            {
                                if (tag[i] != parameters[i])
                                {
                                    isSame = false;
                                    break;
                                }
                            }
                            if (isSame)
                            {
                                child.Activate();
                                child.Show();
                                return child;
                            }
                        }
                    }
                }
            }

            Type[] types = Type.EmptyTypes;
            if (parameters != null)
            {
                types = new Type[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    types[i] = parameters[i].GetType();
                }
            }
            ConstructorInfo constructorInfoObj = windowType.GetConstructor(types);
            if (constructorInfoObj == null)
                MessageBox.Show(windowType.FullName + "指定参数的构造器");
            else
            {
                CreateWaitDialog("正在查询...", "请稍等", new Size(160, 50));

                Form ret = constructorInfoObj.Invoke(parameters) as Form;
                ret.Tag = parameters;

                CloseWaitDialog();

                if (isDialog)
                    ret.ShowDialog();
                else
                {
                    ret.MdiParent = this;
                    ret.Show();
                }
                return ret;
            }
            return null;
        }
        #endregion

        #endregion

        #region i录入_ItemClick

        private void i录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWindow(typeof(CompetingProductPriceInputForm), true);
            //ShowWindow(typeof(PhotoBrowerForm), false);            
        }
        #endregion

        #region i查询_ItemClick

        private void i查询_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWindow(typeof(CompetingProductPriceBrowerForm), false);
        }
        #endregion

        #region i竞品档期汇总表_ItemClick

        private void i竞品档期汇总表_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWindow(typeof(CompetingProductPromotionalActivitiesScheduleForm), false);
        }
        #endregion

        #region i竞品快讯明细表_ItemClick

        private void i竞品快讯明细表_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWindow(typeof(InterruptedRecordBrowerForm), false);
        }
        #endregion

        #region i促销活动统计表_ItemClick

        private void i促销活动统计表_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWindow(typeof(CompetingProductPromotionalActivitiesPivotGridForm), false);
        }
        #endregion

        #region i促销店次计表_ItemClick

        private void i促销店次计表_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWindow(typeof(CompetingProductPromotionalActivitiesPivotGrid2Form), false);
        }
        #endregion

        #region i验证录入_ItemClick

        private void i验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWindow(typeof(PhotoBrower4CheckForm), false);  
        }
        #endregion

        #region btn回收站_ItemClick

        private void btn回收站_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWindow(typeof(PhotoBrower4RecoverForm), false);
        }
        #endregion

        #region i薪酬体系_ItemClick

        private void i薪酬体系_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SalaryPlanTree), false);
        }
        #endregion

        #region i竞品快讯断档统计表_ItemClick

        private void i竞品快讯断档统计表_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWindow(typeof(InterruptedRecordPivotGridForm), false);
        }
        #endregion

        #region i缺少竞品明细表_ItemClick

        private void i缺少竞品明细表_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWindow(typeof(MissingCompetingProductDetail), false);
        }
        #endregion

        #region i采购任务单_ItemClick

        private void i采购任务单_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWindow(typeof(PurchaseTaskBrowerForm), false);
        }
        #endregion

        #region iUploadPhotos_ItemClick

        private void iUploadPhotos_ItemClick(object sender, ItemClickEventArgs e)
        {
            string url = "http://192.168.68.208:8110/?UserName=" + AccessController.CurrentUser.用户名;
            Process.Start("iexplore.exe", url);
        }
        #endregion

        #region btn新照片_ItemClick

        private void btn新照片_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowWindow(typeof(PhotoBrower4NewForm), false); 
        }
        #endregion

        #region btnChangePassword_ItemClick

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FormChangePassword pwdForm = new FormChangePassword())
            {
                pwdForm.ShowDialog();
            }
        }
        #endregion

        #region i工资标准_ItemClick

        private void i工资标准_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SalaryStandardTreeList), false);
        }
        #endregion

        #region i个人职级工资_ItemClick

        private void i个人职级工资_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PersonPayRateList), false);
        }
        #endregion

        #region i初次录入标准职级工资_ItemClick

        private void i初次录入标准职级工资_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateWaitDialog();

            PayRateInputForm form = new PayRateInputForm();
            form.是验证录入 = false;

            CloseWaitDialog();

            form.ShowDialog();
        }
        #endregion

        #region i验证录入标准职级工资_ItemClick

        private void i验证录入标准职级工资_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateWaitDialog();

            PayRateInputForm form = new PayRateInputForm();
            form.是验证录入 = true;

            CloseWaitDialog();

            form.ShowDialog();
        }
        #endregion

        #region i职级工资查询_ItemClick

        private void i职级工资查询_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateWaitDialog();

            StepPayRateView form = new StepPayRateView();
            CloseWaitDialog();

            form.ShowDialog();
        }
        #endregion

        #region i初次录入个人职级工资_ItemClick

        private void i初次录入个人职级工资_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditPersonPayRateForm), false);
        }
        #endregion

        #region i验证录入个人职级工资_ItemClick

        private void i验证录入个人职级工资_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditPersonPayRateForm4Check), false);
        }
        #endregion

        #region i调整个人职级工资顺序_ItemClick

        private void i调整个人职级工资顺序_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(AdjustPersonPayRateOrderForm), false);
        }
        #endregion

        #region i上表工资_ItemClick

        private void i上表工资_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PublicPayReportForm), false);
        }
        #endregion

        #region i上表分类明细_ItemClick

        #endregion

        #region i其它奖项_ItemClick

        private void i其它奖项_ItemClick(object sender, ItemClickEventArgs e)
        {
            OtherMoneyForm form = new OtherMoneyForm("其它奖项");
            form.ShowDialog();
        }
        #endregion

        #region i其它扣项_ItemClick

        private void i其它扣项_ItemClick(object sender, ItemClickEventArgs e)
        {
            OtherMoneyForm form = new OtherMoneyForm("其它扣项");
            form.ShowDialog();
        }
        #endregion

        #region i其它代垫费用_ItemClick

        private void i其它代垫费用_ItemClick(object sender, ItemClickEventArgs e)
        {
            OtherMoneyForm form = new OtherMoneyForm("代垫费用");
            form.ShowDialog();
        }
        #endregion

        #region i工资降级_ItemClick

        private void i工资降级_ItemClick(object sender, ItemClickEventArgs e)
        {
            OtherMoneyForm form = new OtherMoneyForm("工资降级");
            form.ShowDialog();
        }
        #endregion

        #region i导入其它奖扣_ItemClick

        private void i导入其它奖扣_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImportOtherMoneyForm form = new ImportOtherMoneyForm();
            form.ShowDialog();
        }
        #endregion

        #region i工资系数浏览_ItemClick

        private void i工资系数浏览_ItemClick(object sender, ItemClickEventArgs e)
        {
            EmpPayRateForm form = new EmpPayRateForm();
            form.ShowDialog();
        }
        #endregion

        #region i工资系数导入_ItemClick

        private void i工资系数导入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImportEmpPayRateForm form = new ImportEmpPayRateForm();
            form.ShowDialog();
        }
        #endregion

        #region i工资审批表_ItemClick

        private void i工资审批表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PayReportForm), false);
        }

        #endregion

        #region i工资抽查审核_ItemClick

        private void i工资抽查审核_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PayCheckForm), false);
        }
        #endregion

        #region i工资报盘表_ItemClick

        private void i工资报盘表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PayBankReportForm), false);
        }
        #endregion

        #region i工资发放表_ItemClick

        private void i工资发放表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PayBankDetailReportForm), false);
        }
        #endregion

        #region i工资汇总表_ItemClick

        private void i工资汇总表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PrivateSalaryCaluDeptReportForm), false);
        }
        #endregion

        #region i纳税申报表_ItemClick

        private void i纳税申报表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(RatePayingDeclarationReportForm), false);
        }
        #endregion

        #region i工资发放审核表_ItemClick

        private void i工资发放审核表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(AuditingPayReportForm), false);
        }
        #endregion

        #region i封闭工资计算表_ItemClick

        private void i封闭工资计算表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PrivateSalaryPayBankDetailReportForm), false);
        }
        #endregion

        private void i个人所得税_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void i数据库配置_ItemClick(object sender, ItemClickEventArgs e)
        {
            DatabaseConfig dbConfig = new DatabaseConfig();
            dbConfig.ShowDialog();
        }

        private void i封闭工资结构_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SalaryTreeForm), false);
        }

        private void i封闭工资标准_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PrivateSalaryTreeView), false);
        }

        private void i员工工资职级初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditEmployeeSalaryStepForm), false);
        }

        private void i员工工资职级验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditEmployeeSalaryStepForm4Check), false);
        }

        private void i员工工资职级查询_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EmployeeSalaryStepList), false);
        }

        private void i工资表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(AuditingPayDeptReportForm), false);
        }

        private void i封闭工资发放清单_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PrivateSalaryPayItemsForm), false);
        }

        private void i报销标准初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditReimbursementStandardForm), false);
        }

        private void i报销标准验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditReimbursementStandardForm4Check), false);
        }

        private void i报销标准_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(ReimbursementStandardList), false);
        }

        private void i查询绩效工资_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PerformanceSalaryList), false);
        }

        private void i绩效工资初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditPerformanceSalaryForm), false);
        }

        private void i绩效工资验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditPerformanceSalaryForm4Check), false);
        }

        private void i报销初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditPersonReimbursementForm), false);
        }

        private void i报销验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditPersonReimbursementForm4Check), false);
        }

        private void i报销记录_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PersonReimbursementList), false);
        }

        private void i查询执行绩效工资_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EffectivePerformanceSalaryList), false);
        }

        private void i执行绩效工资初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditEffectivePerformanceSalaryForm), false);
        }

        private void i执行绩效工资验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditEffectivePerformanceSalaryForm4Check), false);
        }

        private void i借款记录_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PersonBorrowList), false);
        }

        private void i借款初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditPersonBorrowForm), false);
        }

        private void i借款验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditPersonBorrowForm4Check), false);
        }

        private void i还款记录_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(PersonRepaymentList), false);
        }

        private void i薪酬结构及标准明细_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SalaryMonthReportForm), false);
        }

        private void i薪酬计算表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SalaryCaluReportForm), false);
        }

        private void i部门体系_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(ManageDeptSystem), false);
        }

        private void i销售公司部门薪酬统计表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SaleCompanySalaryCountForm), false);
        }

        private void i按省办薪酬统计_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SaleCompanySalaryCount3Form), false);
        }

        private void i按部门薪酬统计_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SaleCompanySalaryCount2Form), false);
        }

        private void i部门薪酬统计表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(CompanySalaryCountForm), false);
        }

        private void i职务薪酬统计表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(CompanySalaryJobCounterForm), false);
        }

        private void i员工工资标准_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(QueryEmployeePayInfoForm), false);
        }

        private void i职等配置_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(LevelConfigForm), false);
        }

        private void i权限查询_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditEmployeeQueryPowerList), false);
        }

        private void i查询权限初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditEmployeeQueryPowerForm), false);
        }

        private void i查询权限验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditEmployeeQueryPowerForm4Check), false);
        }

        private void i准入电脑_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditAuthorizeComputerForm), false);
        }

        private void i正常工资薪金_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(NormalSalaryList), false);
        }

        private void i职级工资初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectCompanyForm form = new SelectCompanyForm("录入职级及职级工资");
            form.ShowDialog();
        }

        private void page职等职级月薪标准_CaptionButtonClick(object sender, RibbonPageGroupEventArgs e)
        {
            ShowWindow(typeof(SelectCompanyForm), true);
        }

        private void i管理人员执行月薪_CaptionButtonClick(object sender, RibbonPageGroupEventArgs e)
        {
            ShowWindow(typeof(SelectCompanyForm), true);
        }

        private void i职级月薪标准表_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectCompanyForm form = new SelectCompanyForm("查看各职等职级月薪执行标准");
            form.ShowDialog();
        }

        private void i录入各职等等管理人员薪酬执行明细_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectCompanyForm form = new SelectCompanyForm("录入各职等等管理人员薪酬执行明细");
            form.ShowDialog();
        }

        private void i查看各职等管理人员薪酬执行明细_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectCompanyForm form = new SelectCompanyForm("查看各职等管理人员薪酬执行明细");
            form.ShowDialog();
        }

        private void i职等管理_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectCompanyForm form = new SelectCompanyForm("职等管理");
            form.ShowDialog();
        }

        private void i录入异动人员工资_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectCompanyForm form = new SelectCompanyForm("录入异动人员薪酬执行明细");
            form.ShowDialog();
        }

        private void i基本信息录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            IndexForm form = new IndexForm("录入管培生基本信息");
            form.ShowDialog();
        }

        private void i专业属性确认_ItemClick(object sender, ItemClickEventArgs e)
        {
            IndexForm form = new IndexForm("专业属性确认");
            form.ShowDialog();
        }

        private void i工资增幅表_ItemClick(object sender, ItemClickEventArgs e)
        {
            IndexForm form = new IndexForm("录入提资及增幅计划");
            form.ShowDialog();

            //ManagementTraineePayRiseStandardInput a = ManagementTraineePayRiseStandardInput.GetManagementTraineePayRiseStandardInput(new Guid("9ea4f9cb-a83a-4b72-a3c6-5eca9dd7a2f1"));
            //ManagementTraineePayStandard.CreatePayStandards("A202405", 2017);
            //ManagementTraineePayStandard.CreatePayStandards("A202405", 2018);
            //ManagementTraineePayStandard.CreatePayStandards("A202405", 2019);
            //ManagementTraineePayStandard.CreatePayStandards("A202405", 2020);
            //ManagementTraineePayStandard.CreatePayStandards("A202405", 2021);
            //ManagementTraineePayStandard.CreatePayStandards("A202405", 2022);
            //ManagementTraineePayStandard.CreatePayStandards("A202405", 2023);

            //List<ManagementTraineeSalary> list = ManagementTraineeSalary.GetMonthlySalaryList("A202405", 2023);
            //List<ManagementTraineeSalary> list = ManagementTraineeSalary.GetQuarterSalaryList("A202405", 2020);
        }

        private void i薪酬结构初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditSalaryStructureListForm),false, new object[] { false });
        }

        private void i薪酬结构验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditSalaryStructureListForm), false, new object[] { true });
        }

        private void i工资借款初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditWageLoanListForm), false, new object[] { false });
        }

        private void i工资借款验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditWageLoanListForm), false, new object[] { true });
        }

        private void i报账工资初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditRembursementSalaryListForm), false, new object[] { false });
        }

        private void i报账工资验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditRembursementSalaryListForm), false, new object[] { true });
        }

        private void i薪酬结构查询_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SearchSalaryStructureForm), false, null); 
        }

        private void i工资借款查询_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SearchWageLoanForm), false, null); 
        }

        private void i查询报账工资_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SearchRembursementSalaryForm), false, null); 
        }

        private void i实际报账明细_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(RembursementSalaryCalculatorForm), true, null); 
        }

        private void i实际报账工资初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditMonthlyRembursementSalaryItemListForm), false, new object[] { false });
        }

        private void i实际报账工资验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditMonthlyRembursementSalaryItemListForm), false, new object[] { true });
        }

        private void i实际工资借款初次录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditMonthlyWageLoanItemListForm), false, new object[] { false });
        }

        private void i实际工资借款验证录入_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(EditMonthlyWageLoanItemListForm), false, new object[] { true });
        }

        private void i实际借款明细_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(WageLoanCalculatorForm), true, null);
        }

        private void i薪酬结构表_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectCompanyForm form = new SelectCompanyForm("查看各职等人员薪酬结构明细表");
            form.ShowDialog();
        }

        private void i工资借款明细表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(SearchWageLoanForm), false, null);
        }

        private void i报账工资明细表_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(RembursementSalaryListForm), false, null);
        }

        private void i薪酬计划表_ItemClick(object sender, ItemClickEventArgs e)
        {
            IndexForm form = new IndexForm("薪酬计划表");
            form.ShowDialog();
        }

        private void page管培生资料维护_CaptionButtonClick(object sender, RibbonPageGroupEventArgs e)
        {
            ShowWindow(typeof(TraineeFunctionForm), true);
        }

        private void i录入提资表_ItemClick(object sender, ItemClickEventArgs e)
        {
            IndexForm form = new IndexForm("录入个人提资表");
            form.ShowDialog(); 
        }

        private void i软件人员名单_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeveloperConfig dbConfig = new DeveloperConfig();
            dbConfig.ShowDialog(); 
        }

        private void i管培生模块功能目录_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowWindow(typeof(TraineeFunctionForm), true);
        }
    }
}
