using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RewardScreenView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerHolder;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _getRewardButton;

    public void Init(UnityAction back, UnityAction getReward)
    {
        _backButton.onClick.AddListener(back);
        _getRewardButton.onClick.AddListener(getReward);
    }

    public void OnDestroy()
    {
        _backButton.onClick.RemoveAllListeners();
        _getRewardButton.onClick.RemoveAllListeners();
    }


    public TextMeshProUGUI TimerHolder => _timerHolder;
}
