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
    
    public partial class Awarding
    {
        public int ID { get; set; }
        public int ID_RegistrationCompetition { get; set; }
        public int Place { get; set; }
        public decimal Result { get; set; }
    
        public virtual RegistrationCompetition RegistrationCompetition { get; set; }
    }
}