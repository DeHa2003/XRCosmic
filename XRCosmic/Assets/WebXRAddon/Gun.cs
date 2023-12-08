using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;
using WebXR.Interactions;

public class Gun : MonoBehaviour
{
    public WebXRController controller;
    public ControllerInteraction controllerInteraction;

    [Header("Gun")]
    public GameObject gun;
    public GameObject bulletPref;
    public Transform pos1Bullet;
    public Transform pos2Bullet;

    private int bulletFire = 0;
    private AudioSource audioSource;
    public AudioClip clipFire;
    public AudioClip clipPerezaryad;
    private bool fire = true;
    private void Start()
    {
        audioSource = gun.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.GetButtonDown(WebXRController.ButtonTypes.Trigger))
        {
            Vistrel();
        }
    }

    private void Vistrel()
    {
        if (fire)
        {
            bulletFire += 1;
            if (bulletFire == 10)
            {
                fire = false;
                bulletFire = 0;
                audioSource.clip = clipPerezaryad;
                audioSource.Play();

                Invoke(nameof(Perezaryad), 1.2f);
            }
            else
            {
                audioSource.clip = clipFire;
                audioSource.Play();
            }


            GameObject bullet1 = Instantiate(bulletPref, pos1Bullet.position, bulletPref.transform.rotation);
            SetBullet(bullet1);
            GameObject bullet2 = Instantiate(bulletPref, pos2Bullet.position, bulletPref.transform.rotation);
            SetBullet(bullet2);
        }
    }

    private void SetBullet(GameObject bullet)
    {
        bullet.transform.localScale = new Vector3(0.008f, 0.008f, 0.016f);

        Rigidbody rb = bullet.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(gun.transform.forward * 1000);

        Destroy(bullet, 3);
    }

    private void Perezaryad()
    {
        fire = true;
    }
}
