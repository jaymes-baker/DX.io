using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class AddToInventory : InteractableTouchTrigger
{
    public UnityEvent OnItemClicked = new UnityEvent();


    bool isInInventory = false;

    public override GameObject OnTouch()
    {
        if (!isInInventory)
        {

            IInventoryItem inventoryItem = gameObject.GetComponent<IInventoryItem>();

            if (inventoryItem != null)
            {
                Debug.Log($"I am {this.gameObject.name} and I should be in inventory");
                OnItemClicked.Invoke();
                systemTrigger.OnUse();
                isInInventory = true;
                return inventoryItem.AddToInventory();
            }
        }
        return this.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        systemTrigger = gameObject.GetComponent<DialogueSystemTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
