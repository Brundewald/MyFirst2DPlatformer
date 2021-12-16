using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class LocalizationView : MonoBehaviour
{
    [SerializeField] private TMP_Text _showNotificationText;
    [SerializeField] private TMP_Text _messageText;
    [SerializeField] private TMP_Text _chooseLanguageText;
    [SerializeField] private TMP_Text _russianButtonText;
    [SerializeField] private TMP_Text _englishButtonText;

    [SerializeField] private Button _russianButton;
    [SerializeField] private Button _englishButton;

    private void Start()
    {
        ChangeLocaleEvent(null);
        LocalizationSettings.SelectedLocaleChanged += ChangeLocaleEvent;
        _russianButton.onClick.AddListener(()=>ChangeLanguage(1));
        _englishButton.onClick.AddListener(()=>ChangeLanguage(0));
    }

    private void OnDestroy()
    {
        LocalizationSettings.SelectedLocaleChanged -= ChangeLocaleEvent;
        _russianButton.onClick.RemoveAllListeners();
        _englishButton.onClick.RemoveAllListeners();
    }

    private async void ChangeLocaleEvent(Locale locale)
    {
        await OnLocaleChange(locale);
    }

    private async Task OnLocaleChange(Locale locale)
    {
        var loadingOperation = LocalizationSettings.StringDatabase.GetTableAsync("M2FP");
        await Task.Yield();

        if (loadingOperation.Status == AsyncOperationStatus.Succeeded)
        {
            var table = loadingOperation.Result;
            _messageText.text = table.GetEntry("Message_text")?.GetLocalizedString();
            _showNotificationText.text = table.GetEntry("ShowNotificationButton")?.GetLocalizedString();
            _chooseLanguageText.text = table.GetEntry("ChooseLanguage")?.GetLocalizedString();
            _russianButtonText.text = table.GetEntry("RussianButton")?.GetLocalizedString();
            _englishButtonText.text = table.GetEntry("EnglishButton")?.GetLocalizedString();
        }
        else
        {
            Debug.Log("Could not load String Table\n"+ loadingOperation.OperationException);
        }
    }

    private void ChangeLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
