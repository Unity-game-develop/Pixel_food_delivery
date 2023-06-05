using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.FoodZone;
using Game.Manager;

namespace Game.Customer
{
    public class Customer : MonoBehaviour
    {
        public float speed = 2f;
        private SpriteRenderer sr;
        private FoodSO requireFood;
        private Transform tableTransform;

        void Start()
        {
            sr = gameObject.GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            MoveToTable();
        }

        public void SetTableTransform(Transform tableTransform)
        {
            this.tableTransform = tableTransform;
        }

        public void SetFood(Food food)
        {
            if(IsCorrectFood(food))
            {
                CustomerSpawner.Instance.AddTableTransform(this.tableTransform);
                EventManager.Instance.RaiseEvent(EventType.OnCustomerCorrectFood);
            }
            else
            {
                CustomerSpawner.Instance.AddToInvalidTableTransform(this.tableTransform);
                EventManager.Instance.RaiseEvent(EventType.OnCustomerWrongFood);
            }
        }

        public bool IsCorrectFood(Food food)
        {
            return requireFood.Equals(food);
        }

        public void MoveToTable()
        {
            if(tableTransform != null && Vector3.Distance(this.transform.position, tableTransform.position) > 0.3f)
                this.transform.position += GetTableDirection() * speed * Time.deltaTime;
        }

        public Vector3 GetTableDirection()
        {
            return (tableTransform.position - this.transform.position).normalized; 
        }
    }
}
