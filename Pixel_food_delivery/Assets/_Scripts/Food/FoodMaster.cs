using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;

namespace Game.FoodZone
{
    public class FoodMaster : MonoBehaviorInstance<FoodMaster>
    {

        public Food CreateRandomFood(Transform parent = null)
        {
            // Food foodPref = Resources.Load<Food>("Prefab/Food/FoodPref");

            Food foodScript = Instantiate<Food>(Resources.Load<Food>("Prefab/Food/FoodPref"), parent);
            foodScript.SetFoodData(GetRandomFoodData());
            return foodScript;
        }

        public FoodSO GetRandomFoodData()
        {
            FoodSO[] foodSOs = Resources.LoadAll<FoodSO>("Prefab/Food");
            FoodSO foodSO = foodSOs[UnityEngine.Random.Range(0, foodSOs.Length)];
            return foodSO;
        }
    }
}
