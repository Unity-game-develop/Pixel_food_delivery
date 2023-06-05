using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;

namespace Game.Customer
{
    public class CustomerMaster : MonoBehaviorInstance<CustomerMaster>
    {
        public Customer CreateRandomCustomer(Transform parent = null)
        {
            Customer[] customers = Resources.LoadAll<Customer>("Prefab/Customer");
            Customer cloneCustomer = customers[UnityEngine.Random.Range(0, customers.Length)];
            Customer customer = Instantiate<Customer>(cloneCustomer, parent);
            return customer;
        }
    }
}
