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
    public class PortfolioFileData : FileAttachmentBase
    {
        public PortfolioFileData(Session session) : base(session) { }
        protected Resume resume;
        [Persistent, Association("Resume-PortfolioFileData")]
        public Resume Resume
        {
            get { return resume; }
            set
            {
                SetPropertyValue("Resume", ref resume, value);
            }
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            documentType = DocumentType.Unknown;
        }
        private DocumentType documentType;
        public DocumentType DocumentType
        {
            get { return documentType; }
            set { SetPropertyValue("DocumentType", ref documentType, value); }
        }
    }
    public enum DocumentType
    {
        SourceCode = 1, Tests = 2, Documentation = 3,
        Diagrams = 4, ScreenShots = 5, Unknown = 6
    };
}