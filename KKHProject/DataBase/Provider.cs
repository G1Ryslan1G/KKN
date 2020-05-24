namespace KKHProject.DataBase
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Provider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Provider()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int Id { get; set; }

        public int id_user { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(13)]
        public string Phone { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
