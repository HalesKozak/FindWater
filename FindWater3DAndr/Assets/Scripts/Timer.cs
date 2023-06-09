using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private StatsPlayer _statsPlayer;
    [SerializeField] private DayCycleManager _dayCycleManager;

    public float waterStartCount;
    private float waterCurrentCount;

    public Slider sliderWater;

    public GameObject pauseText;

    public AudioSource pauseAS;

    public void StartTimer()
    {
        sliderWater.maxValue = waterStartCount;
        waterCurrentCount = waterStartCount;

        pauseText.SetActive(false);
    }

    private void Update()
    {
        if(waterCurrentCount > 0)
        {
            if (_dayCycleManager.TimeOfDay >= 0.5)
            {
                waterCurrentCount -= Time.deltaTime / 2;
            }
            else
            {
                waterCurrentCount -= Time.deltaTime;
            }

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

    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }

        pauseAS.Play();
        pauseText.SetActive(!pauseText.activeSelf);
    }
}
