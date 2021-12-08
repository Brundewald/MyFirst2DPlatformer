using UnityEngine;

[CreateAssetMenu(menuName = "Data/ScoreHolder", fileName = "ScoreHolder")]
public class ScoreHolder : ScriptableObject
{
    [SerializeField] private GameObject _scorePrefab;
    [SerializeField] private int _scoreForApple = 1;
    [SerializeField] private int _scoreCount;
    [SerializeField] private float _upDistance;
    [SerializeField] private float _downDistance;
    [SerializeField] private float _animationDurationTime;
    [SerializeField] private float _shakingStrength;

    public int ScoreCount
    {
        get { return _scoreCount; }
        set { _scoreCount = value; }
    }

    public int ScoreForApple => _scoreForApple;
    public GameObject ScorePrefab => _scorePrefab;
    public float UpDistance => _upDistance;
    public float DownDistance => _downDistance;
    public float AnimationDurationTime => _animationDurationTime;
    public float ShakingStrength => _shakingStrength;
}
