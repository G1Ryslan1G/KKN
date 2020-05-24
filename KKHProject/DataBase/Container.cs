namespace KKHProject.DataBase
{
    using System.Collections.Generic;

    public partial class Container
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Container()
        {
            ObjectsContainers = new HashSet<ObjectsContainer>();
        }

        public int Id { get; set; }

        public int id_warehouse { get; set; }

        public int Number { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectsContainer> ObjectsContainers { get; set; }
    }
}
