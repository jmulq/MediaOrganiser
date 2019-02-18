using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganiser.Models.IRepositories
{
    public interface IMediaFileRepository
    {
        Task<IEnumerable<MediaFile>> GetAllMediaFilesAsync();

        Task<MediaFile> GetMediaFileByIdAsync(int? mediaFileId);

        Task AddMediaFileAsync(MediaFile mediaFile);

        Task UpdateMediaFileAsync(MediaFile mediaFile);

        Task DeleteMediaFileAsync(MediaFile mediaFile);

        Task<bool> MediaFileExistsAsync(int id);

        
    }
}
