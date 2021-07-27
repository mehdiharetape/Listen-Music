using System.Collections.Generic;

namespace Listen_Music.Application.Services.Users.Queries.GetUser
{
    public class ResultGetUserDTO
    {
        public List<GetUsersDTO> Users { get; set; }
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
