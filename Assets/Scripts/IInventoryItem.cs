using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    bool isInInventory();
    GameObject AddToInventory();
}
