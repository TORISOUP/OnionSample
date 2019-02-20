using SampleApp.Application;
using SampleApp.Domain;
using UniRx;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace SampleApp.Presentation.Model
{
    public class SaveDataManager : MonoBehaviour
    {
        [Inject] private SaveDataService _saveDataService;

        private string _defaultSaveDataKey = "Default";

        public readonly ReactiveProperty<SaveData> CurrentSaveData
            = new ReactiveProperty<SaveData>();

        private void Start()
        {
            LoadAsync().Forget();
        }

        public async UniTask SaveAsync(SaveData newSave)
        {
            CurrentSaveData.Value = newSave;
            await _saveDataService.StoreAsync(_defaultSaveDataKey, CurrentSaveData.Value);
        }

        public async UniTask LoadAsync()
        {
            var data = await _saveDataService.FindAsync(_defaultSaveDataKey);
            if (data != null) CurrentSaveData.Value = data;
        }
    }
}


