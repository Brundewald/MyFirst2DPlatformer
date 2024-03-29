﻿using Controller;
using Model;
using UnityEngine;

namespace View
{
    public class ModelReferenceHolder : MonoBehaviour
    {
        [Header("Model data")] 
        [Tooltip("Drag&drop Character model here")] [SerializeField]
        private CharacterModel _characterModel;
        [Tooltip("Drag&drop Level model here")] [SerializeField]
        private LevelDataModel _levelModel;
        [Tooltip("Drag&drop Dash parameters here")] [SerializeField]
        private DashParameters _dashParaters;
        [Tooltip("Drag&drop score holder here")] [SerializeField]
        private ScoreHolder _scoreHolder;
        [Tooltip("Drag&drop reward screen data here")] [SerializeField]
        private RewardScreenModel _rewardScreenModel;



        public CharacterModel CharacterModel => _characterModel;
        public LevelDataModel LevelModel => _levelModel;
        public DashParameters DashParameters => _dashParaters;
        public ScoreHolder ScoreHolder => _scoreHolder;
        public RewardScreenModel RewardScreenModel => _rewardScreenModel;
    }
}