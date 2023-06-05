using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.FoodZone
{
    public class Food : MonoBehaviour
    {
        private FoodSO foodData;
        private SpriteRenderer sr;

        public Sprite Image => foodData.image;
        public string Name => foodData.foodName;
        public bool isHasData => foodData != null;

        void Awake()
        {
            sr = gameObject.GetComponent<SpriteRenderer>();
        }

        public void SetFoodData(FoodSO foodData)
        {
            this.foodData = foodData;
            sr.sprite = foodData.image;
        }

        public FoodSO GetFoodData()
        {
            return this.foodData;
        }
    }
}
