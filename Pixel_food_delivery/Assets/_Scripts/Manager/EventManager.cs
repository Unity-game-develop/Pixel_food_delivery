using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NOOD;

public enum EventType
{
    OnCustomerCorrectFood,
    OnCustomerWrongFood,
}

namespace  Game.Manager
{
    public class EventManager : MonoBehaviorInstance<EventManager>
    {
        #region Events
        [SerializeField] private CustomDictionary<EventType, VoidEventChannelSO> eventDictionary = new CustomDictionary<EventType, VoidEventChannelSO>();
        #endregion

        public VoidEventChannelSO GetEventChannelSO(EventType eventType)
        {
            return eventDictionary[eventType];
        }

        public void RaiseEvent(EventType eventType)
        {
            GetEventChannelSO(eventType).RaiseEvent();
        }

        public void SubscribeToVoidEvent(EventType eventType, UnityAction action)
        {
            GetEventChannelSO(eventType).OnEventRaise += action;
        }

        public void UnSubscribeToVoidEvent(EventType eventType, UnityAction action)
        {
            GetEventChannelSO(eventType).OnEventRaise -= action;
        }
    }
    
}
