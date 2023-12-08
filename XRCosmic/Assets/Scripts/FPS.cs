using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public GameObject slicedObjs;

    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    private float fps = 0;
    private float framesCount = 0;
    private float lastCheck = 0;
    private float rate = 0.5f;

    void Update()
    {
        framesCount++;
        if (Time.time >= lastCheck + rate)
        {
            fps = framesCount / (Time.time - lastCheck);
            lastCheck = Time.time;
            framesCount = 0;
            text.text = fps.ToString("F0");
            text2.text = fps.ToString("F0");
            if(int.Parse(fps.ToString("F0")) <= 30)
            {
                for (int i = 0; i < slicedObjs.transform.childCount; i++)
                {
                    Destroy(slicedObjs.transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
