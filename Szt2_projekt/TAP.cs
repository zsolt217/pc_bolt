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
    
    public partial class TAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAP()
        {
            this.RENDELESEK = new HashSet<RENDELESEK>();
            this.KEDVENCEK = new HashSet<KEDVENCEK>();
        }
    
        public decimal TAP_ID { get; set; }
        public string TIPUSSZAM { get; set; }
        public decimal TELJESITMENY { get; set; }
        public decimal AR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RENDELESEK> RENDELESEK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KEDVENCEK> KEDVENCEK { get; set; }
        public override string ToString()
        {
            return TIPUSSZAM + " (" + TELJESITMENY + "W)";
        }
    }
}
