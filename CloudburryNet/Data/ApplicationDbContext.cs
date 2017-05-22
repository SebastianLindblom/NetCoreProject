using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CloudburryNet.Models;
using CloudburryNet.Data.DataModels;

namespace CloudburryNet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryTag> CategoryTag { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostTag> PostTag { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Theme> Theme { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }
        public DbSet<UserPost> UserPost { get; set; }
        public DbSet<UserTag> UserTag { get; set; }
        public DbSet<UserTheme> UserTheme { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<User>().HasMany(x => x.UserCategories);
            builder.Entity<User>().HasMany(x => x.UserPosts);
            builder.Entity<User>().HasMany(x => x.UserTagss);
            builder.Entity<User>().HasMany(x => x.UserThemes);

            builder.Entity<Category>().HasMany(x => x.CategoryTags);

            builder.Entity<Post>().HasMany(x => x.PostTags);

            builder.Entity<Tag>().HasMany(x => x.CategoryTags);
            builder.Entity<Tag>().HasMany(x => x.PostTags);

            builder.Entity<Theme>().HasMany(x => x.UserThemes);


        }

    }
}
