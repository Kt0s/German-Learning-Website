//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GermanLearningWebsite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Words
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Article { get; set; }
        public Nullable<System.DateTime> LastUse { get; set; }
        public int TimesUsed { get; set; }
        public int TimesRight { get; set; }
        public int TimesWrong { get; set; }
        public bool IsActiveWord { get; set; }
        public string Translation { get; set; }
    }
}
