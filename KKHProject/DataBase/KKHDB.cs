namespace KKHProject.DataBase
{
    using System.Data.Entity;

    public partial class KKHDB : DbContext
    {
        public KKHDB()
            : base("name=KKHDB")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Cloht> Clohts { get; set; }
        public virtual DbSet<Container> Containers { get; set; }
        public virtual DbSet<Furniture> Furnitures { get; set; }
        public virtual DbSet<ObjectsContainer> ObjectsContainers { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShipmentObject> ShipmentObjects { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Warehouses)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.Id_city)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cloht>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Cloht>()
                .HasMany(e => e.ObjectsContainers)
                .WithOptional(e => e.Cloht)
                .HasForeignKey(e => e.id_cloth);

            modelBuilder.Entity<Cloht>()
                .HasMany(e => e.ShipmentObjects)
                .WithOptional(e => e.Cloht)
                .HasForeignKey(e => e.id_cloht);

            modelBuilder.Entity<Container>()
                .HasMany(e => e.ObjectsContainers)
                .WithRequired(e => e.Container)
                .HasForeignKey(e => e.id_containers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Furniture>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Furniture>()
                .Property(e => e.Descriptions)
                .IsUnicode(false);

            modelBuilder.Entity<Furniture>()
                .HasMany(e => e.ObjectsContainers)
                .WithOptional(e => e.Furniture)
                .HasForeignKey(e => e.id_furniture);

            modelBuilder.Entity<Furniture>()
                .HasMany(e => e.ShipmentObjects)
                .WithOptional(e => e.Furniture)
                .HasForeignKey(e => e.id_furniture);

            modelBuilder.Entity<Provider>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .HasMany(e => e.Shipments)
                .WithOptional(e => e.Provider)
                .HasForeignKey(e => e.id_provider);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shipment>()
                .Property(e => e.Descriptions)
                .IsUnicode(false);

            modelBuilder.Entity<Shipment>()
                .HasMany(e => e.ShipmentObjects)
                .WithRequired(e => e.Shipment)
                .HasForeignKey(e => e.id_shipment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Shipments)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.id_status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Providers)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.Containers)
                .WithRequired(e => e.Warehouse)
                .HasForeignKey(e => e.id_warehouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.Shipments)
                .WithRequired(e => e.Warehouse)
                .HasForeignKey(e => e.id_warehouse)
                .WillCascadeOnDelete(false);
        }
    }
}
