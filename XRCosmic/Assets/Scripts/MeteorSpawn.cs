using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject meteorPref;
    private GameObject[] meteors = new GameObject[20];
    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        GameObject spawn = Instantiate(meteorPref, new Vector3(Random.Range(-100, 100), 30, Random.Range(-100, 100)), meteorPref.transform.rotation);
        Rigidbody rb = spawn.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(new Vector3(Random.Range(1, 4), Random.Range(1, 4), Random.Range(1, 4)) * 1000);
        Invoke(nameof(Spawn), Random.Range(0, 4));
    }
}
