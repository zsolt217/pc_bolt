//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Szt2_projekt
{
    using System;
    using System.Collections.Generic;
    
    public partial class HAZ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HAZ()
        {
            this.RENDELESEK = new HashSet<RENDELESEK>();
        }
    
        public decimal HAZ_ID { get; set; }
        public string TIPUSSZAM { get; set; }
        public string MERETSZABVANY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RENDELESEK> RENDELESEK { get; set; }
    }
}
