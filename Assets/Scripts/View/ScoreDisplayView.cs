using TMPro;
using UnityEngine;

namespace View
{
    public class ScoreDisplayView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public TextMeshProUGUI TextToDisplay => _text;
    }
}