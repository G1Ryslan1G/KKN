namespace KKHProject.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Shipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipment()
        {
            ShipmentObjects = new HashSet<ShipmentObject>();
        }

        public int Id { get; set; }

        public int? id_provider { get; set; }

        public int id_status { get; set; }

        public int id_warehouse { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateChec { get; set; }

        public double CostSupply { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Descriptions { get; set; }

        public virtual Provider Provider { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShipmentObject> ShipmentObjects { get; set; }

        public virtual Status Status { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
