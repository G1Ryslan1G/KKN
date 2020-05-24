namespace KKHProject.DataBase
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ObjectsContainer")]
    public partial class ObjectsContainer
    {
        public int Id { get; set; }

        public int id_containers { get; set; }

        public int? id_cloth { get; set; }

        public int? id_furniture { get; set; }

        public int Count { get; set; }

        public virtual Cloht Cloht { get; set; }

        public virtual Container Container { get; set; }

        public virtual Furniture Furniture { get; set; }
    }
}
