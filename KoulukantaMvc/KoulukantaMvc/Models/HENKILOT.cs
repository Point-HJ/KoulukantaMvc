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
    
    public partial class HENKILOT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HENKILOT()
        {
            this.TUNNIT = new HashSet<TUNNIT>();
        }
    
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Osoite { get; set; }
        public string Postinumero { get; set; }
        public string Sähköposti { get; set; }
        public string Puhelin { get; set; }
        public int HenkiloID { get; set; }
        public Nullable<int> Esimies { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUNNIT> TUNNIT { get; set; }
    }
}
