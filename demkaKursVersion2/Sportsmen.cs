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
    
    public partial class Sportsmen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sportsmen()
        {
            this.RegistrationCompetition = new HashSet<RegistrationCompetition>();
            this.TrainerSportsmen = new HashSet<TrainerSportsmen>();
            this.TypesSports_Sportsmen = new HashSet<TypesSports_Sportsmen>();
        }
    
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime? Date_birhtday { get; set; }
        public Nullable<int> Sport_Club_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrationCompetition> RegistrationCompetition { get; set; }
        public virtual SportClub SportClub { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainerSportsmen> TrainerSportsmen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypesSports_Sportsmen> TypesSports_Sportsmen { get; set; }
    }
}
