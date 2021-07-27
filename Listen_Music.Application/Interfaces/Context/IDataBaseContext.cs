using Listen_Music.Domain.Entities.Comments;
using Listen_Music.Domain.Entities.Songs;
using Listen_Music.Domain.Entities.UserProfiles;
using Listen_Music.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Listen_Music.Application.Interfaces.Context
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserInRole> UserInRoles { get; set; }
        DbSet<Singers> Singers { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<PlayLists> PlayLists { get; set; }
        DbSet<Song> Songs { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<SongFile> SongFiles { get; set; }
        DbSet<ImageFile> ImageFiles { get; set; }
        DbSet<UserSingerFollow> UserSingerFollows { get; set; }
        DbSet<SingerFollowItem> SingerFollowItems { get; set; }
        DbSet<UserGenreFollow> UserGenreFollows { get; set; } 
        DbSet<GenreFollowItems> GenreFollowItems { get; set; }
        DbSet<UserPlayListFollow> UserPlayListFollows { get; set; }
        DbSet<PlayListFollowItem> PlayListFollowItems { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken=new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
