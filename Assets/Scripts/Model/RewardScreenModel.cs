using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/RewardScreenData", fileName = "RewardScreenData")]

public class RewardScreenModel : ScriptableObject
{
    public TimeSpan WhenRewardWasTaken { get; protected internal set; }

    public bool RewardWasTaken
    {
        get => _timerIsCounting;
        protected internal set => _timerIsCounting = value;
    }

    private const string _timeToNextReward = "Next reward in:";

    [SerializeField] private GameObject _rewardWindow;

    [SerializeField] private GameObject _message;

    [SerializeField][Range(0, 86400)] private float _coolDownTime = 86400;

    [SerializeField] private bool _timerIsCounting;

    public string TimerMessage => _timeToNextReward;
    public float CoolDownTime => _coolDownTime;
    public GameObject RewardWindow => _rewardWindow;
    public GameObject Message => _message;
}
