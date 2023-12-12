using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace SupperFFmpeg.Contracts.Services;

public interface IFileSelectService
{
    public Task<StorageFile> OpenFileAsync(IList<string> filter);
}
