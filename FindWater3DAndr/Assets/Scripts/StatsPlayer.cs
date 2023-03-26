using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    [SerializeField] public float heathPoint;

    [SerializeField] private Animator _animator;

    public Slider sliderHealthPoint;

    public ParticleSystem takeDamageParticle;

    public AudioSource takeDamageAS;

    private float defaultDamagePoint = 5;

    public void SliderHealthPointCount()
    {
        sliderHealthPoint.maxValue = heathPoint;
    }

    private void FixedUpdate()
    {
        if (heathPoint <= 0)
        {
            _animator.SetBool("IsDie", true);
        }
        sliderHealthPoint.value = heathPoint;
    }

    public void TakeDamage(int a)
    {
        takeDamageAS.Play();

        if (a == 1)
        {
            heathPoint -= defaultDamagePoint;
        }
        else
        {
            heathPoint -= defaultDamagePoint * Time.deltaTime;
        }

        if (takeDamageParticle.isPlaying == false && heathPoint>=0)
        {
            takeDamageParticle.Play();
        }
    }
}
