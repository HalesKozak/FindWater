using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "New Item")]

public class CreateItemSO : ItemSObject
{
    private void Start()
    {
       itemType = ItemType.BottleWater;
    }
}
