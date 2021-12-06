using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using View;

namespace Controller
{
    public class BonusWobblingHandler:IInitialize
    {
        private readonly ScoreHolder _bonusHolder;
        private List<GameObject> _bonusObjects;
        
        
        public BonusWobblingHandler(BonusView bonusView, ScoreHolder bonusHolder)
        {
            _bonusObjects = bonusView.BonusList;
            _bonusHolder = bonusHolder;
        }


        public void Initialize()
        {
            AppleWobbleAnimation();
        }

        private void AppleWobbleAnimation()
        {
            foreach (var bonus in _bonusObjects)
            {
                if (!bonus.activeInHierarchy)
                    return;
               
                var movePoint = bonus.transform.position.y + _bonusHolder.UpDistance;
                bonus.transform.DOMoveY(movePoint, _bonusHolder.AnimationDurationTime).SetLoops(-1, LoopType.Yoyo);
            }
        }
    }
}