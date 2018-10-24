﻿using System;
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
    [DefaultClassOptions, ImageName("BO_SaleItem")]
    public class Payment : BaseObject
    {
        public Payment(Session session) : base(session) { }
        private double rate;
        public double Rate
        {
            get
            {
                return rate;
            }
            set
            {
                if (SetPropertyValue("Rate", ref rate, value))
                    OnChanged("Amount");
            }
        }
        private double hours;
        public double Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (SetPropertyValue("Hours", ref hours, value))
                    OnChanged("Amount");
            }
        }
        [PersistentAlias("Rate * Hours")]
        public double Amount
        {
            get
            {
                object tempObject = EvaluateAlias("Amount");
                if (tempObject != null)
                {
                    return (double)tempObject;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}