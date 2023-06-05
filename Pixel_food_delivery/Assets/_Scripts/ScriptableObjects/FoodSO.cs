using UnityEngine;

namespace Game.FoodZone
{
    [CreateAssetMenu(fileName = "FoodSO")]
    public class FoodSO : ScriptableObject
    {
        public string foodName = "";
        public Sprite image;
    }
}
