using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;

[CreateAssetMenu(menuName = "Data", fileName = "LevelData")]
public class LevelDataModel : ScriptableObject
{
    [Header("Win Score")][Tooltip("How much score player needs to win")][SerializeField][Range(0,10)] 
    private int _requireScore;
    
    [Header("Ground LayerMask")][Tooltip("Add LayerMask for Ground")][SerializeField] 
    private LayerMask _groundLayerMask;
    
    [Header("Character LayerMask")][Tooltip("Add LayerMask for Character")][SerializeField]
    private LayerMask _characterLayerMask;

    [Header("Engame Dispaly Prefab Path")] [Tooltip("Enter path for endGameDisplay")][SerializeField]
    private string _endGameDisplayPath;
    
    [Header("Enemy base point")] [Tooltip("Add transform of the object were you want to place enemy")] [SerializeField]
    private Transform _enemyBasePoint;


    public int RequireScore => _requireScore;
    public LayerMask GroundLayerMask => _groundLayerMask;
    public LayerMask CharacterLayerMask => _characterLayerMask;
    
    public Transform EnemyBasePoint => _enemyBasePoint;
    public string EndGameDisplayPath => _endGameDisplayPath;
    
}
