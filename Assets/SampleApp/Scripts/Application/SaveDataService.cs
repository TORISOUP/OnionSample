using System.Diagnostics;
using System.Threading.Tasks;
using SampleApp.Domain;

namespace SampleApp.Application
{
    public class SaveDataService
    {
        private readonly ISaveDataRepository _saveDataRepository;

        public SaveDataService(ISaveDataRepository saveDataRepository)
        {
            _saveDataRepository = saveDataRepository;
        }

        public async Task<SaveData> FindAsync(string key)
        {
            var data = await _saveDataRepository.FindAsync(key);
            return data ?? SaveData.Dafault;
        }

        public Task StoreAsync(string key, SaveData saveData)
            => _saveDataRepository.StoreAsync(key, saveData);
    }
}

