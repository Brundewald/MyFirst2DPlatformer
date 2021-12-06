using UnityEngine;

[CreateAssetMenu(menuName = "Data/ScoreHolder", fileName = "ScoreHolder")]
public class ScoreHolder : ScriptableObject
{
    [SerializeField] private GameObject _scorePrefab;
    [SerializeField] private int _scoreForApple = 1;
    [SerializeField] private int _scoreCount;

    public int ScoreCount
    {
        get { return _scoreCount; }
        set { _scoreCount = value; }
    }

    public int ScoreForApple => _scoreForApple;
    public GameObject ScorePrefab => _scorePrefab;
}
