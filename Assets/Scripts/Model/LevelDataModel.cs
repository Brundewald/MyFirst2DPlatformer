using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;

[CreateAssetMenu(menuName = "Data", fileName = "LevelData")]
public class LevelDataModel : ScriptableObject
{
    [Header("Win Score")][Tooltip("How much score player needs to win")][SerializeField][Range(0,10)] 
    private int _requireScore;

    [Header("Awareness score")][Tooltip("How much score should get to become a criminal to the Enemy")]
    [SerializeField][Range(0, 10)]
    private int _awarenessScore;

    [Header("Engame Dispaly Prefab Path")] [Tooltip("Enter path for endGameDisplay")][SerializeField]
    private string _endGameDisplayPath;
    
    [Header("Enemy base point")] [Tooltip("Add transform of the object were you want to place enemy")] [SerializeField]
    private Transform _enemyBasePoint;


    public int AwarenessScore => _awarenessScore;
    public int RequireScore => _requireScore;
    public Transform EnemyBasePoint => _enemyBasePoint;
    public string EndGameDisplayPath => _endGameDisplayPath;
    
}
