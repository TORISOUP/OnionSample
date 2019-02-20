using System;
using System.IO;
using System.Threading.Tasks;
using SampleApp.Domain;
using UnityEngine;

namespace SampleApp.Infrastructure
{
    public class JsonSaveDataRepsitory : ISaveDataRepository
    {
        private readonly string _dataPath;

        public JsonSaveDataRepsitory()
        {
            _dataPath = Path.Combine(Application.dataPath, "..", "Saves");
            if (!Directory.Exists(_dataPath))
            {
                Directory.CreateDirectory(_dataPath);
            }
        }

        public async Task<SaveData> FindAsync(string key)
        {
            var path = $"{_dataPath}/{key}.json";
            if (!File.Exists(path)) return null;
            var json = await Task.Run(() => File.ReadAllText(path));
            var dto = JsonUtility.FromJson<SaveDataDto>(json); // Fix error handling
            return new SaveData(dto.name, dto.power, dto.speed, dto.health);
        }

        public async Task StoreAsync(string key, SaveData saveData)
        {
            var dto = new SaveDataDto
            {
                name = saveData.Name,
                power = saveData.Power,
                speed = saveData.Speed,
                health = saveData.Health
            };
            var json = JsonUtility.ToJson(dto);
            await Task.Run(() => File.WriteAllText($"{_dataPath}/{key}.json", json));
        }

        [Serializable]
        private struct SaveDataDto
        {
            public string name;
            public int power;
            public int speed;
            public int health;
        }
    }
}