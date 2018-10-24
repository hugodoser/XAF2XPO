using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace XAF2XPO.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Custom("Caption", "Task")]
    public class DemoTask : Task
    {
        public DemoTask(Session session) : base(session) { }

        private Priority priority;
        public Priority Priority
        {
            get { return priority; }
            set
            {
                SetPropertyValue("Priority", ref priority, value);
            }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Priority = Priority.Normal;
        }

        [Association("Contact-DemoTask")]
        public XPCollection<Contact> Contacts
        {
            get
            {
                return GetCollection<Contact>("Contacts"); //Many
            }
        }
    }

    public enum Priority
    {
        Low = 0,
        Normal = 1,
        High = 2
    }
}