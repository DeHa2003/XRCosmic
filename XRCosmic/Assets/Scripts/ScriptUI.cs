using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptUI : MonoBehaviour
{
    public Gun gun;
    public GameObject startUI;
    public GameObject player;
    public List<GameObject> handObjs;
    public Animator animator;
    public AudioSource sound;
    public GameObject effects;
    private GameObject spaceShip;

    private void Start()
    {
        spaceShip = gameObject.transform.parent.gameObject;
    }

    public void StartPlay()
    {
        StartCoroutine(nameof(Play));
    }

    IEnumerator Play()
    {
        animator.SetBool("Start", true);
        yield return new WaitForSeconds(3.5f);
        gun.enabled = true;
        animator.SetBool("Start", false);
        startUI.SetActive(false);
        spaceShip.transform.position = new Vector3(100, 30, 100);
        effects.SetActive(false);
        sound.volume = 0.4f;

        player.GetComponent<Player>().enabled = true;
        for (int i = 0; i < handObjs.Count; i++)
        {
            handObjs[i].SetActive(true);
        }
    }
}
