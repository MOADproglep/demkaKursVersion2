//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace demkaKursVersion2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Infrastructure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Infrastructure()
        {
            this.Competitions = new HashSet<Competitions>();
            this.SpecificationsInfrastructure = new HashSet<SpecificationsInfrastructure>();
        }
    
        public int ID { get; set; }
        public int ID_TypeStructure { get; set; }
        public int ID_CItys { get; set; }
    
        public virtual Citys Citys { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Competitions> Competitions { get; set; }
        public virtual TypeStructure TypeStructure { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpecificationsInfrastructure> SpecificationsInfrastructure { get; set; }
    }
}
