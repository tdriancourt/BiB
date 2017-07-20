using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bib.Domain.Model
{
    public partial class bibContext : DbContext
    {
        public virtual DbSet<Acl> Acl { get; set; }
        public virtual DbSet<Borrow> Borrow { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<Medium> Medium { get; set; }
        public virtual DbSet<Reader> Reader { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
        public virtual DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlite(@"DataSource=C:\Workspaces\BiB\data\bib.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acl>(entity =>
            {
                entity.ToTable("acl");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint");

                entity.Property(e => e.CanAddMedia).HasColumnType("tinyint");

                entity.Property(e => e.CanAddReaders).HasColumnType("tinyint");

                entity.Property(e => e.CanAddUserGroups).HasColumnType("tinyint");

                entity.Property(e => e.CanAddUsers).HasColumnType("tinyint");

                entity.Property(e => e.CanModifyMedia).HasColumnType("tinyint");

                entity.Property(e => e.CanModifyReaders).HasColumnType("tinyint");

                entity.Property(e => e.CanModifyUserGroups).HasColumnType("tinyint");

                entity.Property(e => e.CanModifyUsers).HasColumnType("tinyint");

                entity.Property(e => e.CanRemoveMedia).HasColumnType("tinyint");

                entity.Property(e => e.CanRemoveReaders).HasColumnType("tinyint");

                entity.Property(e => e.CanRemoveUserGroups).HasColumnType("tinyint");

                entity.Property(e => e.CanRemoveUsers).HasColumnType("tinyint");
            });

            modelBuilder.Entity<Borrow>(entity =>
            {
                entity.ToTable("borrow");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint");

                entity.Property(e => e.BorrowDate)
                    .IsRequired()
                    .HasColumnType("date");

                entity.Property(e => e.MediumId)
                    .HasColumnName("Medium_ID")
                    .HasColumnType("bigint");

                entity.Property(e => e.ReaderId)
                    .HasColumnName("Reader_ID")
                    .HasColumnType("bigint");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.Medium)
                    .WithMany(p => p.Borrow)
                    .HasForeignKey(d => d.MediumId);

                entity.HasOne(d => d.Reader)
                    .WithMany(p => p.Borrow)
                    .HasForeignKey(d => d.ReaderId);
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.ToTable("media_type");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Medium>(entity =>
            {
                entity.ToTable("medium");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint");

                entity.Property(e => e.Author)
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(1000)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.DevelopmentPlan)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.IsAvailable)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Picture).HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Type)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Year)
                    .HasColumnType("year(4)")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Medium)
                    .HasForeignKey(d => d.Type);
            });

            modelBuilder.Entity<Reader>(entity =>
            {
                entity.ToTable("reader");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint");

                entity.Property(e => e.Address)
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CardId)
                    .HasColumnName("Card_ID")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsActive)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AclId)
                    .HasColumnName("ACL_ID")
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GroupId)
                    .HasColumnName("Group_ID")
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.IsActive)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Acl)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.AclId);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.GroupId);
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("user_group");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint");

                entity.Property(e => e.AclId)
                    .HasColumnName("ACL_ID")
                    .HasColumnType("bigint");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Acl)
                    .WithMany(p => p.UserGroup)
                    .HasForeignKey(d => d.AclId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserSettings>(entity =>
            {
                entity.ToTable("user_settings");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("tinyint");

                entity.Property(e => e.DateTimeFormat)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.IsActive)
                    .HasColumnType("tinyint")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasColumnType("bigint");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSettings)
                    .HasForeignKey(d => d.UserId);
            });
        }
    }
}