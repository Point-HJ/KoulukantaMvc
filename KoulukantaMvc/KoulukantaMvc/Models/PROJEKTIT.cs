//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KoulukantaMvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROJEKTIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROJEKTIT()
        {
            this.TUNNIT = new HashSet<TUNNIT>();
        }
    
        public int ProjektiID { get; set; }
        public string Nimi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUNNIT> TUNNIT { get; set; }
    }
}
