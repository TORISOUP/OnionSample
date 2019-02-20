using SampleApp.Domain;
using SampleApp.Presentation.Model;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleApp.Presentation.Presenter
{
    public class SaveDataPresenter : MonoBehaviour
    {
        [Inject] private SaveDataManager _saveDataManager;
        [SerializeField] private InputField _nameInputField;
        [SerializeField] private InputField _powerInputField;
        [SerializeField] private InputField _speedInputField;
        [SerializeField] private InputField _healthInputField;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _loadButton;

        private void Start()
        {
            _saveDataManager.CurrentSaveData
                .Where(x => x != null)
                .Subscribe(x =>
                {
                    _nameInputField.text = x.Name;
                    _speedInputField.text = x.Speed.ToString();
                    _healthInputField.text = x.Health.ToString();
                    _powerInputField.text = x.Power.ToString();
                });

            _saveButton.BindToOnClick(_ =>
            {
                // cast失敗は考えない
                var s = int.Parse(_speedInputField.text);
                var p = int.Parse(_powerInputField.text);
                var h = int.Parse(_healthInputField.text);
                var n = new SaveData(_nameInputField.text, p, s, h);
                return _saveDataManager.SaveAsync(n).ToObservable();
            });

            _loadButton.BindToOnClick(_ => _saveDataManager.LoadAsync().ToObservable());
        }
    }
}