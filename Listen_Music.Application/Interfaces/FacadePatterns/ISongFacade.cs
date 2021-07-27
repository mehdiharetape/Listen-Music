using Listen_Music.Application.Services.Songs.Commands.AddNewComment;
using Listen_Music.Application.Services.Songs.Commands.AddNewGenre;
using Listen_Music.Application.Services.Songs.Commands.AddNewPlayList;
using Listen_Music.Application.Services.Songs.Commands.AddNewSinger;
using Listen_Music.Application.Services.Songs.Commands.AddNewSong;
using Listen_Music.Application.Services.Songs.Commands.EditGenre;
using Listen_Music.Application.Services.Songs.Commands.EditPlaylist;
using Listen_Music.Application.Services.Songs.Commands.EditSinger;
using Listen_Music.Application.Services.Songs.Commands.EditSong;
using Listen_Music.Application.Services.Songs.Commands.RemoveGenre;
using Listen_Music.Application.Services.Songs.Commands.RemovePlaylist;
using Listen_Music.Application.Services.Songs.Commands.RemoveSinger;
using Listen_Music.Application.Services.Songs.Commands.RemoveSong;
using Listen_Music.Application.Services.Songs.Queries.GetAllGenres;
using Listen_Music.Application.Services.Songs.Queries.GetAllPlayLists;
using Listen_Music.Application.Services.Songs.Queries.GetAllSingers;
using Listen_Music.Application.Services.Songs.Queries.GetCommentForAdmin;
using Listen_Music.Application.Services.Songs.Queries.GetComments;
using Listen_Music.Application.Services.Songs.Queries.GetGenres;
using Listen_Music.Application.Services.Songs.Queries.GetPlayList;
using Listen_Music.Application.Services.Songs.Queries.GetRelatingSongs;
using Listen_Music.Application.Services.Songs.Queries.GetSingers;
using Listen_Music.Application.Services.Songs.Queries.GetSongDetailForSite;
using Listen_Music.Application.Services.Songs.Queries.GetSongForAdmin;
using Listen_Music.Application.Services.Songs.Queries.GetSongForSite;
using Listen_Music.Application.Services.Songs.Queries.GetSongsOfGenre;
using Listen_Music.Application.Services.Songs.Queries.GetSongsOfPlayList;
using Listen_Music.Application.Services.Songs.Queries.GetSongsOfSingers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Interfaces.FacadePatterns
{
    public interface ISongFacade
    {
        AddNewGenreService AddNewGenreService { get; }
        AddNewPlayListService AddNewPlayListService { get; }
        AddNewSingerService AddNewSingerService { get; }

        IGetGenresService GetGenresService { get; }
        IGetPlayListService GetPlayListService { get; }
        IGetSingersService GetSingersService { get; }

        RemoveGenreService RemoveGenreService { get; }
        EditGenreService EditGenreService { get; }

        RemovePlayListService RemovePlayListService { get; }
        EditPlayListService EditPlayListService { get; }

        RemoveSingerService RemoveSingerService { get; }
        EditSingerService EditSingerService { get; }

        AddNewSongService AddNewSongService { get; }

        IGetAllGenresService GetAllGenresService { get; }
        IGetAllPlayListsService GetAllPlayListsService { get; }
        IGetAllSingersService GetAllSingersService { get; }

        IGetSongForAdminService GetSongForAdminService { get; }

        RemoveSongService RemoveSongService { get; }
        EditSongService EditSongService { get; }

        IGetSongForSiteService GetSongForSiteService { get; }

        IGetSongDetailForSiteService GetSongDetailForSiteService { get; }

        IGetSongsOfPlayListService GetSongsOfPlayListService { get; }

        IGetSongOfSingerService GetSongOfSingerService { get; }

        IGetSongOfGenreService GetSongOfGenreService { get; }

        AddNewCommentService AddNewCommentService { get; }

        IGetCommetnsService GetCommetnsService { get; }

        IGetRelatingSongService GetRelatingSongService { get; }

        IGetCommentForAdminService GetCommentForAdminService { get; }
    }
}
