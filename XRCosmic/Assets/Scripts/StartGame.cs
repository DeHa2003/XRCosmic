using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public ScriptUI scriptUI;

    private void OnTriggerEnter(Collider other)
    {
        scriptUI.StartPlay();
    }
}
