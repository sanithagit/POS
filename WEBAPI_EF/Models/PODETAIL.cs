//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBAPI_EF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PODETAIL
    {
        public int PONO { get; set; }
        public int ITCODE { get; set; }
        public Nullable<int> QTY { get; set; }
    
        public virtual ITEM ITEM { get; set; }
        public virtual POMASTER POMASTER { get; set; }
    }
}