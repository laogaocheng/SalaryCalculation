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
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Drawing;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Frames;

namespace Hwagain.Common
{
    public class ApplicationCaptionEx : ApplicationCaption
    {
        Color lightColor = Color.FromArgb(220, 220, 220), darkColor = Color.FromArgb(54, 54, 54);
        public ApplicationCaptionEx()
            : base()
        {
            ForeColor = darkColor;
            this.LookAndFeel.StyleChanged += new EventHandler(LookAndFeel_StyleChanged);
            CheckForeColor();
            ShowLogo(false);
        }
        void LookAndFeel_StyleChanged(object sender, EventArgs e)
        {
            CheckForeColor();
        }
        Color GetDefaultColor()
        {
            if (FrameHelper.IsDarkSkin(this.LookAndFeel))
                return lightColor;
            return darkColor;
        }
        void CheckForeColor()
        {
            if (ForeColor == darkColor || ForeColor == lightColor)
                ForeColor = GetDefaultColor();
        }
        public override void ResetForeColor()
        {
            ForeColor = GetDefaultColor();
        }
        protected override bool ShouldSerializeForeColor()
        {
            return ForeColor != GetDefaultColor();
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor2
        {
            get
            {
                return base.BackColor2;
            }
            set
            {
            }
        }
        static Font defaultFont3 = null;
        static Font defaultFont4 = null;
        static Font DefaultFont3
        {
            get
            {
                if (defaultFont3 == null)
                    defaultFont3 = CreateDefaultFont("Tahoma", 25, FontStyle.Regular);
                return defaultFont3;
            }
        }
        static Font DefaultFont4
        {
            get
            {
                if (defaultFont4 == null)
                    defaultFont4 = CreateDefaultFont("Tahoma", 12, FontStyle.Regular);
                return defaultFont4;
            }
        }
        protected override bool ShouldSerializeFont()
        {
            return !Font.Equals(DefaultFont3);
        }
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                if (value == null)
                    value = DefaultFont3;
                base.Font = value;
                BeginResize();
            }
        }
        protected override bool ShouldSerializeFont2()
        {
            return !Font2.Equals(DefaultFont4);
        }
        public override Font Font2
        {
            get
            {
                return base.Font2;
            }
            set
            {
                if (value == null)
                    value = DefaultFont4;
                base.Font2 = value;
                BeginResize();
            }
        }
        protected override int deltaX
        {
            get
            {
                return 15;
            }
        }
        protected override int CaptionFontHeight
        {
            get
            {
                return Font.Height + 6;
            }
        }

        protected override void FillBackground(GraphicsCache cache, Rectangle r)
        {
            if (LookAndFeel.ActiveLookAndFeel.Style == DevExpress.LookAndFeel.LookAndFeelStyle.Skin)
            {
                SkinElement element = CommonSkins.GetSkin(LookAndFeel)[CommonSkins.SkinForm];
                SkinElementInfo info = new SkinElementInfo(element, r);
                ObjectPainter.DrawObject(cache, SkinElementPainter.Default, info);
            }
            else
            {
                cache.Graphics.FillRectangle(SystemBrushes.Control, r);
            }
        }
        string GetText2()
        {
            if (Text2.Length > 0 && Text2[0] != '(')
                return string.Format("({0})", Text2);
            return Text2;
        }
        protected override void DrawCaptions(GraphicsCache cache, Rectangle r, int textLeft)
        {
            using (SolidBrush foreBrush = new SolidBrush(this.ForeColor))
            {
                int textTop = (this.Height - Font.Height) / 2 - 1;
                r = new Rectangle(textLeft, textTop, this.Width - textLeft - deltaX, Font.Height);
                cache.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                if (r.Width > 0)
                    cache.Graphics.DrawString(Text, this.Font, foreBrush, r, TextStringFormat);
                int textWidth1 = (int)cache.Graphics.MeasureString(Text, this.Font, new PointF(0, 0), TextStringFormat).Width;
                r = new Rectangle(textLeft + textWidth1, textTop + (Font.Height - Font2.Height) - 5, this.Width - textLeft - DXLogo.Width - deltaX - textWidth1, Font2.Height);
                if (r.Width > 0)
                    cache.Graphics.DrawString(GetText2(), this.Font2, foreBrush, r, TextStringFormat);
            }
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = GetNewText(value);
                base.Text2 = GetNewText2(value);
            }
        }
        string GetNewText2(string value)
        {
            int n = value.IndexOf('(');
            if (n == -1)
                return "";
            return value.Substring(n);
        }
        string GetNewText(string value)
        {
            int n = value.IndexOf('(');
            if (n == -1)
                return value;
            return value.Substring(0, n);
        }
    }
    public class NotePanelEx : NotePanel
    {
        public NotePanelEx()
            : base()
        {
            //ArrowImage = DevExpress.Utils.ResourceImageHelper.CreateImageFromResources("DevExpress.Utils.XtraFrames.description.png", typeof(NotePanelEx).Assembly);
        }
        protected override bool ShouldSerializeArrowImage()
        {
            return false;
        }
    }
}
