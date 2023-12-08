using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSliced : MonoBehaviour
{
    public GameObject objects;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < objects.transform.childCount; i++)
        {
            Destroy(objects.transform.GetChild(i).gameObject);
        }
    }
}
