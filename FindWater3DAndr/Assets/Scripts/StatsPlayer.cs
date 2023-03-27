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

    public float maxHeathPoint;
    public float cactusDamagePoint;
    public void SliderHealthPointCount()
    {
        heathPoint = maxHeathPoint;
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
            heathPoint -= cactusDamagePoint;
        }
        else
        {
            heathPoint -= cactusDamagePoint * Time.deltaTime;
        }

        if (takeDamageParticle.isPlaying == false && heathPoint>=0)
        {
            takeDamageParticle.Play();
        }
    }
}
