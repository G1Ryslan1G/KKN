namespace KKHProject.DataBase
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Furniture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Furniture()
        {
            ObjectsContainers = new HashSet<ObjectsContainer>();
            ShipmentObjects = new HashSet<ShipmentObject>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Descriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectsContainer> ObjectsContainers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShipmentObject> ShipmentObjects { get; set; }
    }
}
