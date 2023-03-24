using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    [SerializeField] private float heathPoint;

    public Slider sliderHealthPoint;

    private float damagePoint = 5;

    private void Start()
    {
        sliderHealthPoint.maxValue = heathPoint;
    }

    private void FixedUpdate()
    {
        sliderHealthPoint.value = heathPoint;
    }

    public void TakeDamage()
    {
        heathPoint -= damagePoint * Time.deltaTime;
    }
}
