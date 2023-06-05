using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;

namespace Game.Customer
{
    public class CustomerSpawner : MonoBehaviorInstance<CustomerSpawner>
    {
        [SerializeField] private List<Transform> tableTransformList = new List<Transform>();
        private List<Transform> invalidTableTransformList = new List<Transform>();

        void Start()
        {
            StartCoroutine(CreateCustomerCR());
        }

        private void CreateCustomer()
        {
            Customer customer = CustomerMaster.Instance.CreateRandomCustomer();
            customer.SetTableTransform(GetRandomTableTransform());
        }

        private Transform GetRandomTableTransform()
        {
            Transform tableTransform = tableTransformList[UnityEngine.Random.Range(0, tableTransformList.Count - 1)];
            tableTransformList.Remove(tableTransform);
            return tableTransform;
        }

        public void AddTableTransform(Transform tableTransform)
        {
            if(!tableTransformList.Contains(tableTransform)) tableTransformList.Add(tableTransform);
        }

        public void AddToInvalidTableTransform(Transform tableTransform)
        {
            if(!invalidTableTransformList.Contains(tableTransform)) invalidTableTransformList.Add(tableTransform);
        }

        public void FixOneTable()
        {
            Transform tableTransform = invalidTableTransformList[0];
            AddTableTransform(tableTransform);
        }

        public void RemoveTableTransform(Transform tableTransform)
        {
            if(tableTransformList.Contains(tableTransform)) tableTransformList.Remove(tableTransform);
        }

        private IEnumerator CreateCustomerCR()
        {
            while(true)
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(3f, 5f));
                CreateCustomer();
            }
        }
    }
}
