#region Copyright (c) 2000-2009 Developer Express Inc.
/*
{*******************************************************************}
{                                                                   }
{       Developer Express .NET Component Library                    }
{                                        }
{                                                                   }
{       Copyright (c) 2000-2009 Developer Express Inc.              }
{       ALL RIGHTS RESERVED                                         }
{                                                                   }
{   The entire contents of this file is protected by U.S. and       }
{   International Copyright Laws. Unauthorized reproduction,        }
{   reverse-engineering, and distribution of all or any portion of  }
{   the code contained in this file is strictly prohibited and may  }
{   result in severe civil and criminal penalties and will be       }
{   prosecuted to the maximum extent possible under the law.        }
{                                                                   }
{   RESTRICTIONS                                                    }
{                                                                   }
{   THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES           }
{   ARE CONFIDENTIAL AND PROPRIETARY TRADE                          }
{   SECRETS OF DEVELOPER EXPRESS INC. THE REGISTERED DEVELOPER IS   }
{   LICENSED TO DISTRIBUTE THE PRODUCT AND ALL ACCOMPANYING .NET    }
{   CONTROLS AS PART OF AN EXECUTABLE PROGRAM ONLY.                 }
{                                                                   }
{   THE SOURCE CODE CONTAINED WITHIN THIS FILE AND ALL RELATED      }
{   FILES OR ANY PORTION OF ITS CONTENTS SHALL AT NO TIME BE        }
{   COPIED, TRANSFERRED, SOLD, DISTRIBUTED, OR OTHERWISE MADE       }
{   AVAILABLE TO OTHER INDIVIDUALS WITHOUT EXPRESS WRITTEN CONSENT  }
{   AND PERMISSION FROM DEVELOPER EXPRESS INC.                      }
{                                                                   }
{   CONSULT THE END USER LICENSE AGREEMENT FOR INFORMATION ON       }
{   ADDITIONAL RESTRICTIONS.                                        }
{                                                                   }
{*******************************************************************}
*/
#endregion

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Hwagain.Common
{
    [ToolboxItem(false)]
    public class ModuleBase : DevExpress.XtraEditors.XtraUserControl
    {
        private System.ComponentModel.Container components = null;
        public ModuleBase()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "ModuleBase";
            this.Size = new System.Drawing.Size(784, 432);
        }
        #endregion

        bool setManager = false;
        public void AddMenuManager(BarManager manager)
        {
            if (setManager)
                return;
            AddManager(this.Controls, manager);
            setManager = true;
        }
        void AddManager(ControlCollection collection, BarManager manager)
        {
            foreach (Control ctrl in collection)
            {
                SetControlManager(ctrl, manager);
                AddManager(ctrl.Controls, manager);
            }
        }
        protected virtual void SetControlManager(Control ctrl, BarManager manager)
        {
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.VisibleChanged += new EventHandler(OnVisibleChanged);
        }
        protected virtual void OnVisibleChanged(object sender, EventArgs e)
        {
            DoVisibleChanged(this.Visible);
        }
        protected virtual void DoVisibleChanged(bool visible)
        {
        }
    }
}
