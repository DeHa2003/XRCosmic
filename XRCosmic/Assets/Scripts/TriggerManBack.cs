using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManBack : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(100, 10, 100);
        }
    }
}
