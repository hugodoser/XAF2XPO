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

using XAF2XPO.Module.BusinessObjects;

namespace XAF2XPO.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FilterListViewController : ViewController
    {
        public FilterListViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }

        private void FilterListViewController_Activated_1(object sender, EventArgs e)
        {
            if ((View is ListView) & (View.ObjectTypeInfo.Type == typeof(Contact)))
            {
                ((ListView)View).CollectionSource.Criteria["Filter1"] = new BinaryOperator(
                   "Position.Title", "Developer", BinaryOperatorType.Equal);
            }
        }
    }
}
