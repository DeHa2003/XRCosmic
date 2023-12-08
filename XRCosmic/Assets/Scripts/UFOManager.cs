using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOManager : MonoBehaviour
{
    public GameObject ufoPref;
    private List<GameObject> spawnUFOs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CheckCountUFO();
    }

    private void CheckCountUFO()
    {
        if(spawnUFOs.Count < 4)
        {
            GameObject spawn = Instantiate(ufoPref, new Vector3(Random.Range(0, 200), 30, Random.Range(0, 200)), ufoPref.transform.rotation);
            spawn.transform.localScale = new Vector3(5, 5, 5);
            spawnUFOs.Add(spawn);
        }

        for (int i = 0; i < spawnUFOs.Count; i++)
        {
            if (spawnUFOs[i] == null)
            {
                spawnUFOs.Remove(spawnUFOs[i]);
            }
        }

        Invoke(nameof(CheckCountUFO), 3);
    }
}
