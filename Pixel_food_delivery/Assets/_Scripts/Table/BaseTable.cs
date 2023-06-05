using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.PlayerZone;
using Game.Interface;

public class BaseTable :  MonoBehaviour, IInteractable
{
    [SerializeField] protected GameObject foodObject;
    private readonly string PLAYER_TAG = "Player";


    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            player.SetInteractableObject(this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            player.SetInteractableObject(null);
        }
    }
    
    public virtual void Interact(Player player)
    {

    }

    protected void ShowFoodObject(bool isShow)
    {
        foodObject.SetActive(isShow);
    }
}
