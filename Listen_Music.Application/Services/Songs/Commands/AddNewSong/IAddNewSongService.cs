using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Common.DTO;
using Listen_Music.Domain.Entities.Songs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listen_Music.Application.Services.Songs.Commands.AddNewSong
{
    public interface IAddNewSongService
    {
        ResultDTO Execute(RequestAddNewSongDTO request);
    }

    public class AddNewSongService : IAddNewSongService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewSongService(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDTO Execute(RequestAddNewSongDTO request)
        {
            try
            {
                var singer = _context.Singers.Find(request.SingerId);
                var genre = _context.Genres.Find(request.GenreId);
                var playlist = _context.PlayLists.Find(request.PlayListId);

                Song song = new Song()
                {
                    Name = request.Name,
                    Duration = request.Duration,
                    Singer = singer,
                    Genre = genre,
                    PlayList = playlist
                };
                _context.Songs.Add(song);

                //List<ImageFile> imageFiles = new List<ImageFile>();
                //foreach(var item in request.ImageSrc)
                //{
                //    var uploadImage = UploadImageFile(item);
                //    imageFiles.Add(new ImageFile 
                //    {
                //        Song = song,
                //        ImageSrc = uploadImage.FileNameAddress
                //    });
                //}
                //_context.ImageFiles.AddRange(imageFiles);

                var uploadedImage = UploadImageFile(request.ImageSrc);
                _context.ImageFiles.Add(new ImageFile
                {
                    Song = song,
                    ImageSrc = uploadedImage.FileNameAddress
                });


                //List<SongFile> songFiles = new List<SongFile>();
                //foreach (var item in request.SongSrc)
                //{
                //    var uploadSong = UploadSongFile(item);
                //    songFiles.Add(new SongFile
                //    {
                //        Song = song,
                //        SongSrc = uploadSong.FileNameAddress
                //    });
                //}
                //_context.SongFiles.AddRange(songFiles);

                var uploadedSong = UploadSongFile(request.SongSrc);
                _context.SongFiles.Add(new SongFile
                {
                    Song = song,
                    SongSrc = uploadedSong.FileNameAddress
                });

                _context.SaveChanges();

                return new ResultDTO
                {
                    IsSuccess = true,
                    Message = "موزیک با موفقیت اضافه شد"
                };
                
            }
            catch (Exception ex)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "خطا رخ داد"
                };
            }
        }

        private UploadDto UploadImageFile(IFormFile ImageFile)
        {
            if (ImageFile != null)
            {
                string imageFolder = $@"SongFiles\Images\";
                var uploadRootFolder = Path.Combine(_environment.WebRootPath, imageFolder);
                if (!Directory.Exists(uploadRootFolder))
                {
                    Directory.CreateDirectory(uploadRootFolder);
                }


                if (ImageFile == null || ImageFile.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string imageFileName = DateTime.Now.Ticks.ToString() + ImageFile.FileName;
                var filePath = Path.Combine(uploadRootFolder, imageFileName);
                using (var fileSream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(fileSream);
                }

                return new UploadDto()
                {
                    FileNameAddress = imageFolder + imageFileName,
                    Status = true,
                };
            }
            return null;
        }

        private UploadDto UploadSongFile(IFormFile SongFile)
        {
            if (SongFile != null)
            {
                string songFolder = $@"SongFiles\Songs\";
                var uploadRootFolder = Path.Combine(_environment.WebRootPath, songFolder);
                if (!Directory.Exists(uploadRootFolder))
                {
                    Directory.CreateDirectory(uploadRootFolder);
                }


                if (SongFile == null || SongFile.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string songFileName = DateTime.Now.Ticks.ToString() + SongFile.FileName;
                var filePath = Path.Combine(uploadRootFolder, songFileName);
                using (var fileSream = new FileStream(filePath, FileMode.Create))
                {
                    SongFile.CopyTo(fileSream);
                }

                return new UploadDto()
                {
                    FileNameAddress = songFolder + songFileName,
                    Status = true,
                };
            }
            return null;
        }
    }

    public class UploadDto
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }
    }

    public class RequestAddNewSongDTO
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public long SingerId { get; set; }
        public long GenreId { get; set; }
        public long PlayListId { get; set; }

        //public List<IFormFile> SongSrc { get; set; }
        public IFormFile SongSrc { get; set; }

        //public List<IFormFile> ImageSrc { get; set; }
        public IFormFile ImageSrc { get; set; }

    }

}
