using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private StatsPlayer _statsPlayer;

    public float timeStart;

    public Slider sliderWater;

    private void Start()
    {
        sliderWater.maxValue = timeStart;
    }

    private void Update()
    {
        if(timeStart>0)
        {
            timeStart -= Time.deltaTime;

            sliderWater.value = timeStart;
        }
        else
        {
            _statsPlayer.TakeDamage();
        }
       
    }
}
