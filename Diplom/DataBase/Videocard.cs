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
    
    public partial class Videocard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Videocard()
        {
            this.PC = new HashSet<PC>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public Nullable<int> VideoRamID { get; set; }
        public Nullable<int> GPUID { get; set; }
        public Nullable<int> ManufacturerGPUID { get; set; }
        public Nullable<int> QuantityVentilator { get; set; }
        public Nullable<int> MemoryBusWidthID { get; set; }
        public Nullable<int> PCI_E_ID { get; set; }
        public Nullable<int> TypeOfMemoryID { get; set; }
        public Nullable<int> ManufacturerID { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<int> EnergyConsumption { get; set; }
        public string PhotoLink { get; set; }
    
        public virtual GPU GPU { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ManufacturerGPU ManufacturerGPU { get; set; }
        public virtual MemoryBusWidth MemoryBusWidth { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PC> PC { get; set; }
        public virtual PCI_E PCI_E { get; set; }
        public virtual TypeOfMemory TypeOfMemory { get; set; }
        public virtual VideoRam VideoRam { get; set; }
    }
}
