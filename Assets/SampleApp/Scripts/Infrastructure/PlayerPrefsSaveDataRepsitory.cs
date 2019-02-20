using System.Threading.Tasks;
using SampleApp.Domain;
using UnityEngine;

namespace SampleApp.Infrastructure
{
    public class PlayerPrefsSaveDataRepsitory : ISaveDataRepository
    {
        private readonly string _nameKey = "name.";
        private readonly string _healthKey = "health.";
        private readonly string _speedKey = "speed.";
        private readonly string _powerKey = "power.";
#pragma warning disable CS1998
        public async Task<SaveData> FindAsync(string key)
#pragma warning restore CS1998
        {
            var name = PlayerPrefs.GetString(_nameKey + key, "");
            if (string.IsNullOrEmpty(name)) return null;
            var health = PlayerPrefs.GetInt(_healthKey + key, 0);
            var power = PlayerPrefs.GetInt(_powerKey + key, 0);
            var speed = PlayerPrefs.GetInt(_speedKey + key, 0);

            return new SaveData(name, power, speed, health);
        }
#pragma warning disable CS1998 
        public async Task StoreAsync(string key, SaveData saveData)
#pragma warning restore CS1998
        {
            PlayerPrefs.SetString(_nameKey + key, saveData.Name);
            PlayerPrefs.SetInt(_healthKey + key, saveData.Health);
            PlayerPrefs.SetInt(_powerKey + key, saveData.Power);
            PlayerPrefs.SetInt(_speedKey + key, saveData.Speed);
            PlayerPrefs.Save();
        }
    }
}

