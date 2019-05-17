using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleItem : MonoBehaviour, IInventoryItem
{
    public GameObject InventoryObject;
    private bool m_isInInventory = false;

    public GameObject AddToInventory()
    {
        //TODO: Make this work for real
        gameObject.transform.position = InventoryObject.transform.position;
        m_isInInventory = true;
        return this.gameObject;
    }

    public bool isInInventory()
    {
        return m_isInInventory;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!InventoryObject)
        {
            InventoryObject = GameObject.FindGameObjectWithTag("Inventory");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
