using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    public float TimeOfDay;
    public float DayDuration = 60f;

    public AnimationCurve SunCurve;

    public Light Sun;

    private float sunIntensity;

    private void Start()
    {
        sunIntensity = Sun.intensity;
    }

    private void Update()
    {
        TimeOfDay += Time.deltaTime / DayDuration;
        if (TimeOfDay >= 1) TimeOfDay -= 1;

        Sun.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f, 180, 0);
        Sun.intensity = sunIntensity * SunCurve.Evaluate(TimeOfDay);
    }
}
