using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babah : MonoBehaviour
{
    public AudioClip clipFly;
    public AudioClip clipBabah;

    private bool babah = true;
    private GameObject player;
    private void Start()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.clip = clipFly;
        audio.Play();
        Invoke(nameof(Delete), 10);
    }
    private void OnCollisionEnter(Collision collision)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Animator animator = player.GetComponent<Animator>();
        animator.SetBool("babah", false);
        animator.SetBool("babah", true);
        StartCoroutine(Anim(animator));

        babah = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false; 

        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.volume = 0.9f;
        audio.clip = clipBabah;
        audio.Play();

        Destroy(gameObject, 3);
    }

    private void Delete()
    {
        if(babah == true)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Anim(Animator animator)
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("babah", false);
    }
}
