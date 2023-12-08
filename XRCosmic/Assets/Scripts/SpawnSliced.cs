using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSliced : MonoBehaviour
{
    public Transform posSpawn;
    public GameObject slicedPref;
    public GameObject objects;

    private void OnTriggerEnter(Collider other)
    {
        GameObject spawn = Instantiate(slicedPref, posSpawn.position, new Quaternion(Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f), 0));
        spawn.transform.localScale = new Vector3(0.18f, 0.18f, 0.18f);
        spawn.transform.parent = objects.transform;
    }
}
