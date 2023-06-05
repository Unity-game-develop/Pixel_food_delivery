using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Interface;

namespace Game.FoodZone
{
    public class FoodSpawner : BaseTable, IInteractable
    {
        private Queue<FoodSO> waitingFoodList = new Queue<FoodSO>();
        private FoodSO currentFoodSO;

        void Start()
        {
            CreateRandomFood();
        }

        public Food CreateRandomFood()
        {
            ShowFoodObject(true);
            foodObject.GetComponent<Food>().SetFoodData(FoodMaster.Instance.GetRandomFoodData());
            foodObject.gameObject.transform.position = this.transform.position;
            return foodObject.GetComponent<Food>();
        }

        public void CreateFood(FoodSO foodSO)
        {
            ShowFoodObject(true);
            foodObject.GetComponent<Food>().SetFoodData(foodSO);
            foodObject.gameObject.transform.position = this.transform.position;
            currentFoodSO = foodSO;
        }

        public void AddWaitingFoodList(FoodSO foodSO)
        {
            waitingFoodList.Enqueue(foodSO);
        }

        public void CreateNextFood()
        {
            FoodSO foodSO = waitingFoodList.Dequeue();
            CreateFood(foodSO);
        }

        public FoodSO GetCurrentFoodSO()
        {
            ShowFoodObject(false);
            return this.currentFoodSO;
        }

        public override void Interact(PlayerZone.Player player)
        {
            player.AddFoodIntoQueue(GetCurrentFoodSO());
        }
    } 
}
