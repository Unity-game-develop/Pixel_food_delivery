using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.FoodZone;

namespace Game.Table
{
    public class CustomerTable : BaseTable
    {
        public void SetFoodData(FoodSO foodSO)
        {
            ShowFoodObject(true);
            foodObject.GetComponent<Food>().SetFoodData(foodSO);
            
        }
    }
}
