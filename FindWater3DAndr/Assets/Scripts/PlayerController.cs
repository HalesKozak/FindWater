using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick  _floatingJoystick;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;

    //public AudioSource attackClip;
    //public AudioSource drinkingClip;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_floatingJoystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _floatingJoystick.Vertical * _moveSpeed);
      
        if(_floatingJoystick.Horizontal !=0 || _floatingJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }

        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        //{

        //    if (Input.GetKey(KeyCode.W))
        //    {
        //        if (speed < 3) animator.SetFloat("Side", 1);
        //        else if (speed < 6) animator.SetFloat("Side", 2);
        //        else animator.SetFloat("Side", 3);
        //    }
        //    else if (Input.GetKey(KeyCode.S))
        //    {
        //        if (speed < 3) animator.SetFloat("Side", 8);
        //        else animator.SetFloat("Side", 9);
        //    }
        //    else if (Input.GetKey(KeyCode.A))
        //    {
        //        if (speed < 3) animator.SetFloat("Side", 4);
        //        else animator.SetFloat("Side", 7);
        //    }
        //    else if (Input.GetKey(KeyCode.D))
        //    {
        //        if (speed < 3) animator.SetFloat("Side", 6);
        //        else animator.SetFloat("Side", 5);
        //    }
        //}
        //else animator.SetFloat("Side", 10);
    }

    //private void OnTriggerEnter(Collider other)
    //{
       
    //}
}
