using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject[] explosionPrefab;

    public Vector3 minPosition;
    public Vector3 maxPosition;
    public void SpawnObj(int indexPrefab)
    {
        Vector3 randomPosition = new Vector3
      (
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z)
      );
        Instantiate(explosionPrefab[indexPrefab], randomPosition, Quaternion.identity);
    }
}
