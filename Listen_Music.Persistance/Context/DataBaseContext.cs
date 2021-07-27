using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.Role;
using Listen_Music.Domain.Entities.Comments;
using Listen_Music.Domain.Entities.Songs;
using Listen_Music.Domain.Entities.UserProfiles;
using Listen_Music.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Persistance.Context
{
    public class DataBaseContext:DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Singers> Singers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PlayLists> PlayLists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SongFile> SongFiles { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<UserSingerFollow> UserSingerFollows { get; set; }
        public DbSet<SingerFollowItem> SingerFollowItems { get; set; }
        public DbSet<UserGenreFollow> UserGenreFollows { get; set; }
        public DbSet<GenreFollowItems> GenreFollowItems { get; set; }
        public DbSet<UserPlayListFollow> UserPlayListFollows { get; set; }
        public DbSet<PlayListFollowItem> PlayListFollowItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);

            //عدم تکراری بودن ایمیل
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            ApplyQueryFilter(modelBuilder);
        }

        public void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Singers>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Genre>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<PlayLists>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Song>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Comment>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<SongFile>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ImageFile>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserSingerFollow>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<SingerFollowItem>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserGenreFollow>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<GenreFollowItems>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserPlayListFollow>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<PlayListFollowItem>().HasQueryFilter(p => !p.IsRemoved);
        }

        public void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.User) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Artist)});
        }
    }
}
