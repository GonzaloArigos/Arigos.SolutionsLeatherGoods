//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASF.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Setting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public System.DateTime LastChangeDate { get; set; }
        public string WebSiteName { get; set; }
        public string WebSiteUrl { get; set; }
        public string PageTitle { get; set; }
        public string AdminEmailAddress { get; set; }
        public string SMTP { get; set; }
        public string SMTPUsername { get; set; }
        public string SMTPPassword { get; set; }
        public string SMTPPort { get; set; }
        public Nullable<bool> SMTPEnableSSL { get; set; }
        public string Theme { get; set; }
        public int DefaultLanguageId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime ChangedOn { get; set; }
        public Nullable<int> ChangedBy { get; set; }
    }
}
