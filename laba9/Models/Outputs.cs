//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace laba9.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Outputs
    {
        public int o_id { get; set; }
        public int R_id { get; set; }
        public int B_id { get; set; }
        public DateTime o_dt_out { get; set; }
        public DateTime o_dt_in { get; set; }
    
        public virtual Outputs Outputs1 { get; set; }
        public virtual Outputs Outputs2 { get; set; }
    }
}
