//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class FormFactor
    {
        public int ID { get; set; }
        public string Title { get; set; }
    
        public virtual MotherBoard MotherBoard { get; set; }
        public virtual TowerPC TowerPC { get; set; }
    }
}
