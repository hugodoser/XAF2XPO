﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Web;
using DevExpress.ExpressApp.Web.Editors;

namespace XAF2XPO.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class WebNullTextEditorController : ViewController
    {
        public WebNullTextEditorController()
        {
            InitializeComponent();
            RegisterActions(components);
        }
        private void InitNullText(WebPropertyEditor propertyEditor)
        {
            if (propertyEditor.ViewEditMode == DevExpress.ExpressApp.Editors.ViewEditMode.Edit)
            {
                ((ASPxDateEdit)propertyEditor.Editor).NullText = CaptionHelper.NullValueText;
            }
        }
        private void propertyEditor_ControlCreated(object sender, EventArgs e)
        {
            InitNullText((WebPropertyEditor)sender);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            WebPropertyEditor propertyEditor = ((DetailView)View).FindItem("Anniversary") as WebPropertyEditor;
            if (propertyEditor != null)
            {
                if (propertyEditor.Control != null)
                {
                    InitNullText(propertyEditor);
                }
                else
                {
                    propertyEditor.ControlCreated += new EventHandler<EventArgs>(propertyEditor_ControlCreated);
                }
            }
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ViewItem propertyEditor = ((DetailView)View).FindItem("Anniversary");
            if (propertyEditor != null)
            {
                propertyEditor.ControlCreated -= new EventHandler<EventArgs>(propertyEditor_ControlCreated);
            }
        }
    }
}
