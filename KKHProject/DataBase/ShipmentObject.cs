namespace KKHProject.DataBase
{
    public partial class ShipmentObject
    {
        public int Id { get; set; }

        public int id_shipment { get; set; }

        public int? id_cloht { get; set; }

        public int? CountCloht { get; set; }

        public int? id_furniture { get; set; }

        public int? CountFurniture { get; set; }

        public virtual Cloht Cloht { get; set; }

        public virtual Furniture Furniture { get; set; }

        public virtual Shipment Shipment { get; set; }

        public virtual object Object 
        { 
            get 
            {
                if (id_cloht != null)
                    return Cloht;
                else
                    return Furniture;
            }
        }

        public virtual int Count
        {
            get
            {
                if (id_cloht != null)
                    return CountCloht.Value;
                else
                    return CountFurniture.Value;
            }
        }
    }
}
