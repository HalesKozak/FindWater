using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private StatsPlayer _statsPlayer;
    [SerializeField] private Timer _timer;
    [SerializeField] private SpawnPrefab _spawnPrefab;
    [SerializeField] private StatsProgressGame _statsProgressGame;

    [Header("Components")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;

    [Header("AudioSources")]
    public AudioSource pickUpItemAS;
    public AudioSource pickUpBonusAS;

    public ParticleSystem[] particlesPlayer;
    public ParticleSystem deadCircleParticle;

    [Header("Other Parametres")]
    public GameObject losePanel;


    [SerializeField] private float _moveSpeed;

    private void FixedUpdate()
    {
        if (_animator.GetBool("IsDie") == false)
        {
            _rigidbody.velocity = new Vector3(_fixedJoystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _fixedJoystick.Vertical * _moveSpeed);

            if (_fixedJoystick.Horizontal != 0 || _fixedJoystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
                _animator.SetBool("IsWalking", true);
            }
            else
            {
                _animator.SetBool("IsWalking", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Item>(out var itemScript) == true)
        {
           if(itemScript.item.itemType == ItemType.BottleWater)
           {
                _timer.AddWaterCount(itemScript.item.waterCount);

                _statsProgressGame.bottlesPickUpCount += 1;

                pickUpItemAS.Play();
           }
           else
           {
                if (itemScript.item.moveSpeedCount != 0)
                {
                    StartCoroutine(BaffMoveSpeed(itemScript.item.moveSpeedCount));
                }
                else
                {
                    if ((_statsPlayer.heathPoint += itemScript.item.healthCount) >= _statsPlayer.maxHeathPoint)
                    {
                        _statsPlayer.heathPoint = _statsPlayer.maxHeathPoint;
                    }
                    else
                    {
                        _statsPlayer.heathPoint += itemScript.item.healthCount;
                    }
                }
                _statsProgressGame.bonusPickUpCount += 1;

                pickUpBonusAS.Play();
            }
            particlesPlayer[itemScript.item.indexParticlePlayer].Play();
            _spawnPrefab.SpawnObj(itemScript.item.indexPrefab);

            Destroy(other.gameObject);
        }
        else
        {
            _statsPlayer.TakeDamage(1);
        }
    }

    private void DeadPlayer()
    {
        deadCircleParticle.Play();
    }

    private void ShowLosePanel()
    {
        losePanel.SetActive(true);
        _statsProgressGame.ShowStatsProgressGame();
    }

    IEnumerator BaffMoveSpeed(float bonusMoveSpeed)
    {
        _moveSpeed += bonusMoveSpeed;
        yield return new WaitForSeconds(10f);
        _moveSpeed -= bonusMoveSpeed;
    }
}