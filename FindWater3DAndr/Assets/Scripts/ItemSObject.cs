using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { BottleWater, Bonus }

public class ItemSObject : ScriptableObject
{
    public ItemType itemType;

    public GameObject itemPrefab;

    [Header("Characteristics")]

    public int indexPrefab;

    public float moveSpeedCount;
    public float healthCount;
    public float waterCount;
}
