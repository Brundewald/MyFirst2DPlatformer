using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class BonusView: MonoBehaviour
    {
        [SerializeField] private List<GameObject> _bonusList;

        public List<GameObject> BonusList => _bonusList;
    }
}