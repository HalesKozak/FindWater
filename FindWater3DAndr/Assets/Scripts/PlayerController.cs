using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;

    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private StatsPlayer _statsPlayer;
    [SerializeField] private Timer _timer;

    [SerializeField] private float _moveSpeed;

    public AudioSource pickUpItemAS;
    public AudioSource pickUpBonusAS;

    private void FixedUpdate()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Item>(out var itemScript) == true)
        {
           if(itemScript.item.itemType == ItemType.BottleWater)
           {
                _timer.AddWaterCount(itemScript.item.waterCount);
                pickUpItemAS.Play();

                Destroy(other.gameObject);
           }
           else
           {
                if (itemScript.item.moveSpeedCount != 0)
                {
                    StartCoroutine(BaffMoveSpeed(itemScript.item.moveSpeedCount));
                }
                else
                {
                    _statsPlayer.heathPoint += itemScript.item.healthCount;
                }

                pickUpBonusAS.Play();

                Destroy(other.gameObject);
            }
        }
        else
        {
            _statsPlayer.TakeDamage(1);
        }
    }

    IEnumerator BaffMoveSpeed(float bonusMoveSpeed)
    {
        _moveSpeed += bonusMoveSpeed;
        yield return new WaitForSeconds(10f);
        _moveSpeed -= bonusMoveSpeed;
    }
}
