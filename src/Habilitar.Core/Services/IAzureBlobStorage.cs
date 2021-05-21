using System.IO;
using System.Threading.Tasks;

namespace Habilitar.Core.Services
{
    public interface IAzureBlobStorage
    {
        Task<string> Upload(string file, string nameFile);
    }
}
