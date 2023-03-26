using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModesCount : MonoBehaviour
{
    [SerializeField] private ItemSObject countsGame;
   public void EasyMode()
   {
        countsGame.startCountHealthPoint =100;
        countsGame.startCountWaterPoint =100;
        countsGame.startCountBottles =3;
        countsGame.startCountBonus =3;
    }

    public void MiddleMode()
    {
        countsGame.startCountHealthPoint =60;
        countsGame.startCountWaterPoint =30;
        countsGame.startCountBottles =2;
        countsGame.startCountBonus =2;
    }

    public void HardMode()
    {
        countsGame.startCountHealthPoint =25;
        countsGame.startCountWaterPoint =25;
        countsGame.startCountBottles =1;
        countsGame.startCountBonus =1;
    }
}
