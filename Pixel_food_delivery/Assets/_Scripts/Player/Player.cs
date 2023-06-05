using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Interface;
using NOOD;

namespace Game.PlayerZone
{
    public class Player : MonoBehaviorInstance<Player>
    {
        #region Components
        [SerializeField] private PlayerAnimation playerAnimation;
        private Queue<FoodZone.FoodSO> foodDatas = new Queue<FoodZone.FoodSO>();
        private IInteractable interactableObject;
        #endregion

        [SerializeField] private float runSpeed;
        [SerializeField] private float dashSpeed;
        [SerializeField] private float moveSpeed;

        private void Start()
        {
            moveSpeed = runSpeed;
            GameInput.Instance.OnPlayerLMoveVector2 += HandleMovement;
        }

        private void Update()
        {
            
        }

        private void HandleMovement(Vector2 playerInputMovement)
        {
            if(playerInputMovement != Vector2.zero)
            {
                // Player move
                Vector3 playerMovement = new Vector3(playerInputMovement.x, playerInputMovement.y, 0);
                this.transform.position += playerMovement * moveSpeed * Time.deltaTime;
                playerAnimation.AnimateWalk();

                // Player turn
                playerAnimation.TurnLeft(playerInputMovement.x < 0);
            }
            else
            {
                playerAnimation.AnimateIdle();
            }
        }

        public void SetInteractableObject(IInteractable interactableObject)
        {
            this.interactableObject = interactableObject;
        }

        public IInteractable GetInteractableObject()
        {
            return this.interactableObject;
        }

        public void AddFoodIntoQueue(FoodZone.FoodSO foodData)
        {
            foodDatas.Enqueue(foodData);
        }

        public FoodZone.FoodSO GetFoodData()
        {
            return foodDatas.Dequeue();
        }

        private void Interact()
        {
            if(interactableObject != null)
            {
                interactableObject.Interact(this);
            }
        }
    }
}
