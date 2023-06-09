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
    public int indexParticlePlayer;

    public float moveSpeedCount;
    public float healthCount;
    public float waterCount;

    [Header("ModeCounts")]
    public float startCountHealthPoint;
    public float startCountWaterPoint;
    public float start—actusDamagePoint;

    public int startCountBottles;
    public int startCountBonus;

    public string gameMode;
}