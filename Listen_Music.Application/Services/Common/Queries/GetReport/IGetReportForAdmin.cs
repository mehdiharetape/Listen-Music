using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Common.Queries.GetReport
{
    public interface IGetReportForAdmin
    {
        ResultDTO<ReportDTO> Execute();
    }

    public class GetReportForAdmin : IGetReportForAdmin
    {
        private readonly IDataBaseContext _context;
        public GetReportForAdmin(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ReportDTO> Execute()
        {
            var userCount = _context.Users.Count();
            var AdminCount = _context.UserInRoles.Where(a => a.RoleId == 1).Count();
            var NormalUserCount = _context.UserInRoles.Where(a => a.RoleId == 2).Count();
            var ArtistsCount = _context.UserInRoles.Where(a => a.RoleId == 3).Count();
            var SongsCount = _context.Songs.Count();
            var GenresCount = _context.Genres.Count();
            var playListsCount = _context.PlayLists.Count();
            var SingersCount = _context.Singers.Count();

            return new ResultDTO<ReportDTO>()
            {
                Data = new ReportDTO
                {
                    UserCount = userCount,
                    AdminUserCount = AdminCount,
                    NormalUserCount = NormalUserCount,
                    ArtistsCount = ArtistsCount,
                    SongsCount = SongsCount,
                    GenresCount = GenresCount,
                    playListsCount = playListsCount,
                    SingersCount = SingersCount
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class ReportDTO
    {
        public long UserCount { get; set; }
        public long AdminUserCount { get; set; }
        public long NormalUserCount { get; set; }
        public long SongsCount { get; set; }
        public long GenresCount { get; set; }
        public long playListsCount { get; set; }
        public long SingersCount { get; set; }
        public long ArtistsCount { get; set; }

    }
}
