using System;
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

namespace XAF2XPO.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FindBySubjectController : ViewController
    {
        public FindBySubjectController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        
        private void FindBySubjectAction_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            string paramValue = e.ParameterCurrentValue as string;
            object obj = objectSpace.FindObject(((ListView)View).ObjectTypeInfo.Type,
                CriteriaOperator.Parse(string.Format("Contains([Subject], '{0}')", paramValue)));
            if (obj != null)
            {
                DetailView detailView = Application.CreateDetailView(objectSpace, obj);
                detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
                e.ShowViewParameters.CreatedView = detailView;
            }
        }
    }
}