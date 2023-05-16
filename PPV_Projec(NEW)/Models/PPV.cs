//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPV_Projec_NEW_.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PPV
    {
        public int id_ppv { get; set; }
        public string wo { get; set; }
        public string po { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<decimal> av_price { get; set; }
        public Nullable<decimal> new_price { get; set; }
        public Nullable<int> buyer { get; set; }
        public string reason { get; set; }
        public string times { get; set; }
        public Nullable<int> OtherChange { get; set; }
        public string elaborate { get; set; }
        public string leadtime { get; set; }
        public string explanation { get; set; }
        public Nullable<decimal> change_unit { get; set; }
        public Nullable<double> change_unit_perc { get; set; }
        public Nullable<decimal> current_total { get; set; }
        public Nullable<decimal> new_total { get; set; }
        public Nullable<decimal> total_increase { get; set; }
        public Nullable<int> first_auth { get; set; }
        public Nullable<int> last_auth { get; set; }
        public Nullable<System.DateTime> date_ppv { get; set; }
        public Nullable<System.DateTime> first_date { get; set; }
        public Nullable<System.DateTime> last_date { get; set; }
        public Nullable<bool> first_approval { get; set; }
        public Nullable<bool> last_approval { get; set; }
        public Nullable<int> pn { get; set; }
        public Nullable<int> client { get; set; }
        public Nullable<int> vendor { get; set; }
        public string first_note { get; set; }
        public string last_note { get; set; }
        public Nullable<bool> salesOrder { get; set; }
        public string salesOrder_num { get; set; }
        public string note { get; set; }
        public Nullable<bool> @void { get; set; }
        public Nullable<int> id_mfg { get; set; }
    
        public virtual Client Client1 { get; set; }
        public virtual MFG MFG { get; set; }
        public virtual PN PN1 { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
        public virtual user user2 { get; set; }
        public virtual Vendor Vendor1 { get; set; }
    }
}