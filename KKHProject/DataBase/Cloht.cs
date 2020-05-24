namespace KKHProject.DataBase
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cloht
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cloht()
        {
            ObjectsContainers = new HashSet<ObjectsContainer>();
            ShipmentObjects = new HashSet<ShipmentObject>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Volume { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectsContainer> ObjectsContainers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShipmentObject> ShipmentObjects { get; set; }
    }
}
