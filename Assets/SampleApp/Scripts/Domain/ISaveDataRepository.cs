using System.Threading.Tasks;

namespace SampleApp.Domain
{
    public interface ISaveDataRepository
    {
        Task<SaveData> FindAsync(string key);
        Task StoreAsync(string key, SaveData saveData);
    }
}

