using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class LocalizationView : MonoBehaviour
{
    [SerializeField] private static readonly string CouldNotLoadStringTable = "Could not load String Table\n";
    [SerializeField] private readonly string _tableReference = "M2FP";
    [SerializeField] private readonly string _messageTextKey = "Message_text";
    [SerializeField] private readonly string _showNotificationButtonKey = "ShowNotificationButton";
    [SerializeField] private readonly string _chooseLanguageKey = "ChooseLanguage";
    [SerializeField] private readonly string _russianButtonKey = "RussianButton";
    [SerializeField] private readonly string _englishButtonKey = "EnglishButton";

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
        var loadingOperation = LocalizationSettings.StringDatabase.GetTableAsync(_tableReference);
        await Task.Yield();

        if (loadingOperation.Status == AsyncOperationStatus.Succeeded)
        {
            var table = loadingOperation.Result;
            _messageText.text = table.GetEntry(_messageTextKey)?.GetLocalizedString();
            _showNotificationText.text = table.GetEntry(_showNotificationButtonKey)?.GetLocalizedString();
            _chooseLanguageText.text = table.GetEntry(_chooseLanguageKey)?.GetLocalizedString();
            _russianButtonText.text = table.GetEntry(_russianButtonKey)?.GetLocalizedString();
            _englishButtonText.text = table.GetEntry(_englishButtonKey)?.GetLocalizedString();
        }
        else
        {
            Debug.Log(CouldNotLoadStringTable+ loadingOperation.OperationException);
        }
    }

    private void ChangeLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
