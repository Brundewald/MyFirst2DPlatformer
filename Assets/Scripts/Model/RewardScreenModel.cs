using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/RewardScreenData", fileName = "RewardScreenData")]
public class RewardScreenModel : ScriptableObject
{
    private const string _timeToNextReward = "Next reward in:";
    
    [SerializeField] private GameObject _rewardWindow;
    [SerializeField] private GameObject _message;
    [SerializeField][Range(0, 86400)] private float _coolDownTime = 86400;
    
    public string TimerMessage => _timeToNextReward;
    public float CoolDownTime => _coolDownTime;
    public GameObject RewardWindow => _rewardWindow;
    public GameObject Message => _message;
}
