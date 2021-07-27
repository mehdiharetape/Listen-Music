using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Application.Interfaces.FacadePatterns;
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
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.FacadePatern
{
    public class SongFacade : ISongFacade 
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public SongFacade(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private AddNewGenreService _addNewGenreService;
        public AddNewGenreService AddNewGenreService
        {
            get
            {
                return _addNewGenreService = _addNewGenreService ?? new AddNewGenreService(_context);
            }
        }

        private AddNewPlayListService _addNewPlayList;
        public AddNewPlayListService AddNewPlayListService
        {
            get
            {
                return _addNewPlayList = _addNewPlayList ?? new AddNewPlayListService(_context);
            }
        }

        private AddNewSingerService _addNewSingerService;
        public AddNewSingerService AddNewSingerService
        {
            get
            {
                return _addNewSingerService = _addNewSingerService ?? new AddNewSingerService(_context);
            }
        }

        private IGetGenresService _getGenresService;
        public IGetGenresService GetGenresService
        {
            get
            {
                return _getGenresService = _getGenresService ?? new GetGenresService(_context);
            }
        }

        private IGetPlayListService _getPlayListService;
        public IGetPlayListService GetPlayListService
        {
            get
            {
                return _getPlayListService = _getPlayListService ?? new GetPlayListService(_context);
            }
        }

        private IGetSingersService _getSingersService;
        public IGetSingersService GetSingersService
        {
            get
            {
                return _getSingersService = _getSingersService ?? new GetSingersService(_context);
            }
        }

        private RemoveGenreService _removeGenreService;
        public RemoveGenreService RemoveGenreService
        {
            get
            {
                return _removeGenreService = _removeGenreService ?? new RemoveGenreService(_context);
            }
        }

        private EditGenreService _editGenreService;
        public EditGenreService EditGenreService
        {
            get
            {
                return _editGenreService = _editGenreService ?? new EditGenreService(_context);
            }
        }

        private RemovePlayListService _removePlayListService;
        public RemovePlayListService RemovePlayListService
        {
            get
            {
                return _removePlayListService = _removePlayListService ?? new RemovePlayListService(_context);
            }
        }

        private EditPlayListService _editPlayListService;
        public EditPlayListService EditPlayListService
        {
            get
            {
                return _editPlayListService = _editPlayListService ?? new EditPlayListService(_context);
            }
        }

        private RemoveSingerService _removeSingerService;
        public RemoveSingerService RemoveSingerService
        {
            get
            {
                return _removeSingerService = _removeSingerService ?? new RemoveSingerService(_context);
            }
        }

        private EditSingerService _editSingerService;
        public EditSingerService EditSingerService
        {
            get
            {
                return _editSingerService = _editSingerService ?? new EditSingerService(_context);
            }
        }

        private AddNewSongService _addNewSongService;
        public AddNewSongService AddNewSongService
        {
            get
            {
                return _addNewSongService = _addNewSongService ?? new AddNewSongService(_context, _environment);
            }
        }

        private IGetAllPlayListsService _getAllPlayListsService;
        public IGetAllPlayListsService GetAllPlayListsService
        {
            get
            {
                return _getAllPlayListsService = _getAllPlayListsService ?? new GetAllPlayLists(_context);
            }
        }

        private IGetAllSingersService _getAllSingersService;
        public IGetAllSingersService GetAllSingersService
        {
            get
            {
                return _getAllSingersService = _getAllSingersService ?? new GetAllSingers(_context);
            }
        }

        private IGetAllGenresService _getAllGenresService;
        public IGetAllGenresService GetAllGenresService
        {
            get
            {
                return _getAllGenresService = _getAllGenresService ?? new GetAllGenresService(_context);
            }
        }

        private IGetSongForAdminService _getSongForAdminService;
        public IGetSongForAdminService GetSongForAdminService
        {
            get
            {
                return _getSongForAdminService = _getSongForAdminService ?? new GetSongForAdminService(_context);
            }
        }

        private RemoveSongService _removeSongService;
        public RemoveSongService RemoveSongService
        {
            get
            {
                return _removeSongService = _removeSongService ?? new RemoveSongService(_context,_environment);
            }
        }

        private EditSongService _editSongService;
        public EditSongService EditSongService
        {
            get
            {
                return _editSongService = _editSongService ?? new EditSongService(_context);
            }
        }

        private IGetSongForSiteService _getSongForSiteService;
        public IGetSongForSiteService GetSongForSiteService
        {
            get
            {
                return _getSongForSiteService = _getSongForSiteService ?? new GetSongForSiteService(_context);
            }
        }

        private IGetSongDetailForSiteService _getSongDetailForSiteService;
        public IGetSongDetailForSiteService GetSongDetailForSiteService
        {
            get
            {
                return _getSongDetailForSiteService = _getSongDetailForSiteService ?? new GetSongDetailForSiteService(_context);
            }
        }

        private IGetSongsOfPlayListService _getSongsOfPlayListService;
        public IGetSongsOfPlayListService GetSongsOfPlayListService
        {
            get
            {
                return _getSongsOfPlayListService = _getSongsOfPlayListService ?? new GetSongsOfPlayListService(_context);
            }
        }

        private IGetSongOfSingerService _getSongOfSingerService;
        public IGetSongOfSingerService GetSongOfSingerService
        {
            get
            {
                return _getSongOfSingerService = _getSongOfSingerService ?? new GetSongOfSingerService(_context); 
            }
        }

        private IGetSongOfGenreService _getSongOfGenreService;
        public IGetSongOfGenreService GetSongOfGenreService
        {
            get
            {
                return _getSongOfGenreService = _getSongOfGenreService ?? new GetSongOfGenreService(_context);
            }
        }

        private AddNewCommentService _addNewComment;
        public AddNewCommentService AddNewCommentService
        {
            get
            {
                return _addNewComment = _addNewComment ?? new AddNewCommentService(_context);
            }
        }

        private IGetCommetnsService _getCommetnsService;
        public IGetCommetnsService GetCommetnsService
        {
            get
            {
                return _getCommetnsService = _getCommetnsService ?? new GetCommetnsService(_context);
            }
        }

        private IGetRelatingSongService _getRelatingSong;
        public IGetRelatingSongService GetRelatingSongService
        {
            get
            {
                return _getRelatingSong = _getRelatingSong ?? new GetRelatingSongService(_context);
            }
        }

        private IGetCommentForAdminService _getCommentForAdmin;
        public IGetCommentForAdminService GetCommentForAdminService
        {
            get
            {
                return _getCommentForAdmin = _getCommentForAdmin ?? new GetCommentForAdminService(_context);
            }
        }
    }
}
