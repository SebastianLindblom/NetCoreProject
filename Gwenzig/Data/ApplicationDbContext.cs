using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gwenzig.Models;
using Gwenzig.Data.DataModels;

namespace Gwenzig.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<AppDataTypes> AppDataTypes { get; set; }
        public virtual DbSet<AuthorityLevels> AuthorityLevels { get; set; }
        public virtual DbSet<Banners> Banners { get; set; }
        public virtual DbSet<Businessareas> Businessareas { get; set; }
        public virtual DbSet<FeaturedItems> FeaturedItems { get; set; }
        public virtual DbSet<MenuItems> MenuItems { get; set; }
        public virtual DbSet<MenuNavigations> MenuNavigations { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<PageMenuBinders> PageMenuBinders { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<Priceattributes> Priceattributes { get; set; }
        public virtual DbSet<Prices> Prices { get; set; }
        public virtual DbSet<Sections> Sections { get; set; }
        public virtual DbSet<Serviceareas> Serviceareas { get; set; }
        public virtual DbSet<Serviceoffers> Serviceoffers { get; set; }
        public virtual DbSet<ShowcaseItems> ShowcaseItems { get; set; }
        public virtual DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=SQL5016.SmarterASP.NET;Initial Catalog=DB_A0F8EF_database;User Id=DB_A0F8EF_database_admin;Password=smarterasp1236;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MenuItems>(entity =>
            {
                entity.HasIndex(e => e.MenuNavigationsId)
                    .HasName("IX_MenuNavigations_Id");

                entity.Property(e => e.MenuNavigationsId).HasColumnName("MenuNavigations_Id");

                entity.HasOne(d => d.MenuNavigations)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.MenuNavigationsId)
                    .HasConstraintName("FK_dbo.MenuItems_dbo.MenuNavigations_MenuNavigations_Id");
            });

            modelBuilder.Entity<MenuNavigations>(entity =>
            {
                entity.HasIndex(e => e.AppDataTypesId)
                    .HasName("IX_AppDataTypes_id");

                entity.Property(e => e.AppDataTypesId).HasColumnName("AppDataTypes_id");

                entity.HasOne(d => d.AppDataTypes)
                    .WithMany(p => p.MenuNavigations)
                    .HasForeignKey(d => d.AppDataTypesId)
                    .HasConstraintName("FK_dbo.MenuNavigations_dbo.AppDataTypes_AppDataTypes_id");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.Property(e => e.Mail).IsRequired();

                entity.Property(e => e.Syncedflag).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory2");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<PageMenuBinders>(entity =>
            {
                entity.HasIndex(e => e.MenuItemsId)
                    .HasName("IX_MenuItems_Id");

                entity.HasIndex(e => e.PagesId)
                    .HasName("IX_Pages_id");

                entity.Property(e => e.MenuItemsId).HasColumnName("MenuItems_Id");

                entity.Property(e => e.PagesId).HasColumnName("Pages_id");

                entity.HasOne(d => d.MenuItems)
                    .WithMany(p => p.PageMenuBinders)
                    .HasForeignKey(d => d.MenuItemsId)
                    .HasConstraintName("FK_dbo.PageMenuBinders_dbo.MenuItems_MenuItems_Id");

                entity.HasOne(d => d.Pages)
                    .WithMany(p => p.PageMenuBinders)
                    .HasForeignKey(d => d.PagesId)
                    .HasConstraintName("FK_dbo.PageMenuBinders_dbo.Pages_Pages_id");
            });

            modelBuilder.Entity<Pages>(entity =>
            {
                entity.HasIndex(e => e.AuthorityLevelsId1)
                    .HasName("IX_AuthorityLevels_Id1");

                entity.Property(e => e.AuthorityLevelsId).HasColumnName("AuthorityLevels_Id");

                entity.Property(e => e.AuthorityLevelsId1).HasColumnName("AuthorityLevels_Id1");

                entity.HasOne(d => d.AuthorityLevelsId1Navigation)
                    .WithMany(p => p.Pages)
                    .HasForeignKey(d => d.AuthorityLevelsId1)
                    .HasConstraintName("FK_dbo.Pages_dbo.AuthorityLevels_AuthorityLevels_Id1");
            });

            modelBuilder.Entity<Priceattributes>(entity =>
            {
                entity.HasIndex(e => e.PricesId)
                    .HasName("IX_Prices_Id");

                entity.Property(e => e.PricesId).HasColumnName("Prices_Id");

                entity.HasOne(d => d.Prices)
                    .WithMany(p => p.Priceattributes)
                    .HasForeignKey(d => d.PricesId)
                    .HasConstraintName("FK_dbo.Priceattributes_dbo.Prices_Prices_Id");
            });

           
            modelBuilder.Entity<Sections>(entity =>
            {
                entity.HasIndex(e => e.PagesId)
                    .HasName("IX_Pages_Id");

                entity.Property(e => e.PageId).HasColumnName("Page_Id");

                entity.Property(e => e.PagesId).HasColumnName("Pages_Id");

                entity.Property(e => e.PositionNumber).HasColumnName("Position_number");

                entity.Property(e => e.TemplateId).HasColumnName("Template_Id");

                entity.HasOne(d => d.Pages)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.PagesId)
                    .HasConstraintName("FK_dbo.Sections_dbo.Pages_Pages_Id");
            });


            

            modelBuilder.Entity<UserSettings>(entity =>
            {
                entity.ToTable("User_Settings");

                entity.HasIndex(e => e.AuthorityLevelsId1)
                    .HasName("IX_AuthorityLevels_Id1");

                entity.HasIndex(e => e.MenuItemsId1)
                    .HasName("IX_MenuItems_Id1");

                entity.Property(e => e.AuthorityLevelsId).HasColumnName("AuthorityLevels_Id");

                entity.Property(e => e.AuthorityLevelsId1).HasColumnName("AuthorityLevels_Id1");

                entity.Property(e => e.MenuItemsId).HasColumnName("MenuItems_Id");

                entity.Property(e => e.MenuItemsId1).HasColumnName("MenuItems_Id1");

                entity.HasOne(d => d.AuthorityLevelsId1Navigation)
                    .WithMany(p => p.UserSettings)
                    .HasForeignKey(d => d.AuthorityLevelsId1)
                    .HasConstraintName("FK_dbo.User_Settings_dbo.AuthorityLevels_AuthorityLevels_Id1");

                entity.HasOne(d => d.MenuItemsId1Navigation)
                    .WithMany(p => p.UserSettings)
                    .HasForeignKey(d => d.MenuItemsId1)
                    .HasConstraintName("FK_dbo.User_Settings_dbo.MenuItems_MenuItems_Id1");
            });
        }


    }
}
