using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform player;

    public Joystick joystick;

    private Animator animator;

    //public AudioSource attackClip;
    //public AudioSource drinkingClip;

    public float speed = 3;

    private Vector3 velocity;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
      
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

    private void OnTriggerEnter(Collider other)
    {
       
    }
}
