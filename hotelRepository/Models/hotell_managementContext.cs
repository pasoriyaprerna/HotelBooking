using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace hotelRepository.Models
{
    public partial class hotell_managementContext : DbContext
    {
        public hotell_managementContext()
        {
        }

        public hotell_managementContext(DbContextOptions<hotell_managementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustInfo> CustInfos { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<RoomInformation> RoomInformations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB;Initial Catalog=hotell_management;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustInfo>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Cust_Inf__CD64CFDDE7AA7CE5");

                entity.ToTable("Cust_Info");

                entity.Property(e => e.CustomerId).HasColumnName("customer_ID");

                entity.Property(e => e.Custfname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("custfname");

                entity.Property(e => e.Custlname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("custlname");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employee_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.ContactAdd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contact_add");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.Property(e => e.JobDepartment)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("job_department");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lname");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.HotelCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.HotelCode)
                    .HasConstraintName("FK_Employees_Hotel");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(e => e.HotelCode)
                    .HasName("PK__Hotel__175CAD5972077EEB");

                entity.ToTable("Hotel");

                entity.Property(e => e.HotelCode).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ClassName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.HotelName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StarRating).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_ID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CheckIn)
                    .HasColumnType("date")
                    .HasColumnName("Check_IN");

                entity.Property(e => e.CheckOut)
                    .HasColumnType("date")
                    .HasColumnName("Check_Out");

                entity.Property(e => e.CustomerId).HasColumnName("customer_ID");

                entity.Property(e => e.RoomId).HasColumnName("room_ID");
            });

            modelBuilder.Entity<RoomInformation>(entity =>
            {
                entity.HasKey(e => e.RoomId)
                    .HasName("PK__Room_Inf__19645EB2CC597D38");

                entity.ToTable("Room_Information");

                entity.Property(e => e.RoomId)
                    .ValueGeneratedNever()
                    .HasColumnName("room_ID");

                entity.Property(e => e.Availability)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfRooms).HasColumnName("Number_of_rooms");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.HotelCodeNavigation)
                    .WithMany(p => p.RoomInformations)
                    .HasForeignKey(d => d.HotelCode)
                    .HasConstraintName("FK_Room_Information_Hotel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
