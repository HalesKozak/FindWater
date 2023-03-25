using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    [SerializeField] public float heathPoint;

    public Slider sliderHealthPoint;

    private float defaultDamagePoint = 5;

    private void Start()
    {
        sliderHealthPoint.maxValue = heathPoint;
    }

    private void FixedUpdate()
    {
        sliderHealthPoint.value = heathPoint;
    }

    public void TakeDamage(int a)
    {
        if (a == 1)
        {
            heathPoint -= defaultDamagePoint;
        }
        else
        {
            heathPoint -= defaultDamagePoint * Time.deltaTime;
        }
    }
}
