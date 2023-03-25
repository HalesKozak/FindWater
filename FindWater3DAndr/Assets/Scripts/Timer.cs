using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private StatsPlayer _statsPlayer;

    public float waterStartCount;
    private float waterCurrentCount;

    public Slider sliderWater;

    private void Start()
    {
        sliderWater.maxValue = waterStartCount;
        waterCurrentCount = waterStartCount;
    }

    private void Update()
    {
        if(waterCurrentCount > 0)
        {
            waterCurrentCount -= Time.deltaTime;

            sliderWater.value = waterCurrentCount;
        }
        else
        {
            _statsPlayer.TakeDamage(2);
        }
       
    }

    public void AddWaterCount(float count)
    {
        if((waterCurrentCount += count) >= waterStartCount)
        {
            waterCurrentCount = waterStartCount;
        }
        else
        {
            waterCurrentCount += count;
        }
    }
}
