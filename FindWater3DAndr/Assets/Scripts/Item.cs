using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSObject item;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Cactus"))
        {
            Vector3 changePosition = new Vector3(transform.position.x+2f, transform.position.y, transform.position.z);
            transform.position = changePosition;
        }
    }
}
