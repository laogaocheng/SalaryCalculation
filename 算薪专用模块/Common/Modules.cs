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
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace Hwagain.Common
{
    public class ModuleInfo
    {
        ModuleBase module;
        Type moduleType;
        string fName, fDescription;
        public ModuleInfo(string name, Type moduleType, string fDescription)
        {
            if (!moduleType.IsSubclassOf(typeof(ModuleBase)))
                throw new ArgumentException("Module class should be derived from ModuleBase");

            this.moduleType = moduleType;
            this.fDescription = fDescription;
            this.module = null;
            this.fName = name;
        }
        public ModuleBase Module
        {
            get
            {
                if (module == null)
                    module = CreateModule(moduleType);

                return module;
            }
        }
        public string Name
        {
            get
            {
                return this.fName;
            }
        }
        public void Hide()
        {
            if (module != null)
                module.Visible = false;
        }
        private ModuleBase CreateModule(Type moduleType)
        {
            if (this.module == null)
            {
                ConstructorInfo constructorInfoObj = moduleType.GetConstructor(Type.EmptyTypes);
                if (constructorInfoObj == null)
                    throw new ApplicationException(moduleType.FullName +
                    " doesn't have public constructor with empty parameters");

                ModuleBase ret = constructorInfoObj.Invoke(null) as ModuleBase;

                return ret;
            }
            return module;
        }
    }
    [ListBindable(false)]
    public class ModuleInfoCollection : CollectionBase
    {
        ModuleBase currentModule;
        public ModuleInfoCollection()
            : base()
        {
            this.currentModule = null;
        }
        public ModuleInfo this[int index]
        {
            get
            {
                return List[index] as ModuleInfo;
            }
        }

        public void Add(string fName, Type fType, string fDescription)
        {
            ModuleInfo item = new ModuleInfo(fName, fType, fDescription);
            Add(item);
        }
        public void SetCurrentModule(ModuleBase module)
        {
            currentModule = module;
        }
        public void ShowModule(ModuleBase module, Control container)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            
            if (container.Parent != null)
                container.Parent.SuspendLayout();

            container.SuspendLayout();

            try
            {
                if (module == currentModule)
                    return;

                if (currentModule != null)
                    currentModule.Hide();

                if (module == null)
                    return;

                Control fModule = module as Control;
                fModule.Bounds = container.DisplayRectangle;

                fModule.Visible = false;
                fModule.Parent = container;
                container.Controls.Add(fModule);
                fModule.Dock = DockStyle.Fill;
                fModule.Visible = true;
                SetCurrentModule(module);
            }
            finally
            {
                container.ResumeLayout(true);
                if (container.Parent != null)
                    container.Parent.ResumeLayout(true);
                Cursor.Current = currentCursor;
            }
        }
        public ModuleBase CurrentModule
        {
            get
            {
                return currentModule;
            }
        }
        void Add(ModuleInfo value)
        {
            if (List.IndexOf(value) < 0)
                List.Add(value);
        }
        public ModuleInfo this[string fName]
        {
            get
            {
                foreach (ModuleInfo info in this)
                    if (info.Name.Equals(fName))
                        return info;
                return null;
            }
        }
    }
}
